using Nebulosa.Facturacion.Compartida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Nebulosa.Facturacion.Compartida.Helper
{
    public static class MailHelper
    {
        public static async Task SendMail(MailDTO mail, string fromPassword)
        {

            var fromAddress = new MailAddress("nebulosaretail@gmail.com", "Nebulosa");
            var toAddress = new MailAddress(mail.Address, mail.Name);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = mail.Subject,
                Body = mail.Body,
            })
            {
                smtp.Send(message);
            }
        }
    }
}
