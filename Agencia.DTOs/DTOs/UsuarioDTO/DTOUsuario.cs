using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;

namespace Agencia.DTOs.DTOs.UsuarioDTO;

public class DTOUsuario
{
    public int? Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string Rol { get; set; }

    public bool Activo {  get; set; }

    public int? LogueadoId { get; set; }
}