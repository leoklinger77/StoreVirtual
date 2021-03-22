using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreVirtual.Service.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreVirtual.Service.Filter
{
    public class FuncionarioAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private LoginFuncionario _loginFuncionario;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginFuncionario = (LoginFuncionario)context.HttpContext.RequestServices.GetService(typeof(LoginFuncionario));
            if (_loginFuncionario.GetCliente() == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado" };
            }
        }
    }
}
