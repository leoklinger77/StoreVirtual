using StoreVirtual.Models;
using System.Net;
using System.Net.Mail;

namespace StoreVirtual.Service.Email
{
    public class SendEmail
    {
        public static void EnviarContatoEmail(Contato contato)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("noreply.leandroklinger@gmail.com", "!@#LEO!@#klinger");
            smtp.EnableSsl = true;

            string corpMsg = string.Format("<h2>Contato Loja Virtual</h2>" +
                "<b>Nome: </b> {0} <br/>" +
                "<b>Email</b> {1} <br/>" +
                "<b>Texto</b> {2} <br/>" +
                "<p>E-mail enviado automaticamente do site Loja Virtual</p>",contato.Name,contato.Email,contato.Texto);

            MailMessage message = new MailMessage();
            message.From = new MailAddress("noreply.leandroklinger@gmail.com");
            message.To.Add(contato.Email);
            message.Subject = "Contato - Loja Virtual";
            message.Body = corpMsg;
            message.IsBodyHtml = true; //True caso vc queira que o body seja enviado html

            smtp.Send(message);
        }
    }
}
