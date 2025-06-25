using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Agencia.WebAPI.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private ICULogin _cuLogin;
        private readonly IConfiguration _config; // acceso a JwtKey en appsettings

        public AuthController(ICULogin cuLogin, 
                              IConfiguration config)
        {
            _cuLogin = cuLogin;
            _config = config;
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

                if(usuario.Rol != "Cliente")
                    throw new AccesoDenegadoException("Acceso denegado. Solo los clientes pueden iniciar sesión.");

                string clave = _config["JwtKey"];
                var claveCodificada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clave));

                List<Claim> claims =
                [
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Rol),
                ];

                var credenciales = new SigningCredentials(claveCodificada, SecurityAlgorithms.HmacSha512Signature);

                var TOKEN = new JwtSecurityToken(
                    claims: claims, 
                    signingCredentials: credenciales,
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