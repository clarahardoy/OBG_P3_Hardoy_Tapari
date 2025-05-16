using Agencia.DTOs.DTOs.ComentarioDTO;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Agencia.LogicaNegocio.VO.EnvioVO;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Agencia.DTOs.DTOs.EnvioDTO;

public class DTOEnvio
{
    [JsonIgnore]
    public int Id { get; set; }

    [JsonIgnore]
    public int? LogueadoId { get; set; }

    [Display(Name = "")]
    public string? TipoEnvio { get; set; }

    [Display(Name = "Nro Tracking")]
    public string? NumeroTracking { get; set; }

    [Display(Name = "Cliente")]
    public string NombreCliente { get; set; }

    [Display(Name = "Empelado")]
    public string NombreEmpleado { get; set; }

    public double? Peso { get; set; }

    public string Estado { get; set; }

    public List<DTOComentario>? Seguimiento { get; set; }

    public DateTime? FechaInicio { get; set; }
    
    public DateTime? FechaEntrega { get; set; }

    public string AgenciaOrigen { get; set; }

    //Común :
    public string? Destino { get; set; }

    // Envío urgente : 
    [Display(Name = "Calle")]
    public string? CalleDireccion { get; set; }

    [Display(Name = "Ciudad")]
    public string? CiudadDireccion { get; set; }

    [Display(Name = "Departamento")]
    public string? DepartamentoDireccion { get; set; }

    [Display(Name = "Código postal")]
    public string? CodigoPostalDireccion { get; set; }
}