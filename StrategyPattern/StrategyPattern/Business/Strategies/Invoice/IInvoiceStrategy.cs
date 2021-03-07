using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies.Invoice
{
    public interface IInvoiceStrategy
    {
        public void Generate(Order order);
    }
}