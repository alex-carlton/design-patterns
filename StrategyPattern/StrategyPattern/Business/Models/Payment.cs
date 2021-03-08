using StrategyPattern.Business.Models.Enums;

namespace StrategyPattern.Business.Models
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public PaymentProvider PaymentProvider { get; set; }
    }
}