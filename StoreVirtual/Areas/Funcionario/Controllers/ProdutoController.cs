using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    [Area("Funcionario")]
    public class ProdutoController : Controller
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        
        public IActionResult Index(int?page, string search)
        {
            IPagedList<Produto> list = _produtoRepository.FindAlls(page, search);
            return View(list);
        }
    }
}
