using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUEliminarFuncionario : ICUEliminarFuncionario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUEliminarFuncionario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }
        public void EliminarFuncionario(DTOUsuario dto)
        {
            Usuario usuario = MapperUsuario.FromDtoUsuarioToUsuario(dto);
            try
            {
                Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, Acciones.ELIMINACION, "EXITO", usuario.GetType().Name,
                       null, "Eliminado exitosamente");
                _repoAuditoria.Auditar(aud);
            }
            catch (Exception ex)
            {
                Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, Acciones.ELIMINACION, "FALLA", usuario.GetType().Name,
                       null, ex.Message);
                _repoAuditoria.Auditar(aud);
                throw ex;
            }
        }
    }
}
