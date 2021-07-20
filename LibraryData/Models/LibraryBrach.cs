using System;
using System.Collections.Generic;

namespace LibraryData.Models
{
    public class LibraryBrach
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelePhone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }
        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }
        public string BackgroundImageUrl { get; set; }
    }
}