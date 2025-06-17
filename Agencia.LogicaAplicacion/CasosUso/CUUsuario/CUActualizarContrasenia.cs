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
            Usuario uBuscado = _repoUsuario.FindByEmail(dto.Email);
            if (uBuscado == null) throw new EmailNoValidoException("Email no válido.");
            
            if (uBuscado.Password != dto.OldPassword)
            {
                throw new ContraseniaIncorrectaException("La contraseña anterior es incorrecta.");
            }
            else
            {
                uBuscado.Password = dto.NewPassword;
                _repoUsuario.Update(uBuscado);
            }
        }
    }
}
