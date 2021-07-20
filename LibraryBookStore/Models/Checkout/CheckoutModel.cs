using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookStore.Models.Checkout
{
    public class CheckoutModel
    {
        public string LibraryCardId { get; set; }
        public Guid AssetId { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
        public bool IsCheckedOut { get; set; }     
    }
}
