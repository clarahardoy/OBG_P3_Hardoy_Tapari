using Agencia.DTOs.DTOs.EnvioDTO;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;

public interface ICUObtenerEnviosPorComentario
    {
        List<DTOEnvio> Ejecutar(string palabraClave, string emailCliente);
    }
