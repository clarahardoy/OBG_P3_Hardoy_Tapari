using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUEnvio;

public class CUObtenerEnviosEnProceso : ICUObtenerEnviosEnProceso
{
    private readonly IRepositorioEnvio _repoEnvio;
    public CUObtenerEnviosEnProceso(IRepositorioEnvio repoEnvio)
    {
        _repoEnvio = repoEnvio;
    }
    
    public List<DTOEnvio> ObtenerEnviosEnProceso()
    {
        List<Envio> enviosEnProceso = _repoEnvio.ObtenerEnviosEnProceso();
        List<DTOEnvio> ret = MapperEnvio.FromListEnvioToListDto(enviosEnProceso);
        return ret;
        
    }
}