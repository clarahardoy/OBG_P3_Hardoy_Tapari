using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.CustomException.UsuarioExceptions;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario;

public class CUAltaUsuario : ICUAltaUsuario
{
    private IRepositorioUsuario _repositorioUsuario;

    public CUAltaUsuario(IRepositorioUsuario repositorioUsuario)
    {
        _repositorioUsuario = repositorioUsuario;
    }

    public void AltaEmpleado(DTOAltaUsuario dto)
    {
        try
        {
            Usuario buscado = _repositorioUsuario.FindByEmail(dto.Email);
            if (buscado != null) throw new EmailYaExisteException("El email ingresado ya existe");

            Usuario nuevoUsuario = MapperUsuario.ToUsuario(dto);
            _repositorioUsuario.Add(nuevoUsuario);
        }
        catch (Exception ex)
        {
            Utilidades.Auditor.Auditar(null, "ALTA", "ERROR", null, null, null);
            throw ex;
        }
    }
}