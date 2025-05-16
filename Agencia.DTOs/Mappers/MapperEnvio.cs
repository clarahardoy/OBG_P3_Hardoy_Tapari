using Agencia.DTOs.DTOs.ComentarioDTO;
using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.VO.EnvioVO;

namespace Agencia.DTOs.Mappers;

public class MapperEnvio
{
    public static List<DTOEnvio> FromListEnvioToListDto(List<Envio> envios)
    {
        List<DTOEnvio> ret = new List<DTOEnvio>();

        foreach (Envio envio in envios)
        {
            ret.Add(ToDtoEnvio(envio));
        }
        return ret;
    }

    public static DTOEnvio ToDtoEnvio(Envio eBuscado)
    {
        List<DTOComentario> dtoComentarios = MapperSeguimiento.ToListDtoComentario(eBuscado._seguimiento);

        DTOEnvio dto = new DTOEnvio();
        dto.Id = eBuscado.Id;
        dto.NumeroTracking = eBuscado._nroTracking;
        dto.NombreEmpleado = eBuscado._empleado._nombreCompleto._nombre + " " + eBuscado._empleado._nombreCompleto._apellido;
        dto.NombreCliente = eBuscado._cliente._nombreCompleto._nombre + " " + eBuscado._cliente._nombreCompleto._apellido;
        dto.Peso = eBuscado._peso;
        dto.Estado = eBuscado._estado.ToString();
        dto.FechaInicio = eBuscado._fechaInicio;
        dto.FechaEntrega = eBuscado._fechaEntrega;
        dto.AgenciaOrigen = eBuscado._agenciaOrigen._nombre;
        dto.Seguimiento = dtoComentarios;

        if (eBuscado.GetType() == typeof(EnvioComun))
        {
            var envioComun = (EnvioComun)eBuscado;
            dto.Destino = envioComun._destino?.ToString();
            dto.TipoEnvio = "Común";
        }
        else if (eBuscado.GetType() == typeof(EnvioUrgente))
        {
            var envioUrgente = (EnvioUrgente)eBuscado;

            dto.CalleDireccion = envioUrgente._direccionDestino._calle;
            dto.CiudadDireccion = envioUrgente._direccionDestino._ciudad;
            dto.DepartamentoDireccion = envioUrgente._direccionDestino._departamento;
            dto.CodigoPostalDireccion = envioUrgente._direccionDestino._codigoPostal;
            dto.TipoEnvio = "Urgente";
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