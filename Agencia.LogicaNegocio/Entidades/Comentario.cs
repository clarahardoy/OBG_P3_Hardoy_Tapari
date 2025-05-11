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
        public string _descripcion { get; set; }
        public DateTime _fecha { get; set; }
        public Usuario _empleadoAutor { get; set; }

        public Comentario(string descripcion, Usuario empleadoAutor)
        {
            _descripcion = descripcion;
            _fecha = DateTime.Now;
            _empleadoAutor = empleadoAutor;
        }

        public Comentario()
        {
            _fecha = DateTime.Now;
        }
    }
}