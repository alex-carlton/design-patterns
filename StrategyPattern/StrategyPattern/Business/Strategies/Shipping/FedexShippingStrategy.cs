using StrategyPattern.Business.Models;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Strategies.Shipping
{
    public class FedexShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                //TODO: Implement DHL Shipping Integration

                Console.WriteLine("Order is shipped with FedEx");
            }
        }
    }
}