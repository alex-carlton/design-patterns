﻿using StrategyPattern.Business.Models;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Strategies.Shipping
{
    public class PostNordShippingStrategy : IShippingStrategy
    {
        public void Ship(Order order)
        {
            using (var client = new HttpClient())
            {
                //TODO: Implement Post Nord Shipping Integration

                Console.WriteLine("Order is shipped with Post Nord");
            }
        }
    }
}