using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUEnvio;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.CasosUso.CUEnvio
{
    public class CUObtenerEnvio : ICUObtenerEnvio
    {
        private IRepositorioEnvio _repoEnvio;
        private IRepositorioAuditoria _repoAuditoria;

        public CUObtenerEnvio(IRepositorioEnvio repoEnvio, IRepositorioAuditoria repoAuditoria)
        {
            _repoEnvio = repoEnvio;
            _repoAuditoria = repoAuditoria;
        }
        public DTOEnvio ObtenerEnvioPorId(int id)
        {
            Envio envioBuscado = _repoEnvio.FindById(id);
            if (envioBuscado == null) throw new EnvioNoEncontradoException("Id de Envío incorrecto");
            DTOEnvio dto = MapperEnvio.ToDtoEnvio(envioBuscado);
            return dto;
        }
    }
}
