using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace ConsoleMailKit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SendEmail("melis99mrx@gmail.com", "Salam", "Hello bro, where are you from?").GetAwaiter().GetResult();
        }

        public static async Task SendEmail(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("АДМИНИСТРАЦИЯ SALYK.KG", "noreply@it.salyk.kg"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 465, true);
                //await client.ConnectAsync("smtp.gmail.com", 465, true);
                await client.AuthenticateAsync("noreply@it.salyk.kg", "jG1xB0bZ9sP7uH9f");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}