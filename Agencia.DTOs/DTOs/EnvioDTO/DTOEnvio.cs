using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System.ComponentModel.DataAnnotations;

namespace Agencia.DTOs.DTOs.EnvioDTO;

public class DTOEnvio
{
    public int? Id { get; set; }
    [Display(Name = "Nro Tracking")]
    public string? NumeroTracking { get; set; }

    [Display(Name = "Cliente")]
    public NombreCompleto? NombreCliente { get; set; }

    [Display(Name = "Empelado")]
    public NombreCompleto? NombreEmpleado { get; set; }

    public double? Peso { get; set; }

    [Display(Name = "")]
    public string? TipoEnvio { get; set; }
    public EstadoEnvio? Estado { get; set; }
    public List<Comentario>? Seguimiento { get; set; }
}