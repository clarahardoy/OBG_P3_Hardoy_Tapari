using Agencia.DTOs.DTOs.EnvioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUObtenerEnviosPorFechasDeCliente
    {
        List<DTOEnvio> Ejecutar(string email, DateTime fechaInicio, DateTime fechaFin);
    }
}
