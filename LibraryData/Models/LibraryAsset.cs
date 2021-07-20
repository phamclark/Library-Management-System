using System;

namespace LibraryData.Models
{
    public abstract class LibraryAsset
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int PublishingYear { get; set; }
        public Status Status { get; set; }
        public decimal Cost { get; set; }
        public string CoverImageUrl { get; set; }
        public int NumberOfCopies { get; set; }
        public virtual LibraryBrach Location { get; set; }
    }
}