using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CULogin : ICULogin
    {

        private IRepositorioUsuario _repositorioUsuario;

        public CULogin(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public DTOUsuario VerificarDatosParaLogin(DTOUsuario dto)
        {
            try
            {
                Usuario usuario = _repositorioUsuario.FindByEmail(dto.Email);

                bool passwordCoincide = Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, usuario._password);

                if (passwordCoincide)
                {
                    DTOUsuario ret = new DTOUsuario();
                    ret.Id = usuario._id;
                    ret.Rol = usuario._rol.ToString();
                    return ret;
                }
                else
                {
                    throw new CredencialesInvalidasException("Credenciales inválidas");
                }
            }
            catch (Exception e)
            {
                throw e;
            }


        }
    }
}
     