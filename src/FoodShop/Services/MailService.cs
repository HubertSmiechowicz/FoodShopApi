using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using FoodShop.Entities;
using FoodShop.Exceptions;

namespace FoodShop.Services
{
    public class MailService
    {

        private readonly FoodShopDbContext _dbContext;

        public MailService(FoodShopDbContext dbContext) 
        {
            _dbContext = dbContext;
        }


        private string GetMailAdress()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Properties/mail.json");

            var configuration = builder.Build();
            return configuration["mail"];
        }

        private string GetMailPassword()
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Properties/mail.json");

            var configuration = builder.Build();
            return configuration["password"];
        }

        private void SentMail(string addresseeMail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(GetMailAdress()));
            email.To.Add(MailboxAddress.Parse(addresseeMail));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(GetMailAdress(), GetMailPassword());
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        public void SentEmailOrderPlaced(int orderId, string adresseeMail, string subject, string body)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) { throw new EntityNotFoundException("Order not found. Id: " + orderId, orderId); }
            if (order.OrderStatus != OrderStatus.ORDER_PLACED) { throw new OrderStatusNotChangedException("Operation of change order status fault."); }
            SentMail(adresseeMail, subject, body);
        }
    }
}
