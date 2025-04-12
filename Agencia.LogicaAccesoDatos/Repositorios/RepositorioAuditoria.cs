using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAccesoDatos.Repositorios;

public class RepositorioAuditoria : IRepositorioAuditoria
{
    private ApplicationDbContext _context;
    public RepositorioAuditoria(ApplicationDbContext context)
    {
        _context = context;
    }
    public void Auditar(Auditoria nueva)
    {
        _context.Auditorias.Add(nueva);  
        _context.SaveChanges();
    }
}
