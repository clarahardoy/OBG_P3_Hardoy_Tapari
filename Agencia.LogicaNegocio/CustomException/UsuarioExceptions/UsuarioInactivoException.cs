namespace Agencia.LogicaNegocio.CustomException.UsuarioExceptions;

public class UsuarioInactivoException : Exception
{
    public UsuarioInactivoException(string? message) : base(message) { }
}