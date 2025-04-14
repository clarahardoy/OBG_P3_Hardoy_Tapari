using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AgenciaEnviosWebApp.Filtros
{
    public class AdministradorAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {   
            var userRole = context.HttpContext.Session.GetString("LogueadoRol");
            if (userRole != "Administrador")
            {
                // Si no hay un rol de administrador, redirige al login o muestra un error
                context.Result = new RedirectToActionResult("AccesoDenegado", "Usuario", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
