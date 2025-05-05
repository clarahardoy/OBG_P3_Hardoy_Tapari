using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using AgenciaEnviosWebApp.Filtros;
using AgenciaEnviosWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgenciaEnviosWebApp.Controllers
{
    public class EnvioController : Controller
    {
        private ICUObtenerSucursales _cUObtenerSucursales;
        private ICUObtenerEnviosEnProceso _cUObtenerEnviosEnProceso;
        private ICUAltaEnvio _cUAltaEnvio;

        public EnvioController(ICUObtenerSucursales cUObtenerSucursales,
                               ICUAltaEnvio cUAltaEnvio,
                               ICUObtenerEnviosEnProceso cUObtenerEnviosEnProceso)
        {
            _cUObtenerSucursales = cUObtenerSucursales;
            _cUAltaEnvio = cUAltaEnvio;
            _cUObtenerEnviosEnProceso = cUObtenerEnviosEnProceso;
        }

        [LogueadoAuthorize]
        public IActionResult Index()
        {
            return View(_cUObtenerEnviosEnProceso.ObtenerEnviosEnProceso());
        }

        [LogueadoAuthorize]
        public IActionResult Create()
        {
            AltaEnvioViewModel vm = new AltaEnvioViewModel();
            
            foreach (var agencia in _cUObtenerSucursales.ListarSucursales()) {
                SelectListItem sItem = new SelectListItem();
                sItem.Text = agencia.Nombre;
                sItem.Value = agencia.Id.ToString();
                vm.AgenciasDisponibles.Add(sItem);
            }

            return View(vm);
        }

        [LogueadoAuthorize]
        [HttpPost]
        public IActionResult Create(AltaEnvioViewModel vm)
        {
            try
            {
                vm.Dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                _cUAltaEnvio.AltaEnvio(vm.Dto);
                ViewBag.successMessage = "Envío creado con éxito.";
            }
            catch (EmailNoValidoException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (Exception e)
            {
                ViewBag.Mensaje = e.Message;
            }
                        
            return View();
        }
    }
}
