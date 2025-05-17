using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;
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
        private ICUObtenerEnvio _cUObtenerEnvio;
        private ICUFinalizarEnvio _cUFinalizarEnvio;
        private ICUAgregarSeguimiento _cuAgregarSeguimiento;

        public EnvioController(ICUObtenerSucursales cUObtenerSucursales,
            ICUAltaEnvio cUAltaEnvio,
            ICUObtenerEnviosEnProceso cUObtenerEnviosEnProceso,
            ICUObtenerEnvio cUObtenerEnvio,
            ICUFinalizarEnvio cUFinalizarEnvio,
            ICUAgregarSeguimiento cuAgregarSeguimiento)
        {
            _cUObtenerSucursales = cUObtenerSucursales;
            _cUAltaEnvio = cUAltaEnvio;
            _cUObtenerEnviosEnProceso = cUObtenerEnviosEnProceso;
            _cUObtenerEnvio = cUObtenerEnvio;
            _cUFinalizarEnvio = cUFinalizarEnvio;
            _cuAgregarSeguimiento = cuAgregarSeguimiento;
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

            foreach (var agencia in _cUObtenerSucursales.ListarSucursales())
            {
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
            foreach (var agencia in _cUObtenerSucursales.ListarSucursales())
            {
                SelectListItem sItem = new SelectListItem();
                sItem.Text = agencia.Nombre;
                sItem.Value = agencia.Id.ToString();
                vm.AgenciasDisponibles.Add(sItem);
            }

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

            return View(vm);
        }

        public IActionResult Delete(int id)
        {
            //salir a buscar el genero con este id
            DTOEnvio model = _cUObtenerEnvio.ObtenerEnvioPorId(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(DTOEnvio dto)
        {
            try
            {
                dto.LogueadoId = HttpContext.Session.GetInt32("LogueadoId");
                _cUFinalizarEnvio.FinalizarEnvio(dto);
                ViewBag.successMessage = "Envío finalizado con éxito.";
            }
            catch (EnvioYaFinalizadoException e)
            {
                ViewBag.Mensaje = e.Message;
            }
            catch (EnvioNoEncontradoException e1)
            {
                ViewBag.Mensaje = e1.Message;
            }
            catch (Exception e2)
            {
                ViewBag.Mensaje = e2.Message;
            }

            return View(dto);
        }

        public IActionResult AgregarSeguimiento(int idEnv)
        {
            AgregarSeguimientoModel vm = new AgregarSeguimientoModel();
            DTOEnvio envio = _cUObtenerEnvio.ObtenerEnvioPorId(idEnv);
            vm.dtoEnvio = envio;
            return View(vm);
        }

        [HttpPost]
        public IActionResult AgregarSeguimiento(AgregarSeguimientoModel vm)
        {
            try
            {

                DTOAgregarSeguimiento dto = new DTOAgregarSeguimiento();
                dto.idEnvio = vm.dtoEnvio.Id;
                dto.Seguimiento = vm.dtoAgregarSeguimiento.Seguimiento;
                dto.idLogueado = HttpContext.Session.GetInt32("LogueadoId");

                _cuAgregarSeguimiento.AgregarSeguimiento(dto);
                TempData["successMessage"] = "Seguimiento agregado correctamente";
            }
            catch (Exception e)
            {
                TempData["Mensaje"] = e.Message;
            }
            return RedirectToAction("Index");
        }
    }
}