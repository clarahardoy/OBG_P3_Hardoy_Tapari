using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Envio
    {
        private int _id { get; set; }
        private int _nroTracking { get; set; }
        private Usuario _empleado { get; set; }
        private Usuario _cliente { get; set; }
        private double _peso { get; set; }
        private EstadoEnvio _estado { get; set; }
        private List<Comentario> _seguimiento { get; set; }

        public Envio(int nroTracking, Usuario empleado, Usuario cliente, double peso, EstadoEnvio estado, List<Comentario> seguimiento)
        {
            _nroTracking = nroTracking;
            _empleado = empleado;
            _cliente = cliente;
            _peso = peso;
            _estado = estado;
            _seguimiento = seguimiento;
        }

        public Envio() { }
    }
}
