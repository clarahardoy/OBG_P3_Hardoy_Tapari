using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.CasosUso.CUUsuario;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Agencia.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private ICUActualizarContrasenia _cuActualizarContrasenia;
        public ClienteController(ICUActualizarContrasenia cuActualizarContrasenia)
        {
            _cuActualizarContrasenia = cuActualizarContrasenia;
        }

        [HttpPut("actualizar")]
        [Authorize(Roles = "Cliente")]
        public IActionResult UpdatePass([FromBody] DTOActualizarContrasenia dto)
        {
            string EmailLogueado = EmailUser();
            if (EmailLogueado == null)
            {
                return Unauthorized();
            }
            else
            {
                dto.Email = EmailLogueado;
            }

            try
            {
                _cuActualizarContrasenia.Ejecutar(dto);
                return Ok("Contraseña actualizada correctamente.");
            }
            catch (EmailNoValidoException e)
            {
                return NotFound(e.Message);
            }
            catch (ContraseniaIncorrectaException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error inesperado, intente más tarde.");
            }
        }

        private string EmailUser()
        {
            string email = null;
            // como obtener el email del token
            var claimsIdentity = User.Identity as ClaimsIdentity;
            if (claimsIdentity != null)
            {
                var emailClaim = claimsIdentity.Claims
                .FirstOrDefault(claim => claim.Type == ClaimTypes.Email);
                email = emailClaim.Value;
            }
            return email;
        }
    }
}