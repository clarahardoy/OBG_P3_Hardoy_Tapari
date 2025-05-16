using Agencia.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.DTOs.DTOs.ComentarioDTO
{
    public class DTOComentario
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha = DateTime.Now;
        public string EmpleadoAutor { get; set; }
    }
}
