using Agencia.DTOs.DTOs.EnvioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUObtenerEnvio
    {
        public DTOEnvio Ejecutar(int id);
    }
}
