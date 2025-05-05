using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaEnviosWebApp.Filtros
{
    public class FuncionarioAuthorize : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = context.HttpContext.Session.GetString("LogueadoRol");
            if (userRole != "Funcionario")
            {
                // Si no hay un rol de administrador, redirige al login o muestra un error
                context.Result = new RedirectToActionResult("AccesoDenegado", "Usuario", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
