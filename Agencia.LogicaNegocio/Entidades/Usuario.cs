﻿using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public NombreCompleto _nombreCompleto { get; set; }
        public string _email { get; set; }
        public string _password { get; set; }
        public RolUsuario _rol { get; set; }

        public Usuario(NombreCompleto nombreCompleto, string email, string password, RolUsuario rol)
        {
            _nombreCompleto = nombreCompleto;
            _email = email;
            _password = password;
            _rol = rol;

            nombreCompleto.Validar(); 
            if (!email.Contains('@')) {

                throw new EmailNoValidoException("El email no tiene arroba");
            }
        }
        public Usuario() { }
    }
}