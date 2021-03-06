﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Email;
using StoreVirtual.Service.Filter;
using StoreVirtual.Service.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClienteRepository _cliente;
        private readonly INewsLetterEmailRepository _newsLetter;
        private readonly LoginCliente _loginCliente;
        private readonly SendEmail _sendEmail;

        public HomeController(IClienteRepository cliente, INewsLetterEmailRepository newsLetter, LoginCliente loginCliente, SendEmail sendEmail)
        {
            _cliente = cliente;
            _newsLetter = newsLetter;
            _loginCliente = loginCliente;
            _sendEmail = sendEmail;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(NewsLetterEmail newsLetterEmail)
        {
            if (ModelState.IsValid)
            {
                _newsLetter.Insert(newsLetterEmail);

                TempData["MSG_S"] = "E-mail Cadastrado! Agora você ira receber promoções no seu e-mail!";

                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index), newsLetterEmail);
        }

        [HttpGet]
        public IActionResult Contato()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ContatoAcao()
        {
            try
            {
                Contato contato = new Contato();
                contato.Name = HttpContext.Request.Form["nome"];
                contato.Email = HttpContext.Request.Form["email"];
                contato.Texto = HttpContext.Request.Form["texto"];

                var ListMsg = new List<ValidationResult>();
                var contexto = new ValidationContext(contato);

                bool isValid = Validator.TryValidateObject(contato, contexto, ListMsg, true);

                if (isValid)
                {
                    _sendEmail.EnviarContatoEmail(contato);
                    TempData["MSG_S"] = "Mensagem de contato enviado com sucesso!";
                    return RedirectToAction(nameof(Contato));
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in ListMsg)
                    {
                        sb.Append(item.ErrorMessage + "<br/>");
                    }

                    TempData["MSG_E"] = sb.ToString();
                }
                return View(nameof(Contato), contato);

            }
            catch (Exception)
            {
                TempData["MSG_E"] = "Algo inesperado aconteceu, mensagem não enviada!";

                //TODO Implementa Log

                return RedirectToAction(nameof(Contato));
            }


        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Cliente cliente)
        {
            Cliente clienteDb = _cliente.Login(cliente.Email, cliente.Senha);
            if (clienteDb != null)
            {
                _loginCliente.SetCliente(clienteDb);
                return RedirectToAction(nameof(Painel));
            }
            TempData["MSG_E"] = "Verifique o Email ou a Senha";
            return View(cliente);
        }

        [HttpGet]
        [ClientAuthorization]
        public IActionResult Painel()
        {

            return new ContentResult() { Content = "Est é o painel" };


        }
        public IActionResult CadastroCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastroCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _cliente.Insert(cliente);
                TempData["MSG_S"] = "Cadastro realizado com sucesso!";
                return RedirectToAction(nameof(CadastroCliente));
            }
            return View(nameof(CadastroCliente), cliente);
        }
        public IActionResult CarrinhoCompras()
        {
            return View();
        }
    }
}
