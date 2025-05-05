using Agencia.LogicaNegocio.Enumerados.UsuarioEnums;
using Agencia.LogicaNegocio.VO.UsuarioVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.DTOs.DTOs.UsuarioDTO
{
    public class DTOActualizarFuncionario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public RolUsuario Rol { get; set; }

        public int? LogueadoId { get; set; }
    }
}
