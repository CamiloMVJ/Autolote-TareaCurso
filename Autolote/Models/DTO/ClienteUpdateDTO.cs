using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class ClienteUpdateDTO
    {
        [Required]
        public string CedulaId { get; set; }
        [Required]
        public string? NombreCliente { get; set; }
        [Required]
        public string? NumeroTelefono { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public string? Email { get; set; }
    }
}
