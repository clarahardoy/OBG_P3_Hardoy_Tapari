using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;

namespace Utilidades;

//public class Auditor
//{
//    public static Auditoria Auditar(int? usuarioId, Acciones accion, string resultado, string entidad, string entidadId, string observaciones, string message)
//    {
//        Auditoria nuevaAuditoria = new Auditoria(usuarioId, accion, resultado, entidad, entidadId, observaciones);
//        return nuevaAuditoria;
//    }
//}


public class Auditor
{
    public static Auditoria Auditar(int? usuarioId, Acciones accion, string resultado, string entidad, string entidadId, string observaciones)
    {
        Auditoria nuevaAuditoria = new Auditoria(usuarioId, accion, resultado, entidad, entidadId, observaciones);
        return nuevaAuditoria;
    }
}