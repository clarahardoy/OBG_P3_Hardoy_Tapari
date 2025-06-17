using System.Security.Claims;
using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.LogicaAplicacion.CasosUso.CUEnvio;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agencia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        public ICUObtenerEnvioNroTracking _cUObtenerEnvioNroTracking;
        public ICUObtenerEnviosDeClienteOrdFecha _cUObtenerEnviosDeClienteOrdFecha;
        public ICUObtenerEnviosPorFechasDeCliente _cUObtenerEnviosPorFechaDeCliente;

        public EnvioController(ICUObtenerEnvioNroTracking cUObtenerEnvioNroTracking,
                               ICUObtenerEnviosDeClienteOrdFecha cUObtenerEnviosDeClienteOrdFecha,
                               ICUObtenerEnviosPorFechasDeCliente cUObtenerEnviosPorFechaDeCliente)
        {
            _cUObtenerEnvioNroTracking = cUObtenerEnvioNroTracking;
            _cUObtenerEnviosDeClienteOrdFecha = cUObtenerEnviosDeClienteOrdFecha;
            _cUObtenerEnviosPorFechaDeCliente = cUObtenerEnviosPorFechaDeCliente;
        }

        [HttpGet]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetAll()
        {
            string EmailLogueado = EmailDelUsuario();
            if (EmailLogueado == null)
            {
                return Unauthorized();
            }
            try
            {
                List<DTOEnvio> ret = _cUObtenerEnviosDeClienteOrdFecha.Ejecutar(EmailLogueado);
                return Ok(ret);
            }
            catch (NoHayEnviosException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error inesperado, intente más tarde.");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Cliente")]
        public IActionResult GetByFechas(DateTime f1, DateTime f2)
        {
            string EmailLogueado = EmailDelUsuario();
            if (EmailLogueado == null)
            {
                return Unauthorized();
            }
            if (f1 == null || f2 == null)
            {
                return BadRequest("Las fechas no pueden ser nulas.");
            }
            try
            {
                List<DTOEnvio> ret = _cUObtenerEnviosPorFechaDeCliente.Ejecutar(EmailLogueado, f1, f2);
                return Ok(ret);
            }
            catch (NoHayEnviosException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error inesperado, intente más tarde.");
            }
        }

        [HttpGet("{nroTracking}")]
        public IActionResult GetByNroTracking(string nroTracking)
        {
            try
            {
                DTOEnvio dto = _cUObtenerEnvioNroTracking.Ejecutar(nroTracking);
                return Ok(dto);
            }
            catch (EnvioNoEncontradoException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error inesperado, intente más tarde.");
            }
        }

        private string EmailDelUsuario()
        {
            string email = null;
            //obtener mail del token
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var emailClaim = claimsIdentity.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                email = emailClaim.Value;
            }
            return email;
        }
    }
}