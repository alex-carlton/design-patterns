using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}