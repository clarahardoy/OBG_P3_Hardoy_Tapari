using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int? _id { get; set; }
        private NombreCompleto _nombreCompleto { get; set; }
        private string _email { get; set; }
        private string _password { get; set; }
        private RolUsuario _rol { get; set; }

        public Usuario(NombreCompleto nombreCompleto, string email, string password, RolUsuario rol)
        {
            _nombreCompleto = nombreCompleto;
            _email = email;
            _password = password;
            _rol = rol;
        }

        public Usuario() { }
    }
}