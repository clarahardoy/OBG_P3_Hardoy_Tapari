using System;
using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;
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

    public void Ejecutar(DTOAltaUsuario dto)
    {
        try
        {
            Usuario buscado = _repositorioUsuario.FindByEmail(dto.Email);
            if (buscado != null) throw new EmailYaExisteException("El email ingresado ya existe");

            Usuario nuevoUsuario = MapperUsuario.FromDtoAltaUsuario(dto);

            int entidadId = _repositorioUsuario.Add(nuevoUsuario);

            Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, Acciones.ALTA, "EXITO", nuevoUsuario.GetType().Name,
                entidadId.ToString(), "Alta correcta");
            _repositorioAuditoria.Auditar(aud);
        }
        catch (Exception ex)
        {
            Auditoria aud = Utilidades.Auditor.Auditar(null, Acciones.ALTA, "ERROR", null, null, null);
            _repositorioAuditoria.Auditar(aud);
            throw ;
        }
    }
}