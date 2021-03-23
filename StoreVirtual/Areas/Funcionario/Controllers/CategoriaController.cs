using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Filter;
using StoreVirtual.Service.Lang;
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
                TempData["MSG_S"] = Message.MSG_S006;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categoria = _categoriaRepository.FindAlls().Select(x=> new SelectListItem(x.Nome,x.Id.ToString()));
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Categoria cat = _categoriaRepository.FindById(id);
            ViewBag.Categoria = _categoriaRepository.FindAlls().Where(x=>x.Id != id).Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View(cat);
        }
        [HttpPost]
        public IActionResult Update(Categoria categoria, int id)
        {
            if (ModelState.IsValid)
            {
                _categoriaRepository.Update(categoria);
                TempData["MSG_S"] = Message.MSG_S007;
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categoria = _categoriaRepository.FindAlls().Where(x => x.Id != id).Select(x => new SelectListItem(x.Nome, x.Id.ToString()));
            return View();
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            _categoriaRepository.Delete(id);
            TempData["MSG_S"] = Message.MSG_S008;
            return RedirectToAction(nameof(Index));
        }
    }
}
