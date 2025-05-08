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

    public static DTOMostrarEnvio ToDtoMostrarEnvio(Envio eBuscado)
    {
        DTOMostrarEnvio dto = new DTOMostrarEnvio();
        dto.Id = eBuscado.Id;
        dto.NroTracking = eBuscado._nroTracking;
        dto.Empleado = eBuscado._empleado;
        dto.Cliente = eBuscado._cliente;
        dto.Peso = eBuscado._peso;
        dto.Estado = eBuscado._estado.ToString();
        dto.UltimoComentario = eBuscado._seguimiento[eBuscado._seguimiento.Count - 1]._descripcion;
        dto.FechaInicio = eBuscado._fechaInicio;
        dto.FechaEntrega = eBuscado._fechaEntrega;
        dto.AgenciaOrigen = eBuscado._agenciaOrigen;

        if (eBuscado.GetType() == typeof(EnvioComun))
        {
            dto.Destino = ((EnvioComun)eBuscado)._destino;
        }
        else if (eBuscado.GetType() == typeof(EnvioUrgente))
        {
            var envioUrgente = (EnvioUrgente)eBuscado;
            dto.DireccionDestino = envioUrgente._direccionDestino;
            dto.EntregaEficiente = envioUrgente._entregaEficiente;
        }

        return dto;
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