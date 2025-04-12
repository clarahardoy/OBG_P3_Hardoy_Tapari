using Agencia.DTOs.DTOs.UsuarioDTO;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;

public interface ICULogin

    {

        DTOUsuario VerificarDatosParaLogin(DTOUsuario dto);
    }
