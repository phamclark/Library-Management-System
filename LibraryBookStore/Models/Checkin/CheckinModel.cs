using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookStore.Models.Checkin
{
    public class CheckinModel
    {
        public string LibraryCardId { get; set; }
        public Guid AssetId { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string ImageUrl { get; set; }
    }
}
