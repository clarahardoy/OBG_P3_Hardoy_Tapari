using System;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;

namespace Agencia.LogicaNegocio.Entidades;

public class Auditoria
{
    public int Id { get; set; }
    public int? UsuarioId { get; set; }
    public Acciones? Accion { get; set; }
    public string? Resultado { get; set; }
    public string? Entidad { get; set; }
    public string? EntidadId { get; set; }
    public string? Observaciones { get; set; }
    public DateTime Fecha { get; set; }

    public Auditoria()
    {
        Fecha = DateTime.Now;
    }

    public Auditoria(int? usuarioId, Acciones accion, string resultado, string entidad, string entidadId, string observaciones)
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