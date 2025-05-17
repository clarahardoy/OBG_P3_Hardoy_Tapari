using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using Agencia.LogicaNegocio.VO.UsuarioVO;
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
            return nuevo.Id;
        }

        public List<Usuario> FindAll()
        {
            return _context.Usuarios.ToList();
        }

        public List<Usuario> ListAllFuncionarios()
        {
            var r = RolUsuario.Funcionario;
            return _context.Usuarios.Where(x => x.Rol == r).ToList();
        }

        public Usuario FindByEmail(string email)
        {
            return _context.Usuarios.Where(x => x.Email == email).SingleOrDefault();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Remove(Usuario u)
        {
            _context.Remove(u);
            _context.SaveChanges();
        }

        public int Update(Usuario obj)
        {
            _context.Usuarios.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }
    }
}