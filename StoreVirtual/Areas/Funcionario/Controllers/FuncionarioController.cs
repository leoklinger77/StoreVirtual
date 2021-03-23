using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Lang;
using X.PagedList;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    [Area("Funcionario")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public IActionResult Index(int? page)
        {
            IPagedList<Models.Funcionario> list = _funcionarioRepository.FindAlls(page);
            return View(list);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Models.Funcionario funcionario)
        {
            funcionario.Tipo = "C";
            if (ModelState.IsValid)
            {
                _funcionarioRepository.Insert(funcionario);
                TempData["MSG_S"] = Message.MSG_S006;

                return RedirectToAction(nameof(Index));
            }
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
        [HttpGet]
        public IActionResult Remove(int id)
        {
            return View();
        }
    }
}
