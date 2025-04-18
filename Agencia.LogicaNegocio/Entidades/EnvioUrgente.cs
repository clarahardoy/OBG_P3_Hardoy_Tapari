using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class EnvioUrgente : Envio
    {
        public int _direccionPostal { get; set; }
        public bool _entregado { get; set; }

        public EnvioUrgente(
            int nroTracking,
            Usuario empleado,
            Usuario cliente,
            double peso,
            EstadoEnvio estado,
            List<Comentario> seguimiento,
            DateTime fechaEntrega,
            int direccionPostal, 
            bool entregado) 
            : base(nroTracking, empleado, cliente, peso, estado, seguimiento, fechaEntrega)
        {
            _direccionPostal = direccionPostal;
            _entregado = entregado;
        }

        public EnvioUrgente() : base() { }

        public override void FinalizarEnvio()
        {
           FinalizarEnvioBase();
           //TODO CalcularEficiencia();
        }
    }
}