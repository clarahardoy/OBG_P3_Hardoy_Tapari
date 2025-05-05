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
        private string? calleDireccion;
        private string? ciudadDireccion;
        private string? departamentoDireccion;
        private string? codigoPostalDireccion;

        public Direccion(string? calleDireccion, string? ciudadDireccion, string? departamentoDireccion, string? codigoPostalDireccion)
        {
            this.calleDireccion = calleDireccion;
            this.ciudadDireccion = ciudadDireccion;
            this.departamentoDireccion = departamentoDireccion;
            this.codigoPostalDireccion = codigoPostalDireccion;
        }

        public string _calle {  get; set; }
        
        public string _ciudad {  get; set; }

        public string _departamento {  get; set; }

        public string _codigoPostal { get; set; }
    }
}
