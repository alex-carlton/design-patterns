using StrategyPattern.Business.Models;
using System.Net;
using System.Net.Mail;

namespace StrategyPattern.Business.Strategies.Invoice
{
    public class EmailInvoiceStrategy : InvoiceStrategy
    {
        public override void Generate(Order order)
        {
            var body = GenerateTextInvoice(order);

            using (SmtpClient client = new SmtpClient("test.testing.net", 587))
            {
                client.Credentials = new NetworkCredential("userName", "password");

                MailMessage mail = new MailMessage("from@mail.net", "to@mail.net")
                {
                    Subject = "Hello Friend",
                    Body = body
                };

                client.Send(mail);
            }
        }
    }
}