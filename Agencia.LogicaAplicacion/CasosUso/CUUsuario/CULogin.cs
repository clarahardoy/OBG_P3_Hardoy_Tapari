using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
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
            var usuario = _repositorioUsuario.FindByEmail(dto.Email);
            if (!usuario.Activo)
                throw new UsuarioInactivoException("Usuario inactivo. No puede acceder.");

            if (usuario is null)
                throw new CredencialesInvalidasException("Email o contraseña incorrectos");

            bool passwordCoincide = Utilidades.Crypto.VerifyPasswordConBcrypt(dto.Password, usuario.Password);
            if (!passwordCoincide)
                throw new CredencialesInvalidasException("Email o contraseña incorrectos");

            return new DTOUsuario
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Rol = usuario.Rol.ToString(),
                Activo = usuario.Activo
            };
        }
    }
}