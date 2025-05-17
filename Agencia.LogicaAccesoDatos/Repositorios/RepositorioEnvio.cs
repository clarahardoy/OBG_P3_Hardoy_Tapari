using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Microsoft.EntityFrameworkCore;

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
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.Seguimiento).Include(e => e.AgenciaOrigen).ToList();
        }

        public Envio FindById(int id)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.Seguimiento).Include(e => e.AgenciaOrigen).Where(e => e.Id.Equals(id)).SingleOrDefault();
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

        public List<Envio> ObtenerEnviosEnProceso()
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.Seguimiento).Include(e => e.AgenciaOrigen).Where(e => e.Estado == EstadoEnvio.EN_PROCESO).ToList();
        }


        public Envio FindByTrackingNumber(string nroTracking)
        {
            return _context.Envios.Include(e => e.Cliente).Include(e => e.Empleado).Include(e => e.Seguimiento).Include(e => e.AgenciaOrigen).Where(e => e.NroTracking == nroTracking).SingleOrDefault();
        }
    }
}
