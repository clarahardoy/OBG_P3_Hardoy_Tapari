using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.CustomException.EnvioExceptions
{
    public class NoHayEnviosException : Exception
    {
        public NoHayEnviosException(string? message) : base(message) { }
    }
}
