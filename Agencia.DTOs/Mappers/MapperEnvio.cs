using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.LogicaNegocio.Entidades;

namespace Agencia.DTOs.Mappers;

public class MapperEnvio
{
    public static List<DTOEnvio> FromListEnvioToListDto(List<Envio> envios)
    {
        List<DTOEnvio> ret = new List<DTOEnvio>();

        foreach (Envio env in envios)
        {
            DTOEnvio dto = new DTOEnvio();
            dto.Id = env.Id;
            dto.NumeroTracking = env._nroTracking;
            dto.NombreCliente = env._cliente?._nombreCompleto;
            dto.NombreEmpleado = env._empleado?._nombreCompleto;
            dto.Peso = env._peso;
            dto.TipoEnvio = env.GetType().ToString();
            dto.Estado = env._estado; 
            ret.Add(dto);
        }
        return ret;
    }
}