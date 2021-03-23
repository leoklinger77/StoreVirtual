using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.KeyGenerator;
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
        public IActionResult ResetPassword(int id)
        {
            Models.Funcionario func = _funcionarioRepository.FindById(id);
            func.Senha = KeyGenerator.GetUniqueKey(6);
            _funcionarioRepository.Update(func);
            TempData["MSG_S"] = "Senha alterado com sucesso";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Models.Funcionario model = _funcionarioRepository.FindById(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Models.Funcionario funcionario, int id)
        {
            ModelState.Remove("ConfirmarSenha");
            if (ModelState.IsValid)
            {
                _funcionarioRepository.Update(funcionario);
                TempData["MSG_S"] = Message.MSG_S007;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            _funcionarioRepository.Delete(id);
            TempData["MSG_S"] = Message.MSG_S008;
            return RedirectToAction(nameof(Index));
        }
    }
}
