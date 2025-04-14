﻿using Agencia.LogicaNegocio.Entidades;
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

        public void Remove(int id)
        {
            _context.Remove(id);
            _context.SaveChanges();
        }

        public int Update(Envio unEnvio)
        {
            _context.Comentarios.Update(unEnvio);
            _context.SaveChanges();
            return unEnvio.Id;
        }
    }
}
