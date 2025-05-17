using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.VO.EnvioVO
{
    [ComplexType]
    public record Direccion
    {

        public string Calle { get; set; }

        public string Ciudad { get; set; }

        public string Departamento { get; set; }

        public string CodigoPostal { get; set; }

        public Direccion(string calleDireccion, string ciudadDireccion, string departamentoDireccion, string codigoPostalDireccion)
        {
            this.Calle = calleDireccion;
            this.Ciudad = ciudadDireccion;
            this.Departamento = departamentoDireccion;
            this.CodigoPostal = codigoPostalDireccion;
        }

        public Direccion() { }
    }
}
