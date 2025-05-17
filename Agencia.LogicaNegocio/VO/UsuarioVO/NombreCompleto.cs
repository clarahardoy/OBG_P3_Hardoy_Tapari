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
        public string Nombre { get; init; }

        public string Apellido { get; init; }

        public NombreCompleto(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public void Validar()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new NombreNoValidoException("El nombre no puede ser vacío");
            }
            if (String.IsNullOrEmpty(Apellido))
            {
                throw new NombreNoValidoException("El apellido no puede ser vacío");
            }
        }
    }
}
