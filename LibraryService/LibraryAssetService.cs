using LibraryData;
using LibraryData.Models;
using LibraryData.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryService
{
    public class LibraryAssetService : ILibraryAsset
    {
        protected LibraryContext _dbContext;
        public LibraryAssetService(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Add(LibraryAsset entity)
        {
            await _dbContext.LibraryAssets.AddAsync(entity);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<LibraryAsset>> All()
        {
            return await _dbContext.LibraryAssets
                .Include(asset=> asset.Status)
                .Include(asset=>asset.Location).ToListAsync();
        }

        public async Task<LibraryAsset> GetById(Guid Id)
        {
            return await _dbContext.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public LibraryBrach GetCurrentLocation(Guid Id)
        {
            return GetById(Id).Result.Location;
        }

        public string GetIsbn(Guid Id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == Id).ISBN;
        }

        public string GetTitle(Guid Id)
        {
            return _dbContext.Books.FirstOrDefault(x => x.Id == Id).Title;
        }

        public string GetType(Guid Id)
        {
            return _dbContext.LibraryAssets.OfType<Book>().Any() ? "Book" : "Unknow";
        }
    }
}
