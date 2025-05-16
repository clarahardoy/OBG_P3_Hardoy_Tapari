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
            return _context.Envios.Include(e => e._cliente).Include(e => e._empleado).Include(e => e._seguimiento).Include(e => e._agenciaOrigen).ToList();
        }

        public Envio FindById(int id)
        {
            return _context.Envios.Include(e => e._cliente).Include(e => e._empleado).Include(e => e._seguimiento).Include(e => e._agenciaOrigen).Where(e => e.Id.Equals(id)).SingleOrDefault();
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
            return _context.Envios.Include(e => e._cliente).Include(e => e._empleado).Include(e => e._seguimiento).Include(e => e._agenciaOrigen).Where(e => e._estado == EstadoEnvio.EN_PROCESO).ToList();
        }


        public Envio FindByTrackingNumber(string nroTracking)
        {
            return _context.Envios.Include(e => e._cliente).Include(e => e._empleado).Include(e => e._seguimiento).Include(e => e._agenciaOrigen).Where(e => e._nroTracking == nroTracking).SingleOrDefault();
        }
    }
}
