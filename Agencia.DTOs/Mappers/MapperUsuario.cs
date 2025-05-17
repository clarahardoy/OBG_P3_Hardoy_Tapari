using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System.Data;

namespace Agencia.DTOs.Mappers;

public class MapperUsuario
{
    // Mapper Actualizar:
    public static DTOActualizarFuncionario ToDtoActualizarFuncionario(Usuario usuario)
    {
        DTOActualizarFuncionario dto = new DTOActualizarFuncionario();
        dto.Id = (int)usuario.Id;
        dto.Nombre = usuario.NombreCompleto.Nombre;
        dto.Apellido = usuario.NombreCompleto.Apellido;
        dto.Email = usuario.Email;

        var rol = dto.Rol;
        if (usuario.Rol.Equals(2)) rol = RolUsuario.Cliente.ToString();
        if (usuario.Rol.Equals(1)) rol = RolUsuario.Funcionario.ToString();
        if (usuario.Rol.Equals(0)) rol = RolUsuario.Administrador.ToString();
        dto.Rol = rol;

        return dto;
    }

    // Mapper Alta:
    public static Usuario FromDtoAltaUsuario(DTOAltaUsuario dto)
    {
        RolUsuario rol = (RolUsuario)Enum.Parse(typeof(RolUsuario), dto.Rol);
        string passHashed = Utilidades.Crypto.HashPasswordConBcrypt(dto.Password, 12);

        Usuario ret = new Usuario(new NombreCompleto(dto.Nombre, dto.Apellido),
                                    dto.Email, passHashed, rol);

        return ret;
    }

    // Mapper Lista
    public static List<DTOUsuario> FromListUsuario(List<Usuario> usuarios)
    {
        List<DTOUsuario> ret = new List<DTOUsuario>();

        foreach (Usuario unUsuario in usuarios)
        {
            DTOUsuario dto = ToDtoUsuario(unUsuario);
            if (unUsuario.Activo == true) ret.Add(dto);
        }
        return ret;
    }

    // Mappers Generales: 
    public static DTOUsuario ToDtoUsuario(Usuario u)
    {
        DTOUsuario dto = new DTOUsuario();
        dto.Id = u.Id;
        dto.Nombre = u.NombreCompleto.Nombre;
        dto.Apellido = u.NombreCompleto.Apellido;
        dto.Email = u.Email;
        dto.Password = u.Password;
        dto.Rol = u.Rol.ToString();
        dto.Activo = u.Activo;
        return dto;
    }

    public static Usuario ToUsuario(DTOUsuario dto)
    {
        Usuario u = new Usuario();
        u.Id = (int)dto.Id;
        u.NombreCompleto = new NombreCompleto(dto.Nombre, dto.Apellido);
        u.Email = dto.Email;
        u.Password = dto.Password;
        u.Rol = (RolUsuario)Enum.Parse(typeof(RolUsuario), dto.Rol);
        u.Activo = dto.Activo;
        return u;
    }
}