using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Transactions;

namespace Autolote.Models
{
    public class RegistroVenta
    {
        private decimal tasaTresAños = 0.15m;
        private decimal tasaCincoAños = 0.10m;
        private decimal tasaSeisAños = 0.08m;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int RegistroId { get; set; }
        [Required]

        [ForeignKey("CedulaId")]
        public Cliente? Cliente { get; set; }
        public string? ClienteNombre { get; set; }
        public string CedulaId { get; set; }
        [ForeignKey("VehiculoId")]
        public Vehiculo? Carro { get; set; }
        public int VehiculoId { get; set; }
        public decimal Monto { get; set; }
        public string TipoDePago { get; set; }
        public decimal Cuota { get; set; }
        public string Capitalizacion { get; set; }
        public decimal TasaInteres { get; set; }
        public int AñosDelContrato { get; set; }

        public RegistroVenta() { }
        public RegistroVenta(Cliente cliente, Vehiculo vehiculo, string capitalizacion, int añoscontrato, string pago)
        {
            Cliente = cliente;
            ClienteNombre = cliente.NombreCliente;
            CedulaId = cliente.CedulaId;
            Carro = vehiculo;
            VehiculoId = vehiculo.VehiculoId;
            Monto = vehiculo.Precio;
            Capitalizacion = capitalizacion;
            AñosDelContrato = añoscontrato;
            TipoDePago = pago;
        }

        public void CalcularCouta()
        {
            if (AñosDelContrato == 3)
                TasaInteres = tasaTresAños;
            if (AñosDelContrato == 5)
                TasaInteres = tasaCincoAños;
            if (AñosDelContrato == 6)
                TasaInteres = tasaSeisAños;

            if (TipoDePago == "Credito")
            {
                int capitalizacion = CalcularPagosAnules();
                int n = capitalizacion * AñosDelContrato;
                double tasaEfectiva = Convert.ToDouble(tasaTresAños / capitalizacion);
                decimal numerador = Convert.ToDecimal(tasaEfectiva * (Math.Pow(1 + tasaEfectiva, n)));
                decimal denominador = Convert.ToDecimal(Math.Pow(1 + tasaEfectiva, n) - 1);
                decimal valorCarro = 0;
                valorCarro = Monto;
                decimal cuota = valorCarro * numerador / denominador;
                Cuota = Math.Round(cuota, 4);
            }
        }

        private int CalcularPagosAnules()
        {
            switch (Capitalizacion)
            {
                case "Mensual":
                    return 12;
                case "Bimestral":
                    return 6;
                case "Trimestral":
                    return 4;
                default: return 0;
            }
        }

        public bool VerificarDatos()
        {
            if (CedulaId == "" || CedulaId == "string" || VehiculoId == 0 || Capitalizacion == "" || Capitalizacion == "string" || AñosDelContrato == 0
                || CedulaId == null || Capitalizacion == null)
                return true;
            else
                return false;
        }
    }
}
