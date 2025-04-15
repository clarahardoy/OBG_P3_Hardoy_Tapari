using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAccesoDatos.Repositorios
{
    public class RepositorioEnvio : IRepositorioEnvio
    {
        private ApplicationDbContext _context;
        public RepositorioEnvio(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Add(Envio nuevo)
        {
            _context.Envios.Add(nuevo);
            _context.SaveChanges();
            return nuevo.Id;
        }

        public List<Envio> FindAll()
        {
            return _context.Envios.ToList();
        }

        public Envio FindById(int id)
        {
            return _context.Envios.Find(id);
        }

        public void Remove(Envio e)
        {
            _context.Remove(e);
            _context.SaveChanges();
        }

        public int Update(Envio obj)
        {
            _context.Envios.Update(obj);
            _context.SaveChanges();
            return obj.Id;
        }
    }
}
