namespace Agencia.LogicaNegocio.CustomException.EnvioExceptions;

public class EnvioYaFinalizadoException : Exception
{
    public EnvioYaFinalizadoException(string? message) : base(message) { }
}