using Agencia.DTOs.DTOs.EnvioDTO;

namespace AgenciaEnviosWebApp.Models;

public class AgregarSeguimientoModel
{
    public DTOMostrarEnvio dtoEnvio  { get;  set;   }
    public DTOAgregarSeguimiento dtoAgregarSeguimiento { get; set; }
}