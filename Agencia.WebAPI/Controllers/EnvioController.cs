using System.Security.Claims;
using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.LogicaAplicacion.CasosUso.CUEnvio;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agencia.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        public ICUObtenerEnvioNroTracking _cUObtenerEnvioNroTracking;

        public EnvioController(ICUObtenerEnvioNroTracking cUObtenerEnvioNroTracking)
        {
            _cUObtenerEnvioNroTracking = cUObtenerEnvioNroTracking;
        }


        [HttpGet("{nroTracking}")]
        public IActionResult GetByNroTracking(string nroTracking)
        {
            try
            {
                DTOEnvio dto = _cUObtenerEnvioNroTracking.obtenerEnviosPorNroTracking(nroTracking);
                return Ok(dto);
            }
            catch (EnvioNoEncontradoException e)
            {
                {
                    return NotFound(e.Message);
                }
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