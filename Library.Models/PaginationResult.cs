using System;
using System.Collections.Generic;

namespace Library.Models
{
    public class PaginationResult<T> where T:class
    {
        public List<T> Results { get; set; }
        public int Perpage { get; set; }
        public int PageNumber { get; set; }
    }
}