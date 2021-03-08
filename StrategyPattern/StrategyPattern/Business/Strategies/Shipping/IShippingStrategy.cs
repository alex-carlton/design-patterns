using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Shipping
{
    public interface IShippingStrategy
    {
        void Ship(Order order);
    }
}