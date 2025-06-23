using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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