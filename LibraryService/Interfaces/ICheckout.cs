using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Library.Models.Dtos;
using LibraryService.Models;

namespace LibraryService.Interfaces
{
    public interface ICheckout
    {
        IEnumerable<Checkout> GetAll();
        void Add(Checkout newCheckout);
        void CheckOutItem(Guid assetId, Guid libraryCardId);
        void CheckInItem(Guid assetId, Guid libraryCardId);
        Task<PagedServiceResult<CheckoutHistoryDto>> GetCheckoutHistories(Guid id, int page, int perPage);
        IEnumerable<Hold> GetCurrentHolds(Guid Id);
        Checkout GetLatestCheckout(Guid assetId);
        void MarkLost(Guid assetId);
        void MarkFound(Guid assetId);
        void PlaceHold(Guid assetId, Guid libraryCardId);
        bool IsAssetCheckedOut(Guid assetId);
        string GetPatronCheckout(Guid assetId);
    }
}
