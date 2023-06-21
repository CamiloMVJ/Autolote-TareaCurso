using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class VehiculoDTO
    {

        public int VehiculoId { get; set; }
        [Required]
        public string Marca { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public string Modelo { get; set; }
        public int AñoFab { get; set; }
        public string Descripcion { get; set; }
        public string Vendido { get; set; }
        public byte[] Imagen { get; set; }

    }
}
