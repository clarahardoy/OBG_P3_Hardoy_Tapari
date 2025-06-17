using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.CasosUso.CUUsuario;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using AgenciaEnviosWebApp.Filtros;
using Microsoft.AspNetCore.Mvc;

namespace AgenciaEnviosWebApp.Controllers;

public class UsuarioController : Controller
{
    private ICUActualizarFuncionario _CUActualizarFuncionario;
    private ICUAltaUsuario _CUAltaEmpleado;
    private ICUDesactivarFuncionario _CUDesactivarFuncionario;
    private ICULogin _CULogin;
    private ICUObtenerFuncionarios _CUObtenerFuncionarios;
    private ICUObtenerUsuario _CUObtenerUsuario;

    public UsuarioController(ICUActualizarFuncionario cUActualizarFuncionario,
                             ICUAltaUsuario CUAltaEmpleado,
                             ICUDesactivarFuncionario cUDesactivarFuncionario,
                             ICULogin CUlogin,
                             ICUObtenerFuncionarios CUObtenerFuncionarios,
                             ICUObtenerUsuario cUObtenerUsuario)
    {
        _CUActualizarFuncionario = cUActualizarFuncionario;
        _CUAltaEmpleado = CUAltaEmpleado;
        _CUDesactivarFuncionario = cUDesactivarFuncionario;
        _CULogin = CUlogin;
        _CUObtenerFuncionarios = CUObtenerFuncionarios;
        _CUObtenerUsuario = cUObtenerUsuario;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Index", "Home");
    }

    [LogueadoAuthorize]
    [AdministradorAuthorize]
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

            _CUAltaEmpleado.Ejecutar(dto);
            ViewBag.successMessage = "Usuario creado con éxito.";
        }
        catch (EmailYaExisteException e1)
        {
            ViewBag.Mensaje = e1.Message;
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
            HttpContext.Session.SetString("LogueadoRol", b.Rol.ToString());
            return RedirectToAction("Index", "Home");
        }
        catch (CredencialesInvalidasException ex)
        {
            TempData["Mensaje"] = ex.Message;
            return View(dto);
        }
        catch (UsuarioInactivoException ex)
        {
            TempData["Mensaje"] = ex.Message;
            return View(dto);
        }
        catch (AccesoDenegadoException)
        {
            return RedirectToAction("AccesoDenegado", "Usuario");
        }
        catch (Exception)
        {
            TempData["Mensaje"] = "Ocurrió un error inesperado.";
            return View(dto);
        }
    }

    public IActionResult Logout()
    {
        try
        {
            HttpContext.Session.Clear();
            TempData["successMessage"] = "Sesión cerrada.";
        }
        catch (Exception e)
        {
            ViewBag.Mensaje = e.Message;
        }
        return RedirectToAction("Login", "Usuario");
    }

    [LogueadoAuthorize]
    [AdministradorAuthorize]
    public IActionResult ListFuncionarios()
    {
        return View(_CUObtenerFuncionarios.Ejecutar());
    }

    [LogueadoAuthorize]
    [AdministradorAuthorize]
    public IActionResult Edit(int id)
    {
        //alir a buscar el Usuario con este id
        DTOActualizarFuncionario model = _CUObtenerUsuario.ObtenerFuncionario(id);
        return View(model);
    }
    [HttpPost]
    public IActionResult Edit(DTOActualizarFuncionario dto)
    {
        try
        {
            dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
            _CUActualizarFuncionario.Ejecutar(dto);
            ViewBag.successMessage = "Usuario actualizado con éxito.";
        }
        catch (Exception e)
        {
            ViewBag.Mensaje = e.Message;
        }
        return View();
    }

    [LogueadoAuthorize]
    [AdministradorAuthorize]
    public IActionResult Delete(int id)
    {
        //salir a buscar el genero con este id
        DTOUsuario model = _CUObtenerUsuario.Ejecutar(id);
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(DTOUsuario dto)
    {
        try
        {
            dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
            _CUDesactivarFuncionario.Ejecutar(dto);
            ViewBag.successMessage = "Usuario eliminado con éxito.";
        }
        catch (Exception e)
        {
            ViewBag.Mensaje = e.Message;
        }
        return View();
    }
}