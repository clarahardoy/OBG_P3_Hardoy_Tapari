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
        public Direccion _direccionDestino {  get; set; }
        public bool? _entregaEficiente { get; set; }

        public EnvioUrgente(Usuario empleado, Usuario cliente, double peso,
                            Sucursal agenciaOrigen, Direccion direccionDestino) :
            base(empleado, cliente, peso, agenciaOrigen)
        {
            _direccionDestino = direccionDestino;
        }

        public EnvioUrgente() : base() { }

        public override void FinalizarEnvio()
        {
            FinalizarEnvioBase();
            //TODO: CalcularEficiencia();
        }
    }
}