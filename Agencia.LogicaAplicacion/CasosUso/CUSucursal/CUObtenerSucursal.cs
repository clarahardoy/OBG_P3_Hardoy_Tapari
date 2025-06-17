using Agencia.DTOs.DTOs.AgenciaDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUAgencia;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario;

public class CUObtenerSucursal : ICUObtenerSucursal
{
    private IRepositorioSucursal _repoSucursal;

    public CUObtenerSucursal(IRepositorioSucursal repoSucursal)
    {
        _repoSucursal = repoSucursal;
    }
    public DTOSucursal Ejecutar(int id)
    {
        Sucursal suc = _repoSucursal.FindById(id);
        return MapperSucursal.FromSucursalToDTO(suc);
    }
}
