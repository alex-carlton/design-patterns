using StrategyPattern.Business.Models.Enums;
using StrategyPattern.Business.Strategies;
using StrategyPattern.Business.Strategies.Invoice;
using StrategyPattern.Business.Strategies.Shipping;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StrategyPattern.Business.Models
{
    public class Order
    {
        public Dictionary<Item, int> LineItems { get; } = new Dictionary<Item, int>();

        public IList<Payment> SelectedPayments { get; } = new List<Payment>();

        public IList<Payment> FinalizedPayments { get; } = new List<Payment>();

        public decimal AmountDue => TotalPrice - FinalizedPayments.Sum(payment => payment.Amount);

        public decimal TotalPrice => LineItems.Sum(item => item.Key.Price * item.Value);

        public ShippingStatus ShippingStatus { get; set; }

        public ShippingDetails ShippingDetails { get; set; }

        public ISalesTaxStrategy SalesTaxStrategy { get; set; }

        public IInvoiceStrategy InvoiceStrategy { get; set; }

        public IShippingStrategy ShippingStrategy { get; set; }

        public decimal GetTax()
        {
            if (SalesTaxStrategy == null)
            {
                return 0m;
            }

            return SalesTaxStrategy.GetTaxFor(this);
        }

        public void FinalizeOrder()
        {
            if (SelectedPayments
                .Any(x => x.PaymentProvider == PaymentProvider.Invoice) && AmountDue > 0 && ShippingStatus == ShippingStatus.WaitingForPayment)
            {
                InvoiceStrategy.Generate(this);

                ShippingStatus = ShippingStatus.ReadyForShippment;
            }
            else if (AmountDue > 0)
            {
                throw new Exception("Unable to finalize order");
            }

            ShippingStrategy.Ship(this);
        }
    }
}