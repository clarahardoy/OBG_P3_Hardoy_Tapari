using Agencia.LogicaNegocio.VO.AgenciaVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Agencia
    {
        public int _id { get; set; }
        private string _nombre { get; set; }
        private int _direccionPostal { get; set; }
        private Ubicacion _ubicacion { get; set; }


        // Constructor con parámetros
        public Agencia(string nombre, int direccionPostal, Ubicacion ubicacion)
        {
            _nombre = nombre;
            _direccionPostal = direccionPostal;
            _ubicacion = ubicacion;
        }

        // Constructor sin parámetros
        public Agencia() { }
    }
}
