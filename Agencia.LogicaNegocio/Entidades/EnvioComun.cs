using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class EnvioComun : Envio
    {
        public Agencia _destino { get; set; }

        public EnvioComun(int nroTracking, Usuario empleado, Usuario cliente, double peso, EstadoEnvio estado, List<Comentario> seguimiento, Agencia destino) : base(nroTracking, empleado, cliente, peso, estado, seguimiento)
        {
            _destino = destino;
        }
        public EnvioComun() : base() { }
    }
}
