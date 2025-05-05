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
        dto.Nombre = usuario._nombreCompleto._nombre;
        dto.Apellido = usuario._nombreCompleto._apellido;
        dto.Email = usuario._email;

        var rol = dto.Rol;
        if (usuario._rol.Equals(2)) rol = RolUsuario.Cliente;
        if (usuario._rol.Equals(1)) rol = RolUsuario.Funcionario;
        if (usuario._rol.Equals(0)) rol = RolUsuario.Administrador;
        dto.Rol = rol;

        return dto;
    }

    // Mapper Alta:
    public static Usuario FromDtoAltaUsuario(DTOAltaUsuario dto)
    {
        var rol = dto.Rol;
        if (dto.Rol.Equals(2)) rol = RolUsuario.Cliente;
        if (dto.Rol.Equals(1)) rol = RolUsuario.Funcionario;
        if (dto.Rol.Equals(0)) rol = RolUsuario.Administrador;
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
            DTOUsuario dto = new DTOUsuario();
            dto.Id = unUsuario.Id;
            dto.Nombre = unUsuario._nombreCompleto._nombre;
            dto.Apellido = unUsuario._nombreCompleto._apellido;
            dto.Email = unUsuario._email;
            dto.Rol = unUsuario._rol;
            if(unUsuario._activo == true) ret.Add(dto);
        }
        return ret;
    }

    // Mappers Generales: 
    public static DTOUsuario ToDtoUsuario(Usuario u)
    {
        DTOUsuario dto = new DTOUsuario();
        dto.Id = u.Id;
        dto.Nombre = u._nombreCompleto._nombre;
        dto.Apellido = u._nombreCompleto._apellido;
        dto.Email = u._email;
        dto.Password = u._password;
        dto.Rol = u._rol;
        dto.Activo = u._activo;
        return dto;
    }

    public static Usuario ToUsuario(DTOUsuario dto)
    {
        Usuario u = new Usuario();
        u.Id = (int)dto.Id;
        u._nombreCompleto = new NombreCompleto( dto.Nombre, dto.Apellido );
        u._email = dto.Email;
        u._password = dto.Password;
        u._rol = dto.Rol;
        u._activo = dto.Activo;
        return u;
    }
}