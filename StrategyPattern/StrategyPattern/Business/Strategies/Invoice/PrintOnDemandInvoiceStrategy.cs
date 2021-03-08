using Newtonsoft.Json;
using StrategyPattern.Business.Models;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Strategies.Invoice
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);

                client.BaseAddress = new Uri("https://test.api.com");

                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}