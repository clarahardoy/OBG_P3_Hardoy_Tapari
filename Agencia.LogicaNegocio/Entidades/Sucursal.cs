using Agencia.LogicaNegocio.CustomException.SucursalExceptions;
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
            Validar();
        }

        // Constructor sin parámetros
        public Sucursal() { 
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(_nombre))
                throw new SucursalInvalidaException("El nombre de la sucursal es obligatorio.");

            if (_direccionPostal <= 0)
                throw new SucursalInvalidaException("La dirección postal debe ser un número positivo.");
        }
    }
}
