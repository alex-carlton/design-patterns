using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies
{
    public class USAStateSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            switch (order.ShippingDetails.DestinationState.ToLower())
            {
                case "ca": return order.TotalPrice * 0.095m;
                case "il": return order.TotalPrice * 0.04m;
                case "ny": return order.TotalPrice * 0.045m;
                default: return 0m;
            }
        }
    }
}