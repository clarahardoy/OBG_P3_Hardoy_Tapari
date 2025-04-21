using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUEnvio;

public class CUFinalizarEnvio : ICUFinalizarEnvio
{
    private IRepositorioEnvio _repoEnvio;
    private IRepositorioAuditoria _repoAuditoria;
    
    public CUFinalizarEnvio(IRepositorioEnvio repoEnvio, IRepositorioAuditoria repoAuditoria)
    {
        _repoEnvio = repoEnvio;
        _repoAuditoria = repoAuditoria;
    }
    
    public void FinalizarEnvio(int idEnvio, int idUsuarioLogueado)
    {
        try
        {
            Envio envioAFinalizar = _repoEnvio.FindById(idEnvio);
            if (envioAFinalizar == null) throw new EnvioNoEncontradoException("No se encontró el envío.");
            
            envioAFinalizar.FinalizarEnvio(); 
            _repoEnvio.Update(envioAFinalizar);
            Auditoria aud = Utilidades.Auditor.Auditar(
                idUsuarioLogueado,
                Acciones.EDICION,
                "EXITO",
                envioAFinalizar.GetType().Name,
                idEnvio.ToString(),
                "Finalización de envío exitosa"
            );
            _repoAuditoria.Auditar(aud);


        }
        catch (Exception e)
        {
            Auditoria aud = Utilidades.Auditor.Auditar(
                idUsuarioLogueado,
                Acciones.EDICION,
                "FALLO",
                null,
                null,
                e.Message
            );
            _repoAuditoria.Auditar(aud);
            throw;
        }
    }
}