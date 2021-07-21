using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Library.Models;
using Library.Models.Dtos;
using LibraryService.Interfaces;
using LibraryService.Models;

namespace LibraryService
{
    public class CheckoutService : ICheckout
    {
        private readonly LibraryContext _dbContext;
        private readonly IMapper _mapper;
        public CheckoutService(
            LibraryContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Add(Checkout newCheckout)
        {
            _dbContext.Checkouts.Add(newCheckout);
            _dbContext.SaveChanges();
        }

        public void CheckInItem(Guid assetId, Guid libraryCardId)
        {
            var now = DateTime.Now;
            var asset = _dbContext.LibraryAssets.FirstOrDefault(x => x.Id == assetId);
            var card = _dbContext.LibraryCards.FirstOrDefault(x => x.Id == libraryCardId);

            _dbContext.LibraryAssets.Update(asset);
            asset.Status = _dbContext.Statuses
                    .FirstOrDefault(x => x.Name == "Available");

            //remove existing checkouts
            RemoveExistingCheckout(assetId);
            //close existing checkout history
            var checkout = _dbContext.CheckoutHistories.FirstOrDefault(x => x.LibraryAsset.Id == assetId);
            if (checkout != null)
            {
                checkout.CheckedInTime = now;
            }
            //look for existing holds
            var currentHolds = _dbContext.Holds
                .Include(x => x.LibraryAsset)
                .Include(x => x.LibraryCard)
                .Where(x => x.LibraryAsset.Id == assetId);

            if (currentHolds.Any())
            {
                var firstHold = currentHolds.OrderByDescending(x => x.HoldPlaced).FirstOrDefault();
                var newCheckout = new Checkout()
                {
                    Id= new Guid(),
                    LibraryAsset = firstHold.LibraryAsset,
                    LibraryCard = firstHold.LibraryCard,
                    Since = now
                };
                _dbContext.Checkouts.Add(newCheckout);
                _dbContext.Holds.Remove(firstHold);

                var newCheckoutHistory = new CheckoutHistory()
                {
                    Id = new Guid(),
                    LibraryAsset = firstHold.LibraryAsset,
                    LibraryCard = firstHold.LibraryCard,
                    CheckedOutTime = now
                };
                _dbContext.CheckoutHistories.Add(newCheckoutHistory);

                UpdateAssetStatus(assetId, "Checked Out");
            }
            _dbContext.SaveChanges();
        }

        public bool IsAssetCheckedOut(Guid assetId)
        {
            return _dbContext.Checkouts.Any(x => x.Id == assetId);
        }
        public void CheckOutItem(Guid assetId, Guid libraryCardId)
        {
            if (IsAssetCheckedOut(assetId))
                return;

            UpdateAssetStatus(assetId, "Checked Out");
            var now = DateTime.Now;
            var asset = _dbContext.LibraryAssets.FirstOrDefault(x => x.Id == assetId);
            var card = _dbContext.LibraryCards.FirstOrDefault(x => x.Id == libraryCardId);

            var newCheckout = new Checkout()
            {
                Id = new Guid(),
                LibraryAsset = asset,
                LibraryCard = card,
                Since = now,
                Util = now.AddDays(10)
            };
            _dbContext.Checkouts.Add(newCheckout);

            var newCheckoutHistory = new CheckoutHistory()
            {
                Id = new Guid(),
                LibraryAsset = asset,
                LibraryCard = card,
                CheckedOutTime = now
            };
            _dbContext.CheckoutHistories.Add(newCheckoutHistory);

            _dbContext.SaveChanges();
        }

        public IEnumerable<Checkout> GetAll()
        {
            return _dbContext.Checkouts;
        }

        public async Task<PagedServiceResult<CheckoutHistoryDto>> GetCheckoutHistories(Guid id, int page, int perPage)
        {
            var entsToSkip = (page - 1) * perPage;
            var histories =  await _dbContext.CheckoutHistories
                .Include(x => x.LibraryAsset)
                .Include(x => x.LibraryCard)
                .Where(x => x.LibraryAsset.Id == id).ToListAsync();
            
            var pageOfHistories = histories.Skip(entsToSkip).Take(perPage);
            var paginatedHistories = _mapper.Map<List<CheckoutHistoryDto>>(pageOfHistories);
            return new PagedServiceResult<CheckoutHistoryDto>()
            {
                Data = new PaginationResult<CheckoutHistoryDto>()
                {
                    Results =  paginatedHistories,
                    Perpage = perPage,
                    PageNumber = page
                },
                Error =  null
            };
        }

        public IEnumerable<Hold> GetCurrentHolds(Guid Id)
        {
            return _dbContext.Holds
                .Where(x => x.LibraryAsset.Id == Id);
        }

        public Checkout GetLatestCheckout(Guid assetId)
        {
            return _dbContext.Checkouts
                .Include(x=>x.LibraryCard)
                .Include(x=>x.LibraryAsset)
                .Where(x => x.LibraryAsset.Id == assetId)
                .OrderByDescending(x => x.Since)
                .FirstOrDefault();
;        }

        public void MarkFound(Guid assetId)
        {
            UpdateAssetStatus(assetId, "Available");
            _dbContext.SaveChanges();
        }

        public void MarkLost(Guid assetId)
        {
            UpdateAssetStatus(assetId, "Lost");
            RemoveExistingCheckout(assetId);
            _dbContext.SaveChanges();
        }

        public void UpdateAssetStatus(Guid assetId, string status)
        {
            var asset = _dbContext.LibraryAssets
                .FirstOrDefault(x => x.Id == assetId);
            if (asset != null)
            {
                asset.Status = _dbContext.Statuses
                    .FirstOrDefault(x => x.Name == status);
            }
        }

        public void RemoveExistingCheckout(Guid assetId)
        {
            var checkout = _dbContext.Checkouts.FirstOrDefault(x => x.LibraryAsset.Id == assetId);
            if (checkout != null)
            {
                _dbContext.Checkouts.Remove(checkout);
            }
        }

        public void PlaceHold(Guid assetId, Guid libraryCardId)
        {
            var now = DateTime.Now;
            var asset = _dbContext.LibraryAssets.FirstOrDefault(x => x.Id == assetId);
            var card = _dbContext.LibraryCards.FirstOrDefault(x => x.Id == libraryCardId);

            var hold = new Hold()
            {
                Id = new Guid(),
                LibraryAsset = asset,
                LibraryCard = card,
                HoldPlaced = now
            };
            _dbContext.Holds.Add(hold);
            _dbContext.SaveChanges();
        }

        public string GetPatronCheckout(Guid assetId)
        {
            var checkout = _dbContext.Checkouts
                .Include(x => x.LibraryCard.Patron)
                .FirstOrDefault(x => x.LibraryAsset.Id == assetId);
            if(checkout!=null)
                return $"{checkout.LibraryCard.Patron.FirstName}, {checkout.LibraryCard.Patron.LastName}";
            return "";
        }
    }
}
