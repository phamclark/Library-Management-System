using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Services
{
    public interface ILibraryAsset
    {
        Task<IEnumerable<LibraryAsset>> All();
        Task<LibraryAsset> GetById(Guid Id);
        Task<bool> Add(LibraryAsset entity);
        string GetType(Guid Id);
        string GetTitle(Guid Id);
        string GetIsbn(Guid Id);
        LibraryBrach GetCurrentLocation(Guid Id);
    }
}
