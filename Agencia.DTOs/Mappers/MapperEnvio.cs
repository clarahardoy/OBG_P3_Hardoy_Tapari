using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.VO.EnvioVO;

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
            dto.Seguimiento = env._seguimiento;
            ret.Add(dto);
        }
        return ret;
    }

    public static Envio ToEnvio(DTOAltaEnvio dto, Sucursal agenciaDestino)
    {
        Envio envioNuevo;

        if (dto.TipoEnvio.Equals("urgente"))
        {
            envioNuevo = new EnvioUrgente(null, null, dto.Peso, null,
                                        new Direccion(dto.CalleDireccion, dto.CiudadDireccion, dto.DepartamentoDireccion,
                                        dto.CodigoPostalDireccion));
            return envioNuevo;
        }
        else
        {
            envioNuevo = new EnvioComun(null, null, dto.Peso, null, agenciaDestino);
            return envioNuevo;
        }
    }
}