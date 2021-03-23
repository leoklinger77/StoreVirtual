using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Filter;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    [Area("Funcionario")]
    [FuncionarioAuthorization]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index(int? page)
        {
            IPagedList<Categoria> list = _categoriaRepository.FindAlls(page);           
            
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            ViewBag.Categoria = _categoriaRepository.FindAlls().Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Insert(categoria);
                TempData["MSG_S"] = "Registro salvo com sucesso";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categoria = _categoriaRepository.FindAlls().Select(x=> new SelectListItem(x.Nome,x.Id.ToString()));
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Categoria categoria)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            return View();
        }
    }
}
