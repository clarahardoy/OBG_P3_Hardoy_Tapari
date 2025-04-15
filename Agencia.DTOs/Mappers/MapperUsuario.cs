using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System.Data;

namespace Agencia.DTOs.Mappers;

public class MapperUsuario
{
    public static Usuario FromDtoUsuarioToUsuario(DTOUsuario dto)
    {
        Usuario nuevo = new Usuario();
        nuevo.Id = (int)dto.Id;
        nuevo._nombreCompleto = new NombreCompleto(dto.Nombre, dto.Apellido);
        nuevo._email = dto.Email;
        nuevo._password = dto.Password;

        var rol = dto.Rol;
        if (dto.Rol.Equals(2)) rol = RolUsuario.Cliente;
        if (dto.Rol.Equals(1)) rol = RolUsuario.Funcionario;
        if (dto.Rol.Equals(0)) rol = RolUsuario.Administrador;
        nuevo._rol = rol;

        return nuevo;
    }

    public static List<DTOUsuario> FromListUsuarioToListDto(List<Usuario> usuarios)
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
            ret.Add(dto);
        }
        return ret;
    }

    public static DTOUsuario FromUsuarioToDto(Usuario u)
    {
        DTOUsuario dto = new DTOUsuario();
        dto.Id = u.Id;
        dto.Nombre = u._nombreCompleto._nombre;
        dto.Apellido = u._nombreCompleto._apellido;
        dto.Email = u._email;
        dto.Password = u._password;
        dto.Rol = u._rol;
        return dto;
    }

    public static Usuario ToUsuario(DTOAltaUsuario dto)
    {
        var rol = dto.Rol;
        if (dto.Rol.Equals(2)) rol = RolUsuario.Cliente;
        if (dto.Rol.Equals(1)) rol = RolUsuario.Funcionario;
        if (dto.Rol.Equals(0)) rol = RolUsuario.Administrador;
        string passHashed = Utilidades.Crypto.HashPasswordConBcrypt(dto.Password, 12);

        Usuario ret = new Usuario(new NombreCompleto(dto.Nombre, dto.Apellido), dto.Email, passHashed, rol);

        return ret;
    }
}