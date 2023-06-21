using Autolote.Models;
using Autolote.Models.DTO;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text;

namespace ProyectoSistemaAutos
{
    public partial class frmDebito : Form
    {
        Cliente clienteCompra = new Cliente();
        int vehicleId = 0;
        VehiculoDTO VehiculoDTO = new VehiculoDTO();
        public frmDebito()
        {
            InitializeComponent();

        }
        //Botón regresar (Regresa al formulario principal)
        private void btnRegresaPrincipal_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void rbEfectivo_CheckedChanged(object sender, EventArgs e)
        {
            gbPagoEfectivo.Visible = true;
            gbPagoTarjeta.Visible = false;
        }

        private void rbTarjeta_CheckedChanged(object sender, EventArgs e)
        {
            gbPagoTarjeta.Visible = true;
            gbPagoEfectivo.Visible = false;

        }

        private void Validacion(object sender, CancelEventArgs e)
        {
            if (txtCedula.Text.Trim() == "" || txtNombre.Text.Trim() == "" || txtDireccion.Text.Trim() == "" || txtGmail.Text.Trim() == "" || mtTelefono.Text.Trim() == "")
            {
                btnPagar.Enabled = false;
                btnPagar2.Enabled = false;
            }
            else if (rbEfectivo.Checked)
            {
                if (txtMontoEfectivoPagado.Text == txtCuota.Text)
                {
                    btnPagar.Enabled = true;
                    btnPagar2.Enabled = true;
                    Error.Clear();
                }
                else
                {
                    Error.SetError(txtMontoEfectivoPagado, "El monto no coincide con el total a pagar");
                    btnPagar.Enabled = false;
                    btnPagar2.Enabled = false;
                }
            }
            else if (rbTarjeta.Checked)
            {
                if (mtNumeroTarjetaa.Text.Trim() != "" && mtFechaVencimiento.Text.Trim() != "" && mtCVV.Text.Trim() != "")
                {
                    btnPagar.Enabled = true;
                    btnPagar2.Enabled = true;

                }
            }

        }

        private void frmDebito_Load(object sender, EventArgs e)
        {
            var precio = lblPrecioShow.Text.Split(' ');
            txtCuota.Text = precio[1];
            vehicleId = Convert.ToInt16(lblId.Text);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            decimal PrecioCarro = 0;
            var precio = lblPrecioShow.Text.Split(" ");
            PrecioCarro = Convert.ToDecimal(precio[1]);
            decimal EfectivoPago = decimal.Parse(txtCuota.Text);

            if (rbEfectivo.Checked)
            {
                if (PrecioCarro <= EfectivoPago)
                {
                    clienteCompra.CedulaId = txtCedula.Text;
                    clienteCompra.Email = txtGmail.Text;
                    clienteCompra.NombreCliente = txtNombre.Text;
                    clienteCompra.NumeroTelefono = mtTelefono.Text;
                    clienteCompra.Direccion = txtDireccion.Text;

                }
                else
                {
                    MessageBox.Show("El efectivo no es suficiente");
                }
            }
            else if (rbTarjeta.Checked)
            {
                MessageBox.Show("Pago Efectuado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
                        MessageBox.Show($"Ha ocurrido un error al momento de agregar el cliente: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("No se han llenado todos los datos del cliente", "Error", MessageBoxButtons.OK);
            }

            RegistroVentaCreateDTO Venta = new RegistroVentaCreateDTO();
            Venta.CedulaId = clienteCompra.CedulaId;
            Venta.VehiculoId = vehicleId;
            Venta.TipoDePago = "Contado";
            Venta.Capitalizacion = "No aplica";
            Venta.AñosDelContrato = 0;

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
                            MessageBox.Show($"No se puede obtener el Vehiculo: {response.StatusCode}");
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
                    MessageBox.Show($"Ha ocurrido un error: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}");

            }

        }

        private void Limpiar()
        {
            foreach (var obj in gbDatosCliente.Controls.OfType<TextBox>())
            {
                obj.Text = String.Empty;
            }
            clienteCompra = new Cliente();
            vehicleId = 0;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            RegistrarPagoAsync();
        }

        private void btnPagar2_Click(object sender, EventArgs e)
        {
            decimal PrecioCarro = 0;
            var precio = lblPrecioShow.Text.Split(" ");
            PrecioCarro = Convert.ToDecimal(precio[1]);
            decimal EfectivoPago = decimal.Parse(txtCuota.Text);

            if (rbEfectivo.Checked)
            {
                if (PrecioCarro <= EfectivoPago)
                {
                    clienteCompra.CedulaId = txtCedula.Text;
                    clienteCompra.Email = txtGmail.Text;
                    clienteCompra.NombreCliente = txtNombre.Text;
                    clienteCompra.NumeroTelefono = mtTelefono.Text;
                    clienteCompra.Direccion = txtDireccion.Text;
                    MessageBox.Show("Pago Realizado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El efectivo no es suficiente");
                }
            }
            else if (rbTarjeta.Checked)
            {
                MessageBox.Show("Pago Efectuado correctamente", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
