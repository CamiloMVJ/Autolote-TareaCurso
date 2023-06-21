using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class VehiculoUpdateDTO
    {
        [Required]
        public int VehiculoId { get; set; }
        [Required]
        public string Marca { get; set; }
        [Required]
        public double Precio { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public int AñoFab { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Vendido { get; set; }
        public byte[] Imagen { get; set; }


    }
}
