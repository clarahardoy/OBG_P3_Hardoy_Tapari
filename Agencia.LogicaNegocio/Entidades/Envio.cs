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

        public string NroTracking { get; set; }

        public int EmpleadoId { get; set; } // FK

        public Usuario Empleado { get; set; }

        public int ClienteId { get; set; } // FK

        public Usuario Cliente { get; set; }

        public double Peso { get; set; }

        public EstadoEnvio Estado { get; set; }

        public List<Comentario> Seguimiento { get; set; } = new List<Comentario>();

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public Sucursal AgenciaOrigen { get; set; }

        public int AgenciaOrigenId { get; set; } // FK

        public Envio(Usuario empleado, Usuario cliente,
                     double peso, Sucursal agenciaOrigen)
        {
            NroTracking = GenerarTracking();
            Empleado = empleado;
            Cliente = cliente;
            Peso = peso;
            Estado = EstadoEnvio.EN_PROCESO;
            FechaInicio = DateTime.Now;
            FechaEntrega = null;
            AgenciaOrigen = agenciaOrigen;
            Validar();
        }

        public Envio() { }

        public abstract void FinalizarEnvio();

        protected void FinalizarEnvioBase()
        {
            if (Estado == EstadoEnvio.FINALIZADO)
                throw new EnvioYaFinalizadoException("El envío ya finalizó");

            Estado = EstadoEnvio.FINALIZADO;
            FechaEntrega = DateTime.Now;
        }

        private string GenerarTracking()
        {
            return DateTime.Now.ToString("yyyyMMddddHHmmss");
        }

        private void Validar()
        {
            if (Peso <= 0)
            {
                throw new PesoInvalidoException("El Peso debe ser mayor a 0.");
            }
        }
        
        public void AgregarNuevoSeguimientoALista(Comentario comentarioSeguimiento)
        {
            Seguimiento.Add(comentarioSeguimiento);
        }
    }
}
