using Autolote.Models;
using Autolote.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSistemaAutos
{
    public partial class frmCredito : Form
    {
        bool BtonCalcular = false;
        Cliente clienteCompra = new Cliente();
        int vehicleId = 0;
        VehiculoDTO VehiculoDTO = new VehiculoDTO();
        public frmCredito()
        {
            InitializeComponent();
        }

        private void btnRegresaPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Validacion(object sender, CancelEventArgs e)
        {
            if (txtCedula.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtDireccion.Text.Trim() == "" || txtGmail.Text.Trim() == "" || mtTelefono.Text.Trim() == "")
            {
                btnRegistrar.Enabled = false;
            }
            else if (cboCapitalizacion.Text.Trim() != "" && cboAñosCapitalizacion.Text.Trim() != "" && BtonCalcular)
            {
                btnRegistrar.Enabled = true;
            }
            else
            {
                btnRegistrar.Enabled = false;
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            // Tasas definidas
            decimal tasaTresAños = 0.15m;
            decimal tasaCincoAños = 0.10m;
            decimal tasaSeisAños = 0.08m;

            if (cboAñosCapitalizacion.SelectedIndex == 0)
            {
                txtTasa.Text = tasaTresAños.ToString() + " %";
                int capitalizacion = PagosAnuales(cboCapitalizacion.Text);
                int n = capitalizacion * 3;
                double tasaEfectiva = Convert.ToDouble(tasaTresAños / capitalizacion);
                decimal numerador = Convert.ToDecimal(tasaEfectiva * (Math.Pow(1 + tasaEfectiva, n)));
                decimal denominador = Convert.ToDecimal(Math.Pow(1 + tasaEfectiva, n) - 1);
                decimal valorCarro = 0;
                var precio = lblPrecioShow.Text.Split(' ');
                valorCarro = decimal.Parse(precio[1]);
                decimal cuota = valorCarro * numerador / denominador;
                //Restringiendo a cuatro decimales
                decimal c = Math.Round(cuota, 4);
                txtCuota.Text = "$ " + c.ToString();

            }
            else if (cboAñosCapitalizacion.SelectedIndex == 1)
            {
                txtTasa.Text = tasaCincoAños.ToString() + " %";
                int capitalizacion = PagosAnuales(cboCapitalizacion.Text);
                int n = capitalizacion * 5;
                double tasaEfectiva = Convert.ToDouble(tasaCincoAños / capitalizacion);
                decimal numerador = Convert.ToDecimal(tasaEfectiva * (Math.Pow(1 + tasaEfectiva, n)));
                decimal denominador = Convert.ToDecimal(Math.Pow(1 + tasaEfectiva, n) - 1);
                decimal valorCarro = 0;
                var precio = lblPrecioShow.Text.Split(' ');
                valorCarro = decimal.Parse(precio[1]);
                decimal cuota = valorCarro * numerador / denominador;
                //Restringiendo a cuatro decimales
                decimal c = Math.Round(cuota, 4);
                txtCuota.Text = "$ " + c.ToString();

            }
            else if (cboAñosCapitalizacion.SelectedIndex == 2)
            {
                txtTasa.Text = tasaSeisAños.ToString() + " %";
                int capitalizacion = PagosAnuales(cboCapitalizacion.Text);
                int n = capitalizacion * 6;
                double tasaEfectiva = Convert.ToDouble(tasaSeisAños / capitalizacion);
                decimal numerador = Convert.ToDecimal(tasaEfectiva * (Math.Pow(1 + tasaEfectiva, n)));
                decimal denominador = Convert.ToDecimal(Math.Pow(1 + tasaEfectiva, n) - 1);
                decimal valorCarro = 0;
                var precio = lblPrecioShow.Text.Split(' ');
                valorCarro = decimal.Parse(precio[1]);
                decimal cuota = valorCarro * numerador / denominador;
                //Restringiendo a cuatro decimales
                decimal c = Math.Round(cuota, 4);
                txtCuota.Text = "$ " + c.ToString();
            }
            BtonCalcular = true;
            CancelEventArgs ex = new CancelEventArgs();
            Validacion(sender, ex);
        }
        private int PagosAnuales(string cap)
        {
            switch (cap)
            {
                case "Mensual":
                    return 12;
                case "Bimestral":
                    return 6;
                case "Trimestral":
                    return 4;
            }
            return 0;
        }

        private void cboAñosCapitalizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtonCalcular = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clienteCompra.CedulaId = txtCedula.Text;
            clienteCompra.Email = txtGmail.Text;
            clienteCompra.NombreCliente = txtNombre.Text;
            clienteCompra.NumeroTelefono = mtTelefono.Text;
            clienteCompra.Direccion = txtDireccion.Text;
            RegistrarPagoAsync();
        }

        private async void RegistrarPagoAsync()
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    var ClienteSerializado = JsonConvert.SerializeObject(clienteCompra);
                    var Datos = new StringContent(ClienteSerializado, Encoding.UTF8, "application/json");
                    var Respuesta = await cliente.PostAsync("https://localhost:7166/api/Cliente", Datos);
                    if (Respuesta.IsSuccessStatusCode)
                    {

                    }
                    else
                        MessageBox.Show($"Ha ocurrido un error al momento de agregar el cliente: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("No se han llenado todos los datos del cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            RegistroVentaCreateDTO Venta = new RegistroVentaCreateDTO();
            Venta.CedulaId = clienteCompra.CedulaId;
            Venta.VehiculoId = vehicleId;
            Venta.TipoDePago = "Credito";
            Venta.Capitalizacion = cboCapitalizacion.Text;
            var años = cboAñosCapitalizacion.Text.Split(' ');
            Venta.AñosDelContrato = int.Parse(años[0]);

            using (var cliente = new HttpClient())
            {

                var RegistroSerializado = JsonConvert.SerializeObject(Venta);
                var Datos = new StringContent(RegistroSerializado, Encoding.UTF8, "application/json");
                var Respuesta = await cliente.PostAsync("https://localhost:7166/api/RegistroVenta", Datos);

                if (Respuesta.IsSuccessStatusCode)
                {

                    using (var client = new HttpClient())
                    {
                        var response = await client.GetAsync(String.Format("{0}/{1}",
                            "https://localhost:7166/api/Vehiculo", vehicleId));
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            VehiculoDTO vehiculoDTO = JsonConvert.DeserializeObject<VehiculoDTO>(data);
                            VehiculoDTO = vehiculoDTO;

                        }
                        else
                        {
                            MessageBox.Show($"No se puede obtener el Vehiculo: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    using (var conexion = new HttpClient())
                    {
                        VehiculoUpdateDTO vehiculoUpdate = new VehiculoUpdateDTO()
                        {
                            VehiculoId = VehiculoDTO.VehiculoId,
                            AñoFab = VehiculoDTO.AñoFab,
                            Descripcion = VehiculoDTO.Descripcion,
                            Vendido = "Si",
                            Marca = VehiculoDTO.Marca,
                            Estado = VehiculoDTO.Estado,
                            Imagen = VehiculoDTO.Imagen,
                            Modelo = VehiculoDTO.Modelo,
                            Precio = VehiculoDTO.Precio,
                        };

                        var coche = JsonConvert.SerializeObject(vehiculoUpdate);
                        var content = new StringContent(coche, Encoding.UTF8, "application/json");
                        var response = await conexion.PutAsync(String.Format("{0}={1}", "https://localhost:7166/api/Vehiculo?id", vehiculoUpdate.VehiculoId), content);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Se ha comprado el vehiculo con exito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show($"Ha ocurrido un error: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmCredito_Load(object sender, EventArgs e)
        {
            vehicleId = int.Parse(lblId.Text);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CancelEventArgs ex = new CancelEventArgs();
            Validacion(sender, ex);
        }
    }
}
