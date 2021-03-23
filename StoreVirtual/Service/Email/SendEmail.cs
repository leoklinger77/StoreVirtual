using Microsoft.Extensions.Configuration;
using StoreVirtual.Models;
using System.Net.Mail;

namespace StoreVirtual.Service.Email
{
    public class SendEmail
    {

        private readonly SmtpClient _smtp;
        private readonly IConfiguration _configuration;

        public SendEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public void EnviarContatoEmail(Contato contato)
        {

            string corpMsg = string.Format("<h2>Contato Loja Virtual</h2>" +
                "<b>Nome: </b> {0} <br/>" +
                "<b>Email</b> {1} <br/>" +
                "<b>Texto</b> {2} <br/>" +
                "<p>E-mail enviado automaticamente do site Loja Virtual</p>",contato.Name,contato.Email,contato.Texto);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            message.To.Add(contato.Email);
            message.Subject = "Contato - Loja Virtual";
            message.Body = corpMsg;
            message.IsBodyHtml = true; //True caso vc queira que o body seja enviado html

            _smtp.Send(message);
        }

        public void EnviarSenha(Funcionario funcionario)
        {
            string corpMsg = string.Format("<h2>Contato Loja Virtual</h2>" +
                "<b>Sua senha é : </b><br/>" +
                "<h3>{0}</h3>  <br/>" +                
                "<p>E-mail enviado automaticamente do site Loja Virtual</p>", funcionario.Senha);

            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("Email:UserName"));
            message.To.Add(funcionario.Email);
            message.Subject = "Contato - Loja Virtual";
            message.Body = corpMsg;
            message.IsBodyHtml = true; //True caso vc queira que o body seja enviado html

            _smtp.Send(message);
        }
    }
}
