using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAccesoDatos.Repositorios
{
    public class RepositorioSucursal : IRepositorioSucursal
    {
        private ApplicationDbContext _context;
        public RepositorioSucursal(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Sucursal nuevo)
        {
            _context.Sucursales.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Sucursal> FindAll()
        {
            return _context.Sucursales.ToList();
        }

        public Sucursal FindById(int id)
        {
            return _context.Sucursales.Find(id);
        }

        public void Remove(Sucursal obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();
        }

        public int Update(Sucursal obj)
        {
            _context.Sucursales.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public List<Sucursal> ListAllSucursales()
        {
            return _context.Sucursales.ToList();
        }
    }
}
