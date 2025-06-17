using Agencia.DTOs.DTOs.EnvioDTO;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;

public interface ICUFinalizarEnvio
{
    void Ejecutar(DTOEnvio dto);
}