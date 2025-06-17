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
    public class CUObtenerEnviosDeClienteOrdFecha : ICUObtenerEnviosDeClienteOrdFecha
    {
        private IRepositorioEnvio _repoEnvio;

        public CUObtenerEnviosDeClienteOrdFecha(IRepositorioEnvio repoEnvio)
        {
            _repoEnvio = repoEnvio;
        }
        public List<DTOEnvio> Ejecutar(string email)
        {
            List<Envio> envios = _repoEnvio.ObtenerEnviosDeClienteOrdFecha(email);
            if (envios == null || envios.Count == 0)
            {
                throw new NoHayEnviosException("No se encontraron envíos para el cliente.");
            }

            List<DTOEnvio> ret = MapperEnvio.FromListEnvioToListDto(envios);
            return ret;
        }
    }
}
