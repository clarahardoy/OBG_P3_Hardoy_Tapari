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

        public string Nombre { get; set; }

        public int DireccionPostal { get; set; }

        public Ubicacion Ubicacion { get; set; }

        // Constructor con parámetros
        public Sucursal(string nombre, int direccionPostal, Ubicacion ubicacion)
        {
            Nombre = nombre;
            DireccionPostal = direccionPostal;
            Ubicacion = ubicacion;
            Validar();
        }

        // Constructor sin parámetros
        public Sucursal() { 
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new SucursalInvalidaException("El nombre de la sucursal es obligatorio.");

            if (DireccionPostal <= 0)
                throw new SucursalInvalidaException("La dirección postal debe ser un número positivo.");
        }
    }
}
