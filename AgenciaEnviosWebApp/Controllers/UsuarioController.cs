using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaEnviosWebApp.Controllers;

public class UsuarioController : Controller
{
    private ICUAltaUsuario _CUAltaEmpleado;
    private ICULogin _CULogin;
    private ICUObtenerFuncionarios _CUObtenerFuncionarios;
    private ICUActualizarFuncionario _CUActualizarFuncionario;

    public UsuarioController(ICUAltaUsuario CUAltaEmpleado,
                             ICULogin CUlogin,
                             ICUObtenerFuncionarios CUObtenerFuncionarios,
                             ICUActualizarFuncionario cUActualizarFuncionario)
    {
        _CUAltaEmpleado = CUAltaEmpleado;
        _CULogin = CUlogin;
        _CUObtenerFuncionarios = CUObtenerFuncionarios;
        _CUActualizarFuncionario = cUActualizarFuncionario;
    }
    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home");
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
            ViewBag.successMessage = "Alta exitosa";
        }
        catch (Exception e)
        {
            ViewBag.Mensaje = e.Message;
        }
        return View();
    }

    public IActionResult AccesoDenegado()
    {
        return View();
    }

    public IActionResult Login()
    {
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
            ViewBag.Mensaje = e.Message;
        }
        return View();
    }

    public IActionResult ListFuncionarios()
    {
        return View(_CUObtenerFuncionarios.ListarFuncionarios());
    }
}