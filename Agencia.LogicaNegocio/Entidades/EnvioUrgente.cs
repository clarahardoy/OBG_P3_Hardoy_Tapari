using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Agencia.LogicaNegocio.VO.EnvioVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class EnvioUrgente : Envio
    {
        public Direccion DireccionDestino {  get; set; }

        public bool? EntregaEficiente { get; set; }

        public EnvioUrgente(Usuario empleado, Usuario cliente, double peso,
                            Sucursal agenciaOrigen, Direccion direccionDestino) :
            base(empleado, cliente, peso, agenciaOrigen)
        {
            DireccionDestino = direccionDestino;
        }

        public EnvioUrgente() : base() { }

        public override void FinalizarEnvio()
        {
            FinalizarEnvioBase();
            this.CalcularEficiencia();
        }

        private void CalcularEficiencia()
        {
            var diferencia = FechaEntrega - FechaInicio;

            if (diferencia < TimeSpan.FromHours(24))
            {
                EntregaEficiente = true;
            }
            else
            {
                EntregaEficiente = false;
            }
        }
    }
}