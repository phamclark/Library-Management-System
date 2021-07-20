using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryBookStore.Models.Checkout;

namespace LibraryBookStore.Models.Catalog
{
    public class AssetDetailModel
    {
        public Guid AssetId { get; set; }
        public string Tittle { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int PublishedYear { get; set; }
        public string ISBN { get; set; }
        public string ISBNCodeImage { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public string CurrentLocation { get; set; }
        public string CoverImage { get; set; }
        public string PatronName { get; set; }
        public LibraryData.Models.Checkout LastestCheckout { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistory { get; set; }
        public IEnumerable<AssetHoldModel> CurrentHolds { get; set; }
    }

    public class AssetHoldModel
    {
        public string PatronName { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
