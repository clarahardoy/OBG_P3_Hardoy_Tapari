using Agencia.DTOs.DTOs.UsuarioDTO;
using Agencia.DTOs.Mappers;
using Agencia.LogicaAplicacion.ICasosUso.ICUUsuario;
using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUObtenerFuncionarios : ICUObtenerFuncionarios
    {
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerFuncionarios(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public List<DTOUsuario> ListarFuncionarios()
        {
            List<Usuario> usuarios = _repoUsuario.ListAllFuncionarios();
            List<DTOUsuario> ret = MapperUsuario.FromListUsuario(usuarios);
            return ret;
        }
    }
}
