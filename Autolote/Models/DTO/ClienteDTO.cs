using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class ClienteDTO
    {
        public string CedulaId { get; set; }
        [Required]
        public string? NombreCliente { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? Direccion { get; set; }
        public string? Email { get; set; }

    }
}
