using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace StoreVirtual.Service.Filter
{
    public class ValidationHttpRefererAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Executa antes de passar pelo controlador
            string refere = context.HttpContext.Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(refere))
            {
                context.Result = new ContentResult() { Content = "Acesso negado " };
            }
            else
            {
                Uri uri = new Uri(refere);
                string hostReferet = uri.Host;
                string hostServidor = context.HttpContext.Request.Host.Host;
                if (hostReferet != hostServidor)
                {
                    context.Result = new ContentResult() { Content = "Acesso negado " };
                }
            }           
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Executa após passar pelo controlador            
        }
    }
}
