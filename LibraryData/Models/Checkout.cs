using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Checkout
    {
        public Guid Id { get; set; }
        public LibraryAsset LibraryAsset { get; set; }
        public LibraryCard LibraryCard { get; set; }
        public DateTime Since { get; set; }
        public DateTime Util { get; set; }
    }
}
