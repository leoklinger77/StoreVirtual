using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Filter;
using StoreVirtual.Service.Login;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    [Area("Funcionario")]
    public class HomeController : Controller
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly LoginFuncionario _loginFuncionario;

        public HomeController(IFuncionarioRepository funcionarioRepository, LoginFuncionario loginFuncionario)
        {
            _funcionarioRepository = funcionarioRepository;
            _loginFuncionario = loginFuncionario;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Models.Funcionario funcionario)
        {
            Models.Funcionario funcionarioDB = _funcionarioRepository.Login(funcionario.Email, funcionario.Senha);
            if (funcionarioDB != null)
            {
                _loginFuncionario.SetCliente(funcionarioDB);
                return RedirectToAction(nameof(Painel));
            }
            TempData["MSG_E"] = "Verifique o Email ou a Senha";
            return View(funcionario);
        }
        [HttpGet]
        [FuncionarioAuthorization]
        public IActionResult Forgot()
        {
            _loginFuncionario.Remove();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpGet]
        [FuncionarioAuthorization]
        public IActionResult Painel()
        {
            return View();
        }
    }
}
