using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class Patron
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName}, {LastName}";
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public bool Active { get; set; }
        public string Avatar { get; set; }
        public int RewardPoint { get; set; }
    }
}
