using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.LogicaNegocio.CustomException.EnvioExceptions;

namespace Agencia.LogicaNegocio.Entidades
{
    public class EnvioComun : Envio
    {
        public Sucursal _destino { get; set; }

        public EnvioComun(int nroTracking, Usuario empleado, Usuario cliente, double peso, EstadoEnvio estado, List<Comentario> seguimiento, Sucursal destino, DateTime fechaEntrega) : base(nroTracking, empleado, cliente, peso, estado, seguimiento, fechaEntrega)
        {
            _destino = destino;
        }
        public EnvioComun() : base() { }
        public override void FinalizarEnvio()
        {
            FinalizarEnvioBase();
        }
    }
}
