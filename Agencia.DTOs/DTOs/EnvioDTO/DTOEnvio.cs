using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;

namespace Agencia.DTOs.DTOs.EnvioDTO;

public class DTOEnvio
{ 
        public int? Id { get; set; }
        public int? NumeroTracking { get; set; }
        public NombreCompleto? NombreCliente { get; set; }
        public NombreCompleto? NombreEmpleado { get; set; }
        public double? Peso { get; set; }
        public string? TipoEnvio { get; set; }
        public EstadoEnvio? Estado { get; set; }
        public List<Comentario>? Comentarios { get; set; }
}