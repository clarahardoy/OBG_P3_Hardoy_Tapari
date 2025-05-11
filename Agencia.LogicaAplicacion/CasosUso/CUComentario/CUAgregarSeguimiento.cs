using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUEnvio;

public class CUAgregarSeguimiento : ICUAgregarSeguimiento
{
    private IRepositorioEnvio _repoEnvio;
    private IRepositorioAuditoria _repoAuditoria;
    private IRepositorioUsuario _repoUsuario;
    

    public CUAgregarSeguimiento(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria, IRepositorioEnvio repoEnvio)
    {
        _repoUsuario = repoUsuario;
        _repoAuditoria = repoAuditoria;
        _repoEnvio = repoEnvio;
    }
    
    public void AgregarSeguimiento(DTOAgregarSeguimiento dto)
    {
        int entidadId = (int)dto.idEnvio;
        Usuario usuario = null;
        
        try
        {
            Envio envio = _repoEnvio.FindById((int)dto.idEnvio);
            usuario = _repoUsuario.FindById((int)dto.idLogueado);
        
            Comentario nuevoSeg = MapperSeguimiento.ToComentario(usuario, dto.Seguimiento);
            envio.AgregarNuevoSeguimientoALista(nuevoSeg);
            _repoEnvio.Update(envio);
        
            Auditoria aud = Utilidades.Auditor.Auditar(dto.idLogueado, Acciones.EDICION, "EXITO", usuario.GetType().Name,
                entidadId.ToString(), "Seguimiento exitoso");
            _repoAuditoria.Auditar(aud);

        }
        catch (Exception e)
        {
            Auditoria audError = Utilidades.Auditor .Auditar(dto.idLogueado, Acciones.EDICION, "ERROR",
                usuario.GetType().Name, entidadId.ToString(), $"ERROR: {e.Message}");
            _repoAuditoria.Auditar(audError);

            throw; 
        }
    }
}