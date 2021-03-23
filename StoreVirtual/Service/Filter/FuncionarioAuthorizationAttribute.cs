using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StoreVirtual.Service.Login;
using System;

namespace StoreVirtual.Service.Filter
{
    public class FuncionarioAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private string _tipoColaboradorAuthorization;
        public FuncionarioAuthorizationAttribute(string TipoColaboradorAuthorization = "C")
        {
            _tipoColaboradorAuthorization = TipoColaboradorAuthorization;
        }
        private LoginFuncionario _loginFuncionario;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginFuncionario = (LoginFuncionario)context.HttpContext.RequestServices.GetService(typeof(LoginFuncionario));
            if (_loginFuncionario.GetCliente() == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            else
            {
                if (_loginFuncionario.GetCliente().Tipo == "C" && _tipoColaboradorAuthorization == "G")
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }
}
