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
        List<DTOComentario> dtoComentarios = MapperSeguimiento.ToListDtoComentario(eBuscado.Seguimiento);

        DTOEnvio dto = new DTOEnvio();
        dto.Id = eBuscado.Id;
        dto.NumeroTracking = eBuscado.NroTracking;
        dto.NombreCliente = eBuscado.Cliente.NombreCompleto.Nombre + " " + eBuscado.Cliente.NombreCompleto.Apellido;
        dto.NombreEmpleado = eBuscado.Empleado.NombreCompleto.Nombre + " " + eBuscado.Empleado.NombreCompleto.Apellido;
        dto.Peso = eBuscado.Peso;
        dto.Estado = eBuscado.Estado.ToString();
        dto.FechaInicio = eBuscado.FechaInicio;
        dto.FechaEntrega = eBuscado.FechaEntrega;
        dto.AgenciaOrigen = eBuscado.AgenciaOrigen.Nombre;
        dto.Seguimiento = dtoComentarios;

        if (eBuscado.GetType() == typeof(EnvioComun))
        {
            var envioComun = (EnvioComun)eBuscado;
            dto.Destino = envioComun.AgenciaDestino?.ToString();
            dto.TipoEnvio = "Común";
        }
        else if (eBuscado.GetType() == typeof(EnvioUrgente))
        {
            var envioUrgente = (EnvioUrgente)eBuscado;

            dto.CalleDireccion = envioUrgente.DireccionDestino.Calle;
            dto.CiudadDireccion = envioUrgente.DireccionDestino.Ciudad;
            dto.DepartamentoDireccion = envioUrgente.DireccionDestino.Departamento;
            dto.CodigoPostalDireccion = envioUrgente.DireccionDestino.CodigoPostal;
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