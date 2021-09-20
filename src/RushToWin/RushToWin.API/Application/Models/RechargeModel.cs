using System;

namespace RushToWin.API.Application.Models
{
    public class RechargeModel
    {
        public Guid WalletId { get; set; }
        public double Value { get; set; }
    }
}
