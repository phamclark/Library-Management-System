using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBookStore.Models.Catalog
{
    public class AssetIndexListingModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublishingYear { get; set; }
        public decimal Cost { get; set; }
        public string CoverImageUrl { get; set; }
        public int NumberOfCopies { get; set; }
        public string Type { get; set; }
    }
}
