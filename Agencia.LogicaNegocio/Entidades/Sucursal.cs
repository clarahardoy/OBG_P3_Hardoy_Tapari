using Agencia.LogicaNegocio.VO.AgenciaVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string _nombre { get; set; }
        public int _direccionPostal { get; set; }
        public Ubicacion _ubicacion { get; set; }


        // Constructor con parámetros
        public Sucursal(string nombre, int direccionPostal, Ubicacion ubicacion)
        {
            _nombre = nombre;
            _direccionPostal = direccionPostal;
            _ubicacion = ubicacion;
        }

        // Constructor sin parámetros
        public Sucursal() { }
    }
}
