using Agencia.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioEnvio : IRepositorio<Envio>
    {
        List<Envio> ObtenerEnviosEnProceso();

        Envio FindByTrackingNumber(string nroTracking);

        List<Envio> ObtenerEnviosDeClienteOrdFecha(string emailCliente);

        List<Envio> ObtenerEnviosFechaCliente(string emailCliente, DateTime fecha1, DateTime fecha2);
    }
}