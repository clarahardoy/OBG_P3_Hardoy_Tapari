﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.CustomException.UsuarioExceptions
{
    public class NombreNoValidoException : Exception
    {
        public NombreNoValidoException(string? message) : base(message) { }
    }
}