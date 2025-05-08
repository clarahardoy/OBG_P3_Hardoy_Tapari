using Agencia.LogicaNegocio.Entidades;
using Agencia.LogicaNegocio.Enumerados.EnvioEnums;
using Agencia.LogicaNegocio.VO.EnvioVO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agencia.DTOs.DTOs.EnvioDTO
{
    public class DTOMostrarEnvio
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [JsonIgnore]
        public int? LogueadoId { get; set; }

        [Display(Name = "Nro Tracking")]
        public string NroTracking { get; set; }

        public Usuario Empleado { get; set; }

        public Usuario Cliente { get; set; }

        public double Peso { get; set; }

        public string Estado { get; set; }

        [Display(Name = "Último comentario")]
        public string UltimoComentario { get; set; }

        [Display(Name = "Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Fecha Entrega")]
        public DateTime? FechaEntrega { get; set; }

        [Display(Name = "Agencia origen")]
        public Sucursal AgenciaOrigen { get; set; }

        //Común :
        public Sucursal? Destino { get; set; }

        //Urgente: 
        public Direccion? DireccionDestino { get; set; }
        public bool? EntregaEficiente { get; set; }
    }
}
