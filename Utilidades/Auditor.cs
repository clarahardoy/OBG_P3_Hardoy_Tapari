using Agencia.LogicaNegocio.Entidades;

namespace Utilidades;

public class Auditor
{
    public static Auditoria Auditar( int? usuarioId, string accion, string resultado, string entidad, string entidadId, string observaciones)
    {
        Auditoria nuevaAuditoria = new Auditoria(usuarioId, accion, resultado, entidad, entidadId, observaciones);
        return nuevaAuditoria;
    }
}