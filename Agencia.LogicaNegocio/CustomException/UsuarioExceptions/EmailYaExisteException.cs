
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.CustomException.UsuarioExceptions
{
    public class EmailYaExisteException : Exception
    {
        public EmailYaExisteException(string? message) : base(message) { }
    }
}
