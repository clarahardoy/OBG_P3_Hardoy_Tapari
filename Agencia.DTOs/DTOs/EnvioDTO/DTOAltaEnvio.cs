﻿using Agencia.LogicaNegocio.Entidades;
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

        [Required]
        [Display(Name = "Email del Cliente")]
        [EmailAddress]
        public string ClienteEmail { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El Peso debe ser mayor a 0")]
        public double Peso { get; set; }

        [Required]
        [Display(Name = "Primer comentario")]
        public string PrimerComentario { get; set; }

        [Required]
        [Display(Name = "Agencia de origen")]
        public int AgenciaOrigenId { get; set; }

        // Envío Común :
        public int? AgenciaDestinoId { get; set; }

        // Envío urgente : 
        [Required]
        [Display(Name = "Calle")]
        public string? CalleDireccion { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public string? CiudadDireccion { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public string? DepartamentoDireccion { get; set; }

        [Required]
        [Display(Name = "Código postal")]
        public string? CodigoPostalDireccion { get; set; }
    }
}
