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
        public Sucursal AgenciaDestino { get; set; }

        public int AgenciaDestinoId { get; set; } // FK

        public EnvioComun(Usuario empleado, Usuario cliente, double peso,
                            Sucursal agenciaOrigen, Sucursal destino) :
            base(empleado, cliente, peso, agenciaOrigen)
        {
            AgenciaDestino = destino;
        }

        public EnvioComun() : base() { }

        public override void FinalizarEnvio()
        {
            FinalizarEnvioBase();
        }
    }
}
