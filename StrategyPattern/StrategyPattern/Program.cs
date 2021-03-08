using StrategyPattern.Business.Models;
using StrategyPattern.Business.Models.Enums;
using StrategyPattern.Business.Strategies;
using StrategyPattern.Business.Strategies.Invoice;
using StrategyPattern.Business.Strategies.Shipping;
using System;

namespace StrategyPattern
{
    internal static class Program
    {
        private static void Main()
        {
            #region Input

            Console.WriteLine("Please select an origin country: ");
            var origin = Console.ReadLine().Trim();
            var originState = String.Empty;

            if (string.Equals(origin, "usa", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Chose one of the following origin states.");
                Console.WriteLine("1. California");
                Console.WriteLine("2. Illinois");
                Console.WriteLine("3. New York");
                Console.WriteLine("Select shipping provider: ");
                originState = GetState(Convert.ToInt32(Console.ReadLine().Trim()));
            }

            Console.Clear();
            Console.WriteLine("Please select a destination country: ");
            var destination = Console.ReadLine().Trim();
            var destinationState = String.Empty;

            if (string.Equals(destination, "usa", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Chose one of the following destination states.");
                Console.WriteLine("1. CA");
                Console.WriteLine("2. IL");
                Console.WriteLine("3. NY");
                Console.WriteLine("Select shipping provider: ");
                destinationState = GetState(Convert.ToInt32(Console.ReadLine().Trim()));
            }

            Console.Clear();
            Console.WriteLine("Choose one of the following shipping providers.");
            Console.WriteLine("1. UPS");
            Console.WriteLine("2. FedEx");
            Console.WriteLine("3. PostNord");
            Console.WriteLine("Select shipping provider: ");
            var provider = Convert.ToInt32(Console.ReadLine().Trim());

            Console.Clear();
            Console.WriteLine("Choose one of the following invoice delivery options.");
            Console.WriteLine("1. E-mail");
            Console.WriteLine("2. File");
            Console.WriteLine("3. Mail");
            Console.WriteLine("Select invoice delivery options: ");
            var invoiceOption = Convert.ToInt32(Console.ReadLine().Trim());

            #endregion Input

            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = origin,
                    OriginState = originState,
                    DestinationCountry = destination,
                    DestinationState = destinationState
                },
                SalesTaxStrategy = GetSalesTaxStrategyFor(origin),
                InvoiceStrategy = GetInvoiceStrategyFor(invoiceOption),
                ShippingStrategy = GetShippingStrategyFor(provider)
            };

            order.LineItems.Add(new Item("{7CF326C9-FB24-4D39-99E0-203E16E064BF}", "Dry Cleaners", 23.96m, ItemType.Service), 1);
            order.LineItems.Add(new Item("{B3FB771B-616E-4379-A1F8-0FA178F98229}", "The Silmarillion", 13.69m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("{322E919B-1541-434F-BCB2-01917F77EDF6}", "Quaker Instant Oatmeal", 11.35m, ItemType.Food), 1);

            order.SelectedPayments.Add(new Payment
            {
                PaymentProvider = PaymentProvider.Invoice
            });

            Console.WriteLine($"Tax: {order.GetTax()}");
            order.FinalizeOrder();

            Console.ReadKey();
        }

        private static string GetState(int state)
        {
            switch (state)
            {
                case 1: return "ca";
                case 2: return "il";
                case 3: return "ny";
                default: throw new Exception("Unsupported state selection");
            }
        }

        private static IInvoiceStrategy GetInvoiceStrategyFor(int option)
        {
            switch (option)
            {
                case 1: return new EmailInvoiceStrategy();
                case 2: return new FileInvoiceStrategy();
                case 3: return new PrintOnDemandInvoiceStrategy();
                default: throw new Exception("Unsupported invoice delivery option");
            }
        }

        private static IShippingStrategy GetShippingStrategyFor(int provider)
        {
            switch (provider)
            {
                case 1: return new UpsShippingStrategy();
                case 2: return new FedexShippingStrategy();
                case 3: return new PostNordShippingStrategy();
                default: throw new Exception("Unsupported shipping method");
            }
        }

        private static ISalesTaxStrategy GetSalesTaxStrategyFor(string origin)
        {
            if (string.Equals(origin, "sweden", StringComparison.OrdinalIgnoreCase))
            {
                return new SwedenSalesTaxStrategy();
            }
            else if (string.Equals(origin, "usa", StringComparison.OrdinalIgnoreCase))
            {
                return new USAStateSalesTaxStrategy();
            }
            else
            {
                throw new Exception("Unsupported shipping region");
            }
        }
    }
}