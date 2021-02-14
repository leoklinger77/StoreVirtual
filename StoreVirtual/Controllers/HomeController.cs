﻿using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Data;
using StoreVirtual.Models;
using StoreVirtual.Service.Email;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StoreVirtual.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreVirtualContext _context;

        public HomeController(StoreVirtualContext context)
        {
            _context = context;
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
                _context.NewsLetterEmail.Add(newsLetterEmail);
                _context.SaveChanges();

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
                    SendEmail.EnviarContatoEmail(contato);
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
                return View(nameof(Contato),contato);

            }
            catch (Exception)
            {
                TempData["MSG_E"] = "Algo inesperado aconteceu, mensagem não enviada!";

                //TODO Implementa Log

                return RedirectToAction(nameof(Contato));
            }


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
