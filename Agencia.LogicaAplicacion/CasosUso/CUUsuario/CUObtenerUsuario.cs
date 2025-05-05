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
    public class CUObtenerUsuario : ICUObtenerUsuario
    {
        private IRepositorioUsuario _repoUsuario;

        public CUObtenerUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public DTOUsuario ObtenerUsuario(int id)
        {
            Usuario u = _repoUsuario.FindById(id);
            return MapperUsuario.ToDtoUsuario(u);
        }

        public DTOActualizarFuncionario ObtenerFuncionario(int id)
        {
            Usuario funcionario = _repoUsuario.FindById(id);
            return MapperUsuario.ToDtoActualizarFuncionario(funcionario);
        }
    }
}
