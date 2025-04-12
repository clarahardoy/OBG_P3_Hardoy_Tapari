using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private ApplicationDbContext _context;
        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Usuario nuevo)
        {
            _context.Usuarios.Add(nuevo);
            _context.SaveChanges();
            return nuevo._id;
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList(); 
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Where(x => x._email == email).SingleOrDefault();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Remove(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public int Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
