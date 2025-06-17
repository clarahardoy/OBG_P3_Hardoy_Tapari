using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAccesoDatos.Repositorios
{
    public class RepositorioComentario : IRepositorioComentario
    {
        private ApplicationDbContext _context;
        public RepositorioComentario(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Add(Comentario nuevo)
        {
            _context.Comentarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Comentario> FindAll()
        {
            return _context.Comentarios
                .Include(c => c.EmpleadoAutor)
                .ThenInclude(e => e.NombreCompleto)
                .ToList();
        }

        public Comentario FindById(int id)
        {
            return _context.Comentarios.Find(id);
        }

        public void Remove(Comentario c)
        {
            _context.Remove(c);
            _context.SaveChanges();
        }

        public int Update(Comentario unComentario)
        {
            _context.Comentarios.Update(unComentario);
            _context.SaveChanges();
            return unComentario.Id;
        }
    }
}
