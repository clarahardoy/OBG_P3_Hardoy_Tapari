using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;

namespace Agencia.DTOs.Mappers;

public class MapperUsuario
{
    public static Usuario ToUsuario(DTOAltaUsuario dto)
    {
        var rol = RolUsuario.Funcionario;
        if (dto.Rol.Equals(2)) rol = RolUsuario.Cliente; 
        if (dto.Rol.Equals(1)) rol = RolUsuario.Funcionario;
        string passHashed = Utilidades.Crypto.HashPasswordConBcrypt(dto.Password, 12);


        Usuario ret = new Usuario(new NombreCompleto(dto.Nombre,dto.Apellido),dto.Email,passHashed,rol);

        return ret;
    }
}