using System;

namespace Library.Models.Dtos
{
    public class CheckoutHistoryDto
    {
        public Guid Id { get; set; }
        public DateTime CheckedOutTime { get; set; }
        public DateTime? CheckedInTime { get; set; }
    }
}