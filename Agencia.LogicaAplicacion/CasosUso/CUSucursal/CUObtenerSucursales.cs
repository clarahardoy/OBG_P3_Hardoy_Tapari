using Agencia.DTOs.DTOs.AgenciaDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUAgencia;

public class CUObtenerSucursales : ICasosUso.ICUAgencia.ICUObtenerSucursales
{
    private IRepositorioSucursal _repoSucursal;
    
    public CUObtenerSucursales(IRepositorioSucursal repoSucursal)
    {
        _repoSucursal = repoSucursal;
    }
    
    public List<DTOSucursal> ListarSucursales()
    {
        List<Sucursal> listaSucursales = _repoSucursal.ListAllSucursales();
        List<DTOSucursal> sucursalesARetornar = MapperSucursal.FromListSucursalesToListDTO(listaSucursales);
        return sucursalesARetornar;

    }
}