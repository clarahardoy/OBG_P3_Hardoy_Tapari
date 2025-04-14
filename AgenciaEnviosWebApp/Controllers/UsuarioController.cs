using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaEnviosWebApp.Controllers;

public class UsuarioController : Controller
{
    private ICUAltaUsuario _CUAltaEmpleado;
    private ICULogin _CULogin;
    private ICUObtenerFuncionarios _CUObtenerEmpleados;
    
    public UsuarioController(ICUAltaUsuario CUAltaEmpleado,ICULogin CUlogin)
    {
        _CUAltaEmpleado = CUAltaEmpleado;
        _CULogin = CUlogin;
    }
    public IActionResult Index()
    {
        return View();
    }

   // [LogueadoAuthorize]
   // [AdministradorAuthorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(DTOAltaUsuario dto)
    {
        try
        {
            int? logueadoId = HttpContext.Session.GetInt32("LogueadoId");
            dto.LogueadoId = logueadoId;

            _CUAltaEmpleado.AltaEmpleado(dto);
            ViewBag.msg = "Alta exitosa";
        }
        catch (Exception e)
        {
            ViewBag.msg = e.Message;
        }
        return View();
    }


    public IActionResult AccesoDenegado() { 
        return View();
    }


    public IActionResult Login() {
        return View();
    }

    [HttpPost]
    public IActionResult Login(DTOUsuario dto)
    {
        try
        {
            DTOUsuario b = _CULogin.VerificarDatosParaLogin(dto);
            HttpContext.Session.SetInt32("LogueadoId", (int)b.Id);
            HttpContext.Session.SetString("LogueadoRol", b.Rol);
        }
        catch (Exception e)
        {

            throw e;
        }
        return View();
    }

    public IActionResult ListEmpleados()
    {
        return View(_CUObtenerEmpleados.ListarEmpleados());
    }
}