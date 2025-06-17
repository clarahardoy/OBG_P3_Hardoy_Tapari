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
    public class CUObtenerEnvioNroTracking : ICUObtenerEnvioNroTracking
    {
        private readonly IRepositorioEnvio _repoEnvio;
        public CUObtenerEnvioNroTracking(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }

        public DTOEnvio Ejecutar(string nroTracking)
        {
            Envio eBuscado = _repoEnvio.FindByTrackingNumber(nroTracking);
            if (eBuscado == null) throw new EnvioNoEncontradoException("El número de Tracking ingresado no es válido");
            
            DTOEnvio dto = MapperEnvio.ToDtoEnvio(eBuscado);
            return dto;
        }
    }
}
