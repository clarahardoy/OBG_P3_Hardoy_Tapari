using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Agencia.WebAPI.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ICULogin _cuLogin;

        public AuthController(ICULogin cuLogin)
        {
            _cuLogin = cuLogin;
        }

        //LOG IN 
        [HttpPost("login")]
        public IActionResult Login([FromBody] DTOLogin dto)
        {
            try
            {
                DTOUsuario dtoUsuarioALoggear = new DTOUsuario();
                dtoUsuarioALoggear.Email = dto.Email;
                dtoUsuarioALoggear.Password = dto.Password;

                DTOUsuario usuario = _cuLogin.VerificarDatosParaLogin(dtoUsuarioALoggear);

                var clave =
                    "UTzl^7yPl$5xrT6&{7RZCSG&O42MEK89$CW1XXRrN(>XqIp{W4s2S5$>KT$6CG!2M]'ZlrqH-t%eI4.X9W~u#qO+oX£+[?7QDAa";
                var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));

                List<Claim> claims =
                [
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Rol),
                ];

                var credenciales = new SigningCredentials(claveCodificada, SecurityAlgorithms.HmacSha512Signature);

                var TOKEN = new JwtSecurityToken(claims: claims, signingCredentials: credenciales,
                    expires: DateTime.Now.AddDays(1));
                var jwt = new JwtSecurityTokenHandler().WriteToken(TOKEN);

                return Ok(new { token = jwt });
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
    }