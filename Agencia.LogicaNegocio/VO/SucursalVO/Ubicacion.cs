using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.VO.AgenciaVO
{
    [ComplexType]
    public record Ubicacion
    {
        public int Latitud { get; set; }

        public int Longitud { get; set; }
    }
}