using Agencia.DTOs.DTOs.AgenciaDTO;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaNegocio.Entidades;

namespace Agencia.DTOs.Mappers;

public class MapperSucursal
{
    public static List<DTOSucursal> FromListSucursalesToListDTO(List<Sucursal> sucursales)
    {
        List<DTOSucursal> ret = new List<DTOSucursal>();

        foreach (Sucursal suc in sucursales)
        {
            DTOSucursal dto = new DTOSucursal();
            dto.Id = suc.Id;
            dto.Nombre = suc._nombre;
            dto.DireccionPostal = suc._direccionPostal;
            dto.Ubicacion = suc._ubicacion;
            
            ret.Add(dto);
        }
        return ret;
    }

    public static DTOSucursal FromSucursalToDTO(Sucursal sucursal)
    {
        DTOSucursal dto = new DTOSucursal();
        dto.Id = sucursal.Id;
        dto.Nombre = sucursal._nombre;
        dto.DireccionPostal = sucursal._direccionPostal;
        dto.Ubicacion = sucursal._ubicacion;
        return dto;
    }
}