
namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario
{
    public class ContraseniaIncorrectaException : Exception
    {
        public ContraseniaIncorrectaException(string? message) : base(message) { }
    }
}