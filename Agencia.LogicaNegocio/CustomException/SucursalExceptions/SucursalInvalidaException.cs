using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.CustomException.SucursalExceptions;

public class SucursalInvalidaException : Exception
{
    public SucursalInvalidaException(string? message) : base(message) { }
}
