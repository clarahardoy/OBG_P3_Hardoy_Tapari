using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agencia.DTOs.DTOs.EnvioDTO
{
    public class DTOAltaEnvio
    {
        public string TipoEnvio { get; set; }

        public int Id { get; set; }

        public int? LogueadoId { get; set; }

        [Display(Name = "Email del Cliente")]
        [EmailAddress]
        public string ClienteEmail { get; set; }

        public double Peso { get; set; }

        [Display(Name = "Primer comentario")]
        public string PrimerComentario { get; set; }

        [Display(Name = "Agencia de origen")]
        public int AgenciaOrigenId { get; set; }

        // Envío Común :
        public int? AgenciaDestinoId { get; set; }

        // Envío urgente : 
        [Display(Name = "Calle")]
        public string? CalleDireccion { get; set; }

        [Display(Name = "Ciudad")]
        public string? CiudadDireccion { get; set; }

        [Display(Name = "Departamento")]
        public string? DepartamentoDireccion { get; set; }

        [Display(Name = "Código postal")]
        public string? CodigoPostalDireccion { get; set; }
    }
}
