using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUEnvio;

public class CUObtenerEnviosPorComentario : ICUObtenerEnviosPorComentario
{
    private readonly IRepositorioEnvio _repoEnvio;

    public CUObtenerEnviosPorComentario(IRepositorioEnvio repoEnvio)
    {
        _repoEnvio = repoEnvio; 
    }

    public List<DTOEnvio> Ejecutar(string palabraClave, string email)
    {
        List<Envio> envios = _repoEnvio.ObtenerEnviosDeClienteOrdFecha(email);
        
        var contienenPalabraClave = envios
            .Where(e => e.Seguimiento.Any(
                com => !string.IsNullOrEmpty(com.Descripcion) && com.Descripcion.ToLower().Contains(palabraClave.ToLower())
            ))
            .Select(e => MapperEnvio.ToDtoEnvio(e)) 
            .ToList();

        if (contienenPalabraClave == null || contienenPalabraClave.Count == 0)
        {
            throw new NoHayEnviosException("No se encontraron envíos.");
        }
        
        return contienenPalabraClave; 

    }
    
}