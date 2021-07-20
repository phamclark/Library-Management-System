using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class CheckoutHistory
    {
        public Guid Id { get; set; }
        public LibraryAsset LibraryAsset { get; set; }
        public LibraryCard LibraryCard { get; set; }
        public DateTime CheckedOutTime { get; set; }
        public DateTime? CheckedInTime { get; set; }
    }
}
