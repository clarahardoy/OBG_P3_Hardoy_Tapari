using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public NombreCompleto NombreCompleto { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public RolUsuario Rol { get; set; }

        public bool Activo { get; set; }

        public Usuario(NombreCompleto nombreCompleto, string email, string password, RolUsuario rol)
        {
            NombreCompleto = nombreCompleto;
            Email = email;
            Password = password;
            Rol = rol;
            Activo = true;
            Validar();
        }

        public Usuario() { }

        private void Validar()
        {
            NombreCompleto.Validar();
            if (!(Email.Contains('@')))
            {
                throw new EmailNoValidoException("El email no tiene arroba");
            }
        }
    }
}