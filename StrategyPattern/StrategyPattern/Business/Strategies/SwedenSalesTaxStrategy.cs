using StrategyPattern.Business.Models;

namespace StrategyPattern.Business.Strategies
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var destination = order.ShippingDetails.DestinationCountry.ToLower();
            var origin = order.ShippingDetails.OriginCountry.ToLower();

            if (destination == origin)
            {
                return order.TotalPrice * 0.25m;
            }

            #region Tax per item

            //if (destination == ShippingDetails.OriginCountry.ToLowerInvariant())
            //{
            //    decimal totalTax = 0m;
            //    foreach (var item in LineItems)
            //    {
            //        switch (item.Key.ItemType)
            //        {
            //            case ItemType.Food:
            //                totalTax += (item.Key.Price * 0.06m) * item.Value;
            //                break;

            //            case ItemType.Literature:
            //                totalTax += (item.Key.Price * 0.08m) * item.Value;
            //                break;

            //            case ItemType.Service:
            //            case ItemType.Hardware:
            //                totalTax += (item.Key.Price * 0.25m) * item.Value;
            //                break;
            //        }
            //    }

            //    return totalTax;
            //}

            #endregion Tax per item

            return 0m;
        }
    }
}