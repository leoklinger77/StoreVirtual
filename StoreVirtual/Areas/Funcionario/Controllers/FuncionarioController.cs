using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    public class FuncionarioController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Models.Funcionario funcionario)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(Models.Funcionario funcionario, int id)
        {
            return View();
        }
    }
}
