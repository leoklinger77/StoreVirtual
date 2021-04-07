using Microsoft.AspNetCore.Mvc;
using StoreVirtual.Models;
using StoreVirtual.Models.Constants;
using StoreVirtual.Repositories.Interfaces;
using StoreVirtual.Service.Filter;
using StoreVirtual.Service.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace StoreVirtual.Areas.Funcionario.Controllers
{
    [Area("Funcionario")]
    [FuncionarioAuthorization]
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public IActionResult Index(int? page)
        {
            IPagedList<Cliente> clientes = _clienteRepository.FindAll(page);
            return View(clientes);
        }
        [ValidationHttpReferer]
        public IActionResult AtivarDesativar(int id)
        {
            Cliente cliente = _clienteRepository.FindById(id);
            cliente.Situacao = (cliente.Situacao == ClienteTypeConstant.Ativo) ? ClienteTypeConstant.Desativado : ClienteTypeConstant.Ativo;
            _clienteRepository.Update(cliente);

            TempData["MSG_S"] = Message.MSG_S007;

            return RedirectToAction(nameof(Index));
        }
    }
}
