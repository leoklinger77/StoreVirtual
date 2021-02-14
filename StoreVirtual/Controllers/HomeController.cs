using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Models;
using StoreVirtual.Service.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreVirtual.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contato()
        {
            return View();
        }
        public IActionResult ContatoAcao()
        {
            Contato contato = new Contato();
            contato.Name = HttpContext.Request.Form["nome"];
            contato.Email = HttpContext.Request.Form["email"];
            contato.Texto= HttpContext.Request.Form["texto"];

            Service.Email.SendEmail.EnviarContatoEmail(contato);

            return new ContentResult()
            {
                Content = string.Format("Dados Recebidos com sucesso! <br/>" +
                "Nome:{0} <br/>" +
                "E-mail:{1} <br/>" +
                "texto:{2}", contato.Name, contato.Email, contato.Texto),
                ContentType = "text/html"
            };
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CadastroCliente()
        {
            return View();
        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
