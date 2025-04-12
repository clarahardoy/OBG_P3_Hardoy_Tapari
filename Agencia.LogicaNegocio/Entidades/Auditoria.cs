namespace Agencia.LogicaNegocio.Entidades;

public class Auditoria
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }
    public string? Accion { get; set; }
    public string? Resultado { get; set; }
    public string? Entidad { get; set; }
    public string? EntidadId { get; set; }
    public string? Observaciones { get; set; }
    public DateTime Fecha { get; set; }

    public Auditoria(int? usuarioId, string accion, string resultado, string entidad, string entidadId, string observaciones)
    {
        UsuarioId = usuarioId;
        Accion = accion;
        Resultado = resultado;
        Entidad = entidad;
        EntidadId = entidadId;
        Observaciones = observaciones;
        Fecha = DateTime.Now;
    }
}