using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Lang;
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
        private readonly IProdutoRepository _produtoRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public ProdutoController(IProdutoRepository produtoRepository, ICategoriaRepository categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }
        
        public IActionResult Index(int?page, string search)
        {
            IPagedList<Produto> list = _produtoRepository.FindAlls(page, search);
            
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Categoria = _categoriaRepository.FindAlls().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Insert(produto);
                
                TempData["MSG_S"] = Message.MSG_S006;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categoria = _categoriaRepository.FindAlls().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Produto produto = _produtoRepository.FindById(id);
            ViewBag.Categoria = _categoriaRepository.FindAlls().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View(produto);
        }
        [HttpPost]
        public IActionResult Update(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.Update(produto);
                TempData["MSG_S"] = Message.MSG_S006;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categoria = _categoriaRepository.FindAlls().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View(produto);
        }

    }
}
