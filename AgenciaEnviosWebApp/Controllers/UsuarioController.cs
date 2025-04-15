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
    private ICUObtenerUsuario _CUObtenerUsuario;
    private ICUEliminarFuncionario _CUEliminarFuncionario;

    public UsuarioController(ICUAltaUsuario CUAltaEmpleado,
                             ICULogin CUlogin,
                             ICUObtenerFuncionarios CUObtenerFuncionarios,
                             ICUActualizarFuncionario cUActualizarFuncionario,
                             ICUObtenerUsuario cUObtenerUsuario,
                             ICUEliminarFuncionario cUEliminarFuncionario)
    {
        _CUAltaEmpleado = CUAltaEmpleado;
        _CULogin = CUlogin;
        _CUObtenerFuncionarios = CUObtenerFuncionarios;
        _CUActualizarFuncionario = cUActualizarFuncionario;
        _CUObtenerUsuario = cUObtenerUsuario;
        _CUEliminarFuncionario = cUEliminarFuncionario;
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
            //int? logueadoId = HttpContext.Session.GetInt32("LogueadoId");
            int? logueadoId = 2;
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
            HttpContext.Session.SetString("LogueadoRol", b.Rol.ToString());
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
    public IActionResult Edit(int id)
    {
        //salir a buscar el genero con este id
        DTOUsuario model = _CUObtenerUsuario.ObtenerUsuario(id);
        return View(model);
    }
    [HttpPost]
    public IActionResult Edit(DTOUsuario dto)
    {
        try
        {
            //dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
            dto.LogueadoId = 2;
            _CUActualizarFuncionario.ActualizarFuncionario(dto);
            ViewBag.successMessage = "Usuario actualizado con éxito.";
        }
        catch (Exception e)
        {
            ViewBag.Mensaje = e.Message;
        }
        return View();
    }

    public IActionResult Delete(int id)
    {
        //salir a buscar el genero con este id
        DTOUsuario model = _CUObtenerUsuario.ObtenerUsuario(id);
        return View(model);
    }
    [HttpPost]
    public IActionResult Delete(DTOUsuario dto)
    {
        try
        {
            //dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
            dto.LogueadoId = 2;
            _CUEliminarFuncionario.EliminarFuncionario(dto);
            ViewBag.successMessage = "Usuario eliminado con éxito.";
        }
        catch (Exception e)
        {
            ViewBag.Mensaje = e.Message;
        }
        return View();
    }
}