using System;

namespace RushToWin.API.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }       
        public double Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public Wallet Wallet { get; set; }
    }
}
