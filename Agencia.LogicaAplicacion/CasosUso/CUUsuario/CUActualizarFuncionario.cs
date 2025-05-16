using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUActualizarFuncionario : ICUActualizarFuncionario
    {
        private IRepositorioUsuario _repoUsuario;
        private IRepositorioAuditoria _repoAuditoria;

        public CUActualizarFuncionario(IRepositorioUsuario repoUsuario, IRepositorioAuditoria repoAuditoria)
        {
            _repoUsuario = repoUsuario;
            _repoAuditoria = repoAuditoria;
        }
        public void ActualizarFuncionario(DTOActualizarFuncionario dto)
        {
            try
            {
                // Traigo el Usuario de la BD:
                Usuario usuario = _repoUsuario.FindById((int)dto.Id);

                // Le cambio solo los datos que tengo en el DTO:
                usuario._nombreCompleto = new NombreCompleto(dto.Nombre, dto.Apellido);
                usuario._email = dto.Email;
                usuario._rol = (RolUsuario)Enum.Parse(typeof(RolUsuario), dto.Rol);

                usuario.Validar();
                int entidadId = _repoUsuario.Update(usuario);

                Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, Acciones.EDICION, "EXITO", usuario.GetType().Name,
                    entidadId.ToString(), "Actualización exitosa");
                _repoAuditoria.Auditar(aud);
            }
            catch (EmailNoValidoException e)
            {
                Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, Acciones.EDICION, "FALLO", null,
                    null, e.Message); 
                _repoAuditoria.Auditar(aud);
                throw;
            }
            catch (Exception e)
            {
                Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, Acciones.EDICION, "FALLO", null,
                    null, e.Message);
                _repoAuditoria.Auditar(aud);
                throw;
            }
        }
    }
}
