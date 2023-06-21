using Autolote.Data;
using Autolote.Models;
using Autolote.Models.DTO;
using Guna.UI2.WinForms;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ProyectoSistemaAutos
{
    public partial class frmPrincipal : Form
    {
        private int vehiculoId = 0;
        byte[] datosImagen;
        string cedulaCliente = "";
        public frmPrincipal()
        {
            InitializeComponent();


        }

        //Boton que muestra la pagina del Inventario de Vehiculos
        private void btnCRUDInventario_Click(object sender, EventArgs e)
        {
            tpInventario.Select();
            tcPrincipal.SelectedIndex = 0;
            GetCatalogoAsync();


        }

        private void btnCatalogoVehiculos_Click(object sender, EventArgs e)
        {
            tpCatalogo.Select();
            tcPrincipal.SelectedIndex = 1;
            GetAllCarsAsycn();
        }

        private void btnRegistroClientes_Click(object sender, EventArgs e)
        {
            tpRegistroClientes.Select();
            tcPrincipal.SelectedIndex = 2;
            GetClientesAsync();

        }

        private void btnRegistroVentas_Click(object sender, EventArgs e)
        {
            tpRegistroVentas.Select();
            tcPrincipal.SelectedIndex = 3;
            GetRegistrosAsync();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GetCatalogoAsync();
        }

        private async void GetCatalogoAsync()
        {
            flpCatalogo.Controls.Clear();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7166/api/Vehiculo"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var cars = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<VehiculoDTO>>(cars);
                        foreach (var obj in result)
                        {
                            if (obj.Vendido == "No")
                            {
                                VehicleItem control = new VehicleItem();
                                control.Precio = "$ " + obj.Precio.ToString();
                                control.AñoFabricacion = obj.AñoFab.ToString();
                                control.EstadodelVehiculo = obj.Estado.ToString();
                                control.Marca = obj.Marca.ToString();
                                control.Id = obj.VehiculoId.ToString();
                                MemoryStream ms = new MemoryStream(obj.Imagen);
                                control.ImagenVehiculo = Image.FromStream(ms);
                                if (obj.Descripcion.Length > 40)
                                {
                                    int cicle = 0;
                                    string[] descripciones = new string[3];
                                    var descrip = obj.Descripcion.Split(' ');
                                    for (int i = 0; i < descrip.Count(); i++)
                                    {
                                        if (cicle > 2)
                                            break;
                                        descripciones[cicle] = descripciones[cicle] + " " + descrip[i];
                                        if (descripciones[cicle].Length >= 40)
                                            cicle++;
                                    }
                                    control.DescripcionVehiculo = descripciones[0];
                                    control.DescripcionVehiculo2 = descripciones[1];
                                    control.DescripcionVehiculo3 = descripciones[2];
                                }
                                else
                                {
                                    control.DescripcionVehiculo = obj.Descripcion;
                                    control.DescripcionVehiculo2 = string.Empty;
                                    control.DescripcionVehiculo3 = string.Empty;
                                }
                                flpCatalogo.Controls.Add(control);
                            }
                        }
                    }
                }
            }
        }
        private void tcPrincipal_Selected(object sender, TabControlEventArgs e)
        {
            if (tcPrincipal.SelectedIndex == 0)
                GetCatalogoAsync();
            if (tcPrincipal.SelectedIndex == 1)
                GetAllCarsAsycn();
            if (tcPrincipal.SelectedIndex == 3)
                GetRegistrosAsync();
            if (tcPrincipal.SelectedIndex == 2)
                GetClientesAsync();
        }

        private async void GetClientesAsync()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7166/api/Cliente"))
                {
                    var clientes = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<ClienteDTO>>(clientes);
                    dgvRegistroClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRegistroClientes.DataSource = result;
                }
            }
        }
        private async void GetRegistrosAsync()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7166/api/RegistroVenta"))
                {
                    var registros = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<RegistroVentaDTO>>(registros);
                    dgvRegistroVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRegistroVentas.DataSource = result;
                }
            }
        }

        private async void GetAllCarsAsycn()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7166/api/Vehiculo"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var cars = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<VehiculoDTO>>(cars);
                        dgvVehiculos.Columns.Clear();
                        dgvVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvVehiculos.Columns.Add("VehiculoId", "VehiculoId");
                        dgvVehiculos.Columns.Add("Marca", "Marca");
                        dgvVehiculos.Columns.Add("Modelo", "Modelo");
                        dgvVehiculos.Columns.Add("Precio", "Precio");
                        dgvVehiculos.Columns.Add("Estado", "Estado");
                        dgvVehiculos.Columns.Add("AñoFabricacion", "AñoFabricacion");
                        dgvVehiculos.Columns.Add("Descripcion", "Descripcion");
                        dgvVehiculos.Columns.Add("Imagen", "Imagen");
                        dgvVehiculos.Columns.Add("Vendido", "Vendido");

                        for (int i = 0; i < result.Count; i++)
                        {
                            dgvVehiculos.Rows.Add();
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["VehiculoId"].Value = result[i].VehiculoId;
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["Marca"].Value = result[i].Marca;
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["Modelo"].Value = result[i].Modelo;
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["Precio"].Value = result[i].Precio;
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["Estado"].Value = result[i].Estado;
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["AñoFabricacion"].Value = result[i].AñoFab;
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["Descripcion"].Value = result[i].Descripcion;

                            string codigoImagen = "0x" + BitConverter.ToString(result[i].Imagen).Replace("-", "");
                            codigoImagen = codigoImagen.Substring(0, Math.Min(codigoImagen.Length, 40));

                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["Imagen"].Value = codigoImagen;
                            dgvVehiculos.Rows[dgvVehiculos.Rows.Count - 1].Cells["Vendido"].Value = result[i].Vendido;
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No se ha podido obtener el inventario de carros debido ha: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void txtImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog SelectorImagen = new OpenFileDialog();
            DialogResult resultado = SelectorImagen.ShowDialog();
            string nombreArchivo;

            if (resultado == DialogResult.Cancel)
                return;

            nombreArchivo = SelectorImagen.FileName;

            Image imagen;
            using (FileStream File = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read))
            {
                imagen = Image.FromStream(File);
            }


            using (MemoryStream memoryStream = new MemoryStream())
            {
                imagen.Save(memoryStream, imagen.RawFormat);
                datosImagen = memoryStream.ToArray();
            }

            txtImagen.Text = nombreArchivo;
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvVehiculos.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    vehiculoId = int.Parse(row.Cells[0].Value.ToString());
                    ObtenerVehiculoxChasis(vehiculoId);
                }
            }
        }

        private async void ObtenerVehiculoxChasis(int vehiculoID)
        {
            string imageeeen = "";
            using (var client = new HttpClient())
            {
                var Respuesta = await client.GetAsync(String.Format("{0}/{1}", "https://localhost:7166/api/Vehiculo", vehiculoID));
                if (Respuesta.IsSuccessStatusCode)
                {
                    var Datos = await Respuesta.Content.ReadAsStringAsync();
                    Vehiculo vehiculo = JsonConvert.DeserializeObject<Vehiculo>(Datos);
                    txtMarca.Text = vehiculo.Marca;
                    txtModelo.Text = vehiculo.Modelo;
                    txtPrecio.Text = vehiculo.Precio.ToString();
                    txtAño.Text = vehiculo.AñoFab.ToString();
                    txtDescripcion.Text = vehiculo.Descripcion.ToString();
                    txtEstado.Text = vehiculo.Estado;
                    imageeeen = "0x" + BitConverter.ToString(vehiculo.Imagen).Replace("-", "");
                    txtImagen.Text = imageeeen.Substring(0, Math.Min(imageeeen.Length, 40));
                    datosImagen = vehiculo.Imagen;

                }
                else
                    MessageBox.Show($"No se ha encontrado el vehiculo con id {vehiculoID}, {Respuesta.StatusCode.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ObtenerClienteXCedula(string cedula)
        {
            using (var client = new HttpClient())
            {
                var Respuesta = await client.GetAsync(String.Format("{0}/{1}", "https://localhost:7166/api/Cliente", cedula));
                if (Respuesta.IsSuccessStatusCode)
                {
                    var Datos = await Respuesta.Content.ReadAsStringAsync();
                    Cliente cliente = JsonConvert.DeserializeObject<Cliente>(Datos);
                    txtCedula.Text = cliente.CedulaId;
                    txtNombre.Text = cliente.NombreCliente;
                    txtDireccion.Text = cliente.Direccion;
                    mtTelefono.Text = cliente.NumeroTelefono;
                    txtGmail.Text = cliente.Email;
                }
                else
                    MessageBox.Show($"No se ha encontrado el cliente con id {cedula}, {Respuesta.StatusCode.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbBuscador_Click(object sender, EventArgs e)
        {
            bool verificar = true;

            foreach (VehicleItem itemVehiculo in flpCatalogo.Controls.OfType<VehicleItem>())
            {
                if (itemVehiculo.Marca.ToLower() != txtBuscadorVehiculoItem.Text.ToLower())
                {
                    itemVehiculo.Visible = false;
                }
                else
                {
                    itemVehiculo.Visible = true;
                    verificar = false;
                }

            }
            if (verificar)
            {
                MessageBox.Show($"No existen carros de la marca {txtBuscadorVehiculoItem.Text}", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                foreach (VehicleItem itemVehiculo in flpCatalogo.Controls.OfType<VehicleItem>())
                {
                    itemVehiculo.Visible = true;
                }
            }

        }

        private void txtBuscadorVehiculoItem_Click(object sender, EventArgs e)
        {
            txtBuscadorVehiculoItem.Text = "";
            txtBuscadorVehiculoItem.Focus();
        }

        private void txtBuscadorVehiculo_Click(object sender, EventArgs e)
        {
            txtBuscadorVehiculo.Text = "";
            txtBuscadorVehiculo.Focus();
        }

        private void txtBuscadorCliente_Click(object sender, EventArgs e)
        {
            txtBuscadorCliente.Text = "";
            txtBuscadorCliente.Focus();
        }

        private void guna2TextBox1_Click(object sender, EventArgs e)
        {
            txtBuscadorRegistro.Text = "";
            txtBuscadorRegistro.Focus();
        }

        private void pbBuscadorVehiculo_Click(object sender, EventArgs e)
        {
            ObtenerVehiculoxChasis(Convert.ToInt32(txtBuscadorVehiculo.Text));
            vehiculoId = Convert.ToInt32(txtBuscadorVehiculo.Text);
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            AñadirVehiculo();
        }

        private async void AñadirVehiculo()
        {
            try
            {
                VehiculoCreateDTO Vehiculo = new VehiculoCreateDTO()
                {
                    Modelo = txtModelo.Text,
                    Marca = txtMarca.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    Estado = txtEstado.Text,
                    AñoFab = int.Parse(txtAño.Text),
                    Descripcion = txtDescripcion.Text,
                    Imagen = datosImagen,
                    Vendido = "No"
                };
                using (var vehiculo = new HttpClient())
                {
                    var VehiculoSerializado = JsonConvert.SerializeObject(Vehiculo);
                    var Datos = new StringContent(VehiculoSerializado, Encoding.UTF8, "application/json");
                    var Respuesta = await vehiculo.PostAsync("https://localhost:7166/api/Vehiculo", Datos);
                    if (Respuesta.IsSuccessStatusCode)
                    {
                        MessageBox.Show("El vehículo ha sido agregado correctamente", "Información!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show($"Ha ocurrido un error: {Respuesta.Content.ReadAsStringAsync().Result.ToString()}");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al registrar el vehiculo", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar(Guna2GroupBox item)
        {
            foreach (Control Controles in item.Controls)
            {
                if (Controles is TextBox)
                {
                    Controles.Text = "";
                }
            }
            vehiculoId = 0;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Limpiar(gbDatosVehiculo);
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            if (vehiculoId != 0)
                EliminarVehiculoAsync();
            else
                MessageBox.Show("No se ha elegido el vehículo a eliminar", "!Error¡", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private async Task EliminarVehiculoAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7166/api/Vehiculo");
                string VariablePrueba = String.Format("{0}={1}",
                    "https://localhost:7166/api/Vehiculo?id", vehiculoId);
                var Respuesta = await client.DeleteAsync(VariablePrueba);
                if (Respuesta.IsSuccessStatusCode)
                {
                    MessageBox.Show("El vehículo se ha eliminado correctamente", "!Exito¡", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar(gbDatosVehiculo);
                    GetAllCarsAsycn();

                }
                else
                    MessageBox.Show("No se ha podido eliminar el vehículo correctamente", "!Error¡", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            ActualizarVehiculoAsync();


        }

        private async void ActualizarVehiculoAsync()
        {
            try
            {
                VehiculoUpdateDTO vehiculo = new VehiculoUpdateDTO()
                {
                    Modelo = txtModelo.Text,
                    Marca = txtMarca.Text,
                    Precio = double.Parse(txtPrecio.Text),
                    Estado = txtEstado.Text,
                    AñoFab = int.Parse(txtAño.Text),
                    Descripcion = txtDescripcion.Text,
                    VehiculoId = vehiculoId,
                    Imagen = datosImagen,
                    Vendido = "No"
                };

                using (var client = new HttpClient())
                {

                    var VehiculoSerializado = JsonConvert.SerializeObject(vehiculo);
                    var VehiculoContenido = new StringContent(VehiculoSerializado, Encoding.UTF8, "application/json");
                    var Respuesta = await client.PutAsync(String.Format("{0}={1}", "https://localhost:7166/api/Vehiculo?id", vehiculoId), VehiculoContenido);
                    if (Respuesta.IsSuccessStatusCode)
                        MessageBox.Show("El vehículo ha sido actualizado", "!Exito¡", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se ha podido actualizar el vehículo correctamente", "!Error¡", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Limpiar(gbDatosVehiculo);
                GetAllCarsAsycn();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar el vehiculo", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Limpiar(gbClientes);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ObtenerClienteXCedula(txtBuscadorCliente.Text);
        }

        private void dgvRegistroClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRegistroClientes.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    cedulaCliente = row.Cells[0].Value.ToString();
                    ObtenerClienteXCedula(cedulaCliente);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            BusquedaRegistroAsync(txtBuscadorRegistro.Text);


        }

        private async Task BusquedaRegistroAsync(string buscador)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:7166/api/RegistroVenta"))
                {
                    var registros = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<List<RegistroVentaDTO>>(registros);
                    var busqueda = from obj in result where obj.CedulaId == buscador select obj;
                    if (busqueda.Count() >= 1)
                    {
                        dgvRegistroVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvRegistroVentas.DataSource = busqueda.ToList();
                        return;
                    }
                    dgvRegistroVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvRegistroVentas.DataSource = result.ToList();
                }
            }
        }

        private void tpRegistroVentas_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            UpdateClienteAsync();
           
        }

        private async Task UpdateClienteAsync()
        {
            ClienteUpdateDTO clienteUpdate = new ClienteUpdateDTO();
            clienteUpdate.CedulaId = txtCedula.Text;
            clienteUpdate.NombreCliente = txtNombre.Text;
            clienteUpdate.Email = txtGmail.Text;
            clienteUpdate.NumeroTelefono = mtTelefono.Text;
            clienteUpdate.Direccion = txtDireccion.Text;

            using (var client = new HttpClient())
            {
                var student = JsonConvert.SerializeObject(clienteUpdate);
                var content = new StringContent(student, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(String.Format("{0}={1}",
                    "https://localhost:7166/api/Cliente?id", clienteUpdate.CedulaId), content);
                if (response.IsSuccessStatusCode)
                    MessageBox.Show("Estudiante actualizado");
                else
                    MessageBox.Show($"Error al actualizar el estudiante: {response.StatusCode}");
            }
        }
    }
}