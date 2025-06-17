using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.LogicaNegocio.Entidades;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;

public interface ICUAgregarSeguimiento
{
    void Ejecutar(DTOAgregarSeguimiento dto);
}