using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.CustomException.EnvioExceptions
{
    internal class PesoInvalidoException : Exception
    {
        public PesoInvalidoException(string? message) : base(message) { }
    }
    
}
