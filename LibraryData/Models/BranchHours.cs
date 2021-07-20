using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
    public class BranchHours
    {
        public Guid Id { get; set; }
        public LibraryBrach Branch { get; set; }
        public int DayOfWeek { get; set; }
        public int OpenTime { get; set; }
        public int CloseTime { get; set; }
    }
}
