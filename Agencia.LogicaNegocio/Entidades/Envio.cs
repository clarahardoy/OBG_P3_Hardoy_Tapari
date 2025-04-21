using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;

namespace Agencia.LogicaNegocio.Entidades
{
    public abstract class Envio
    {
        public int Id { get; set; }

        public int _nroTracking { get; set; }

        public int EmpleadoId { get; set; } // FK

        public Usuario _empleado { get; set; }

        public int ClienteId { get; set; } // FK
        public Usuario _cliente { get; set; }

        public double _peso { get; set; }

        public EstadoEnvio _estado { get; set; }

        public List<Comentario> _seguimiento { get; set; }
        
        public DateTime? _fechaEntrega { get; set; }

        public Envio(int nroTracking, Usuario empleado, Usuario cliente, double peso, EstadoEnvio estado, List<Comentario> seguimiento, DateTime fechaEntrega)
        {
            _nroTracking = nroTracking;
            _empleado = empleado;
            _cliente = cliente;
            _peso = peso;
            _estado = estado;
            _seguimiento = seguimiento;
            _fechaEntrega = fechaEntrega;
        }

        public Envio() { }

        public abstract void FinalizarEnvio();

        protected void FinalizarEnvioBase()
        {
            if (_estado == EstadoEnvio.FINALIZADO)
                throw new EnvioYaFinalizadoException("El envío ya finalizó");

            _estado = EstadoEnvio.FINALIZADO;
            _fechaEntrega = DateTime.Now;
        }
    }
}
