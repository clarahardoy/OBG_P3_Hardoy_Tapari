using Agencia.LogicaNegocio.VO.AgenciaVO;
using System.ComponentModel.DataAnnotations;

namespace Agencia.DTOs.DTOs.AgenciaDTO;

public class DTOSucursal
{
    public int? Id { get; set; }
    public string? Nombre { get; set; }

    [Display(Name = "Direccion Postal")]
    public int? DireccionPostal { get; set; }

    [Display(Name = "Latitud")]
    public string LatitudUbicacion { get; set; }

    [Display(Name = "Longitud")]
    public string LongitudUbicacion { get; set; }

}