using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        public Usuario EmpleadoAutor { get; set; }

        public Comentario(string descripcion, Usuario empleadoAutor)
        {
            Descripcion = descripcion;
            Fecha = DateTime.Now;
            EmpleadoAutor = empleadoAutor;
        }

        public Comentario()
        {
            Fecha = DateTime.Now;
        }
    }
}