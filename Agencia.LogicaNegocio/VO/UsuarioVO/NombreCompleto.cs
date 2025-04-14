using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.VO.UsuarioVO
{
    [ComplexType]
    public record NombreCompleto
    {
        public string _nombre { get; init; }
        public string _apellido { get; init; }
        public NombreCompleto(string nombre, string apellido)
        {
            _nombre = nombre;
            _apellido = apellido;
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(_nombre))
            {
                throw new NombreNoValidoException("El nombre no puede ser vacío");
            }
            if (String.IsNullOrEmpty(_apellido))
            {
                throw new NombreNoValidoException("El apellido no puede ser vacío");
            }
        }
    }
}
