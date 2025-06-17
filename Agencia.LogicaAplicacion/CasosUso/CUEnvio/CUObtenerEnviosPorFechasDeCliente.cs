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
    public class CUObtenerEnviosPorFechasDeCliente : ICUObtenerEnviosPorFechasDeCliente
    {
        private IRepositorioEnvio _repoEnvio;

        public CUObtenerEnviosPorFechasDeCliente(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }

        public List<DTOEnvio> Ejecutar(string email, DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
            {
                DateTime temp = fechaInicio;
                fechaInicio = fechaFin;
                fechaFin = temp;
            }
            List<Envio> envios = _repoEnvio.ObtenerEnviosFechaCliente(email, fechaInicio, fechaFin);
            if (envios == null || envios.Count == 0)
                throw new NoHayEnviosException("No se encontraros envíos realizados entre esas fechas.");

            List<DTOEnvio> ret = MapperEnvio.FromListEnvioToListDto(envios);
            return ret;
        }
    }
}
