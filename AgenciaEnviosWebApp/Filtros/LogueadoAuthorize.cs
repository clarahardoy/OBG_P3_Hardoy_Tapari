using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AgenciaEnviosWebApp.Filtros;

public class LogueadoAuthorize : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        int? usuarioLogueadoId = context.HttpContext.Session.GetInt32("LogueadoId");
        if (usuarioLogueadoId == null)
        {
            context.Result = new RedirectToActionResult("Login", "Usuario", null);
        }
    }
}