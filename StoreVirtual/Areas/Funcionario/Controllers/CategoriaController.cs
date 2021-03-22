using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Models;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Filter;
using System.Collections.Generic;

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

        public IActionResult Index()
        {
            ICollection<Categoria> list = _categoriaRepository.FindAlls();
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Categoria categoria)
        {
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
