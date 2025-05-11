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

        public string _nroTracking { get; set; }

        public int EmpleadoId { get; set; } // FK

        public Usuario _empleado { get; set; }

        public int ClienteId { get; set; } // FK
        public Usuario _cliente { get; set; }

        public double _peso { get; set; }

        public EstadoEnvio _estado { get; set; }

        public List<Comentario> _seguimiento { get; set; } = new List<Comentario>();

        public DateTime? _fechaInicio { get; set; }

        public DateTime? _fechaEntrega { get; set; }

        public Sucursal _agenciaOrigen { get; set; }
        public int AgenciaOrigenId { get; set; } // FK

        public Envio(Usuario empleado, Usuario cliente,
                     double peso, Sucursal agenciaOrigen)
        {
            _nroTracking = GenerarTracking();
            _empleado = empleado;
            _cliente = cliente;
            _peso = peso;
            _estado = EstadoEnvio.EN_PROCESO;
            _fechaInicio = DateTime.Now;
            _fechaEntrega = null;
            _agenciaOrigen = agenciaOrigen;
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

        private string GenerarTracking()
        {
            return DateTime.Now.ToString("yyyyMMddddHHmmss");
        }

        private void Validar()
        {
            if (_peso <= 0)
            {
                throw new PesoInvalidoException("El Peso debe ser mayor a 0.");
            }
        }
        
        public void AgregarNuevoSeguimientoALista(Comentario comentarioSeguimiento)
        {
            _seguimiento.Add(comentarioSeguimiento);
        }
    }
}
