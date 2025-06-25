using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUActualizarContrasenia : ICUActualizarContrasenia
    {
        private IRepositorioUsuario _repoUsuario;

        public CUActualizarContrasenia(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public void Ejecutar(DTOActualizarContrasenia dto)
        {
            if (dto.NewPassword == dto.OldPassword)
                throw new ContraseniaIncorrectaException("La nueva contraseña no puede ser igual a la anterior.");

            Usuario uBuscado = _repoUsuario.FindByEmail(dto.Email);
            if (uBuscado == null) throw new EmailNoValidoException("Email no válido.");

            // Validar que la oldPassword sea igual a la que está gurdada
            if (!(Utilidades.Crypto.VerifyPasswordConBcrypt(dto.OldPassword, uBuscado.Password)))
            {
                throw new ContraseniaIncorrectaException("La contraseña anterior es incorrecta.");
            }
            else
            {
                string newPass = Utilidades.Crypto.HashPasswordConBcrypt(dto.NewPassword, 10);
                uBuscado.Password = newPass;
                _repoUsuario.Update(uBuscado);
            }
        }
    }
}
