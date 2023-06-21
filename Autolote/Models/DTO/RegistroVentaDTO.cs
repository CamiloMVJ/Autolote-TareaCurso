using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class RegistroVentaDTO
    {
        public int RegistroId { get; set; }
        [Required]
        public string? ClienteNombre { get; set; }
        public string? CedulaId { get; set; }
        public string? VehiculoId { get; set; }
        public decimal? Monto { get; set; }
        public decimal? Cuota { get; set; }
        public string? Capitalizacion { get; set; }
        public decimal TasaInteres { get; set; }
        public int AñosDelContrato { get; set; }
        public string TipoDePago { get; set; }

    }
}
