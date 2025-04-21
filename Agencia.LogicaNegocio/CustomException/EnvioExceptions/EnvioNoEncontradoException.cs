namespace Agencia.LogicaNegocio.CustomException.EnvioExceptions;

public class EnvioNoEncontradoException : Exception
{
    public EnvioNoEncontradoException(string? message) : base(message) { }
}