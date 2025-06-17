using Agencia.DTOs.DTOs.UsuarioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUUsuario
{
    public interface ICUObtenerUsuario
    {
        DTOUsuario Ejecutar(int id);

        public DTOActualizarFuncionario ObtenerFuncionario(int id);
    }
}
