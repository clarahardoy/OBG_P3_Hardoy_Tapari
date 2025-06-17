using Agencia.DTOs.DTOs.UsuarioDTO;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;

public interface ICUAltaUsuario
{
    void Ejecutar(DTOAltaUsuario dto);
}