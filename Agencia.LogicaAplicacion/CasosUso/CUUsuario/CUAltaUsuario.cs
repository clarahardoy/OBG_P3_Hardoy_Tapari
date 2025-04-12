using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario;

public class CUAltaUsuario : ICUAltaUsuario
{
    private IRepositorioUsuario _repositorioUsuario;
    private IRepositorioAuditoria _repositorioAuditoria;

    public CUAltaUsuario(IRepositorioUsuario repositorioUsuario, IRepositorioAuditoria repositorioAuditoria)
    {
        _repositorioUsuario = repositorioUsuario;
        _repositorioAuditoria = repositorioAuditoria;
    }

    public void AltaEmpleado(DTOAltaUsuario dto)
    {
        try
        {
            Usuario buscado = _repositorioUsuario.FindByEmail(dto.Email);
            if (buscado != null) throw new EmailYaExisteException("El email ingresado ya existe");

            Usuario nuevoUsuario = MapperUsuario.ToUsuario(dto);
            int entidadId = _repositorioUsuario.Add(nuevoUsuario);
            Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, "ALTA", "EXITO", nuevoUsuario.GetType().Name,
                entidadId.ToString(), "Alta correcta");
            _repositorioAuditoria.Auditar(aud);
        }
        catch (Exception ex)
        {
            Auditoria aud = Utilidades.Auditor.Auditar(null, "ALTA", "ERROR", null, null, null);
           _repositorioAuditoria.Auditar(aud);
            throw ex;
        }
    }
}