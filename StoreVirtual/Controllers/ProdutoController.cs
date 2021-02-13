using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreVirtual.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Visualizar()
        {
            Produto view = GetProduto();
            return View(view);
        }

        private Produto GetProduto()
        {
            return new Produto
            {
                Id = 1,
                Descricao = "Descricao",
                Nome = "Nome",
                Valor = 25.50M
            };
        }
    }
}
