using System.ComponentModel.DataAnnotations;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;

namespace Agencia.DTOs.DTOs.UsuarioDTO;

public class DTOAltaUsuario
{
    [Required]
    public string Nombre { get; set; }
    [Required]
    public string Apellido { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(32, MinimumLength = 8, ErrorMessage = "La longitud debe estar entre 8 y 32 caracteres")]
    public string Password { get; set; }

    public RolUsuario Rol { get; set; }
    
    public int? LogueadoId { get; set; }
    
    public DTOAltaUsuario(string nombre, string apellido, string email, string password, RolUsuario rol)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Password = password;
        Rol = rol;
    }

    public DTOAltaUsuario(){ }
}