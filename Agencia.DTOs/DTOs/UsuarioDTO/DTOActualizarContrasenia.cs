using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agencia.DTOs.DTOs.UsuarioDTO
{
    public class DTOActualizarContrasenia
    {
        [JsonIgnore]
        public string Email { get; set; }

        [Required]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "La longitud debe estar entre 8 y 32 caracteres")]
        public string NewPassword { get; set; }
    }
}