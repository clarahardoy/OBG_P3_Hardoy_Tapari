using Agencia.DTOs.DTOs.AgenciaDTO;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaNegocio.Entidades;

namespace Agencia.DTOs.Mappers;

public class MapperSucursal
{
    public static List<DTOSucursal> FromListSucursalesToListDTO(List<Sucursal> sucursales)
    {
        List<DTOSucursal> ret = new List<DTOSucursal>();

        foreach (Sucursal sucursal in sucursales)
        {
            ret.Add(FromSucursalToDTO(sucursal));
        }
        return ret;
    }

    public static DTOSucursal FromSucursalToDTO(Sucursal sucursal)
    {
        DTOSucursal dto = new DTOSucursal();
        dto.Id = sucursal.Id;
        dto.Nombre = sucursal.Nombre;
        dto.DireccionPostal = sucursal.DireccionPostal;
        dto.LongitudUbicacion = sucursal.Ubicacion.Longitud.ToString();
        dto.LatitudUbicacion = sucursal.Ubicacion.Latitud.ToString();
        return dto;
    }
}