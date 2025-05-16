using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.CustomException.UsuarioExceptions
{
    public class AccesoDenegadoException : Exception
    {
        public AccesoDenegadoException(string? message) : base(message) { }
    }
}
