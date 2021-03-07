using StrategyPattern.Business.Models;
using StrategyPattern.Business.Strategies;
using System;

namespace StrategyPattern
{
    internal static class Program
    {
        private static void Main()
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            var destination = order.ShippingDetails.DestinationCountry.ToLower();

            if (destination == "sweden")
            {
                order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
            }
            else if (destination == "us")
            {
                order.SalesTaxStrategy = new USAStateSalesTaxStrategy();
            }

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            Console.WriteLine(order.GetTax());
            Console.ReadKey();
        }
    }
}