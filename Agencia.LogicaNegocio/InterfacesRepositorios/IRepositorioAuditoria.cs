using Agencia.LogicaNegocio.Entidades;

namespace Agencia.LogicaNegocio.InterfacesRepositorios;

public interface IRepositorioAuditoria
{ 
    void Auditar(Auditoria nueva);
    
}