using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Autolote.Models
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int VehiculoId { get; set; }
        [Required]
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }
        public string Estado { get; set; }
        public int AñoFab { get; set; }
        public string Descripcion { get; set; }
        public byte[] Imagen { get; set; }
        public string Vendido { get; set; }
    }
}
