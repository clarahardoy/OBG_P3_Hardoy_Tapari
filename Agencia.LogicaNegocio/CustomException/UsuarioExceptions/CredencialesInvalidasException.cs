using System;

namespace Agencia.LogicaNegocio.CustomException.UsuarioExceptions;

public class CredencialesInvalidasException : Exception
{
    public CredencialesInvalidasException(string? message) : base(message) { }
}