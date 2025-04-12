using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaNegocio.Entidades
{
    public class Comentario
    {
        public int _id { get; set; }
        private string _descripcion { get; set; }
        private DateTime _fecha { get; set; }
        private Usuario _empleadoAutor { get; set; }

        public Comentario(string descripcion, DateTime fecha, Usuario empleadoAutor)
        {
            _descripcion = descripcion;
            _fecha = fecha;
            _empleadoAutor = empleadoAutor;
        }

        public Comentario() { }
    }
}