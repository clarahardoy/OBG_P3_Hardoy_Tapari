using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.AuditoriaEnums;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using Agencia.LogicaNegocio.VO.EnvioVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUAltaEnvio : ICUAltaEnvio
    {
        private IRepositorioEnvio _repositorioEnvio;
        private IRepositorioAuditoria _repositorioAuditoria;
        private IRepositorioSucursal _repositorioSucursal;
        private IRepositorioUsuario _repositorioUsuario;

        public CUAltaEnvio(IRepositorioEnvio repositorioEnvio,
                           IRepositorioAuditoria repositorioAuditoria,
                           IRepositorioSucursal repositorioSucursal,
                           IRepositorioUsuario repositorioUsuario)
        {
            _repositorioEnvio = repositorioEnvio;
            _repositorioAuditoria = repositorioAuditoria;
            _repositorioSucursal = repositorioSucursal;
            _repositorioUsuario = repositorioUsuario;
        }
        public void AltaEnvio(DTOAltaEnvio dto)
        {
            try
            {
                // Mappeo a mano ya que hay que salir a buscar la agencia, el cliente y el empleado : 
                Sucursal agenciaOrigenBuscada = _repositorioSucursal.FindById(dto.AgenciaOrigenId);
                Sucursal agenciaDestinoBuscada = _repositorioSucursal.FindById((int)dto.AgenciaDestinoId);
                Usuario empleadoAutorBuscado = _repositorioUsuario.FindById((int)dto.LogueadoId);
                Usuario clienteBuscado = _repositorioUsuario.FindByEmail(dto.ClienteEmail);
                if (clienteBuscado == null || clienteBuscado._rol != RolUsuario.Cliente)
                    throw new EmailNoValidoException("Email de Cliente inválido.");

                Comentario primerComentario = new Comentario(dto.PrimerComentario, empleadoAutorBuscado);

                Envio e = MapperEnvio.ToEnvio(dto, agenciaDestinoBuscada);
                e._agenciaOrigen = agenciaOrigenBuscada;
                e._empleado = empleadoAutorBuscado;
                e._cliente = clienteBuscado;
                e._seguimiento.Add(primerComentario);

                int entidadId = _repositorioEnvio.Add(e);

                Auditoria aud = Utilidades.Auditor.Auditar(dto.LogueadoId, Acciones.ALTA, "EXITO", e.GetType().Name,
                entidadId.ToString(), "Alta correcta");
                _repositorioAuditoria.Auditar(aud);
            }
            catch (Exception ex)
            {
                Auditoria aud = Utilidades.Auditor.Auditar(null, Acciones.ALTA, "ERROR", null, null, null);
                _repositorioAuditoria.Auditar(aud);
                throw;
            }
        }
    }
}
