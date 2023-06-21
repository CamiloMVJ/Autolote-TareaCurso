namespace Autolote.Models.DTO
{
    public class VehiculoCreateDTO
    {
        public string Marca { get; set; }
        public double Precio { get; set; }
        public string Estado { get; set; }
        public int AñoFab { get; set; }
        public string Modelo { get; set; }
        public string Descripcion { get; set; }
        public string Vendido { get; set; }
        public byte[] Imagen { get; set; }


        public bool VerificarDatos()
        {
            if (Marca == "" || Marca == "string" || Estado == "" || Estado == "string"  || Descripcion == "" || Descripcion == "string" ||
                Marca == null || Estado == null || Descripcion == null || Precio == 0 || AñoFab == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
