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

        public string _calle { get; set; }

        public string _ciudad { get; set; }

        public string _departamento { get; set; }

        public string _codigoPostal { get; set; }

        public Direccion(string calleDireccion, string ciudadDireccion, string departamentoDireccion, string codigoPostalDireccion)
        {
            this._calle = calleDireccion;
            this._ciudad = ciudadDireccion;
            this._departamento = departamentoDireccion;
            this._codigoPostal = codigoPostalDireccion;
        }

        public Direccion() { }
    }
}
