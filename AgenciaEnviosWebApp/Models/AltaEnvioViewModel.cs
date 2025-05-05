using Agencia.DTOs.DTOs.EnvioDTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgenciaEnviosWebApp.Models
{
    public class AltaEnvioViewModel
    {
        public DTOAltaEnvio Dto { get; set; }

        public List<SelectListItem> TiposEnvio { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Envío Urgente", Value = "urgente" },
            new SelectListItem { Text = "Envío Común", Value = "comun" }
        };

        public List<SelectListItem> EstadoEnvio { get; set; } = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Envío Urgente", Value = "urgente" },
            new SelectListItem { Text = "Envío Común", Value = "comun" }
        };

        public List<SelectListItem> AgenciasDisponibles { get; set; } = new List<SelectListItem>();
    }
}
