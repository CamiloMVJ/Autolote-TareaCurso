using System.ComponentModel.DataAnnotations;

namespace Autolote.Models.DTO
{
    public class ClienteCreateDTO
    {
        public string CedulaId { get; set; }
        [Required]
        public string? NombreCliente { get; set; }
        public string? NumeroTelefono { get; set; }
        public string? Direccion { get; set; }
        public string? Email {  get; set; }

        public bool VerificarDatos()
        {
            if (CedulaId == "" || CedulaId == "string" || NombreCliente == "" || NombreCliente == "string" || NumeroTelefono == "" || NumeroTelefono == "string" ||
                Direccion == "" || Direccion == "string" || Email == "" || Email == "string" || CedulaId == null || NombreCliente == null || NumeroTelefono == null || Direccion == null ||
                Direccion == null || Email == null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
