using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Email;
using StoreVirtual.Service.Filter;
using StoreVirtual.Service.KeyGenerator;
using StoreVirtual.Service.Lang;
using X.PagedList;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    [Area("Funcionario")]
    [FuncionarioAuthorization("G")]
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly SendEmail _sendEmail;

        public FuncionarioController(IFuncionarioRepository funcionarioRepository, SendEmail sendEmail)
        {
            _funcionarioRepository = funcionarioRepository;
            _sendEmail = sendEmail;
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
            
            ModelState.Remove("Senha");
            ModelState.Remove("ConfirmarSenha");
            if (ModelState.IsValid)
            {
                funcionario.Tipo = "C";
                funcionario.Senha = KeyGenerator.GetUniqueKey(6);
                _funcionarioRepository.Insert(funcionario);
                _sendEmail.EnviarSenha(funcionario);
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
            _funcionarioRepository.UpdateSenha(func);
            _sendEmail.EnviarSenha(func);
            TempData["MSG_S"] = Message.MSG_S009;
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
            ModelState.Remove("Senha");
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
