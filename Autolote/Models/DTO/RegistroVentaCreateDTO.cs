using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Versioning;

namespace Autolote.Models.DTO
{
    public class RegistroVentaCreateDTO
    {
        public string CedulaId { get; set; }
        public int VehiculoId { get; set; }
        public string Capitalizacion { get; set; }
        public int AñosDelContrato { get; set; }
        public string TipoDePago { get; set; }


        public bool VerificarDatos()
        {
            if (CedulaId == "" || CedulaId == "string" || VehiculoId == 0 || Capitalizacion == "" || Capitalizacion == "string" 
                || CedulaId == null || Capitalizacion == null)
                return true;
            else
                return false;
        }
    }
}
