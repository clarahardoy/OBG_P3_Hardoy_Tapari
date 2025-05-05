using Agencia.DTOs.DTOs.EnvioDTO;
using Agencia.DTOs.DTOs.UsuarioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUAltaEnvio
    {
        void AltaEnvio (DTOAltaEnvio dto);
    }
}
