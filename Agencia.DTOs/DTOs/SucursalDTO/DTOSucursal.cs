using Agencia.LogicaNegocio.VO.AgenciaVO;

namespace Agencia.DTOs.DTOs.AgenciaDTO;

public class DTOSucursal
{
   public int? Id { get; set; }
   public string? Nombre { get; set; }
   public int? DireccionPostal  { get; set; }
   public Ubicacion? Ubicacion { get; set; }
}