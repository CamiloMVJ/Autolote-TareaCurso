using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autolote.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string CedulaId { get; set; }
        [Required]
        public string? NombreCliente { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }

    }
}
