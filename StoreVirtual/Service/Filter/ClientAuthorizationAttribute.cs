using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreVirtual.Service.Login;
using System;

namespace StoreVirtual.Service.Filter
{
    public class ClientAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private LoginCliente _loginCliente;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginCliente = (LoginCliente)context.HttpContext.RequestServices.GetService(typeof(LoginCliente));
            if (_loginCliente.GetCliente() == null)
            {
                context.Result = new ContentResult() { Content = "Acesso negado" };
            }
        }
    }
}
