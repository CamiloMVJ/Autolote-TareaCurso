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
    public partial class VehicleItem : UserControl
    {
        public VehicleItem()
        {
            InitializeComponent();
            pDatos.Size = new Size(300, 282);
            pBotones.Size = new Size(300, 63);


        }

        //Atributos del UserItem(sirve para modifcar cada Item)
        public Image ImagenVehiculo
        {
            get { return pbImage.Image; }
            set { pbImage.Image = value; }
        }

        public string Marca
        {
            get { return lblMarca.Text; }
            set { lblMarca.Text = value; }
        }
        public string Id
        {
            get { return lblId.Text; }
            set { lblId.Text = value; }
        }

        public string EstadodelVehiculo
        {
            get { return lblEstado.Text; }
            set { lblEstado.Text = value; }
        }

        public string AñoFabricacion
        {
            get { return lblAño.Text; }
            set { lblAño.Text = value; }

        }

        public string DescripcionVehiculo
        {

            get { return lblDescripcionVehiculo1.Text; }
            set { lblDescripcionVehiculo1.Text = value; }
        }

        public string Precio
        {
            get { return lblPrecio.Text; }
            set { lblPrecio.Text = value; }
        }

        public string DescripcionVehiculo2
        {
            get { return lblDescripcionVehiculo2.Text; }
            set { lblDescripcionVehiculo2.Text = value; }
        }
        public string DescripcionVehiculo3
        {
            get { return lblDescripcionVehiculo3.Text; }
            set { lblDescripcionVehiculo3.Text = value; }
        }

        //Funcionalidad del Boton Debito
        private void btnDebito_Click(object sender, EventArgs e)
        {

            //Llamamos al formulario de Debito
            frmDebito vehiculoSelected = new frmDebito();
            //Aqui pasamos los valores que contiene el User al formulario de debito
            //mostrando el vehiculo que seleccionó
            vehiculoSelected.lblId.Text = this.Id.ToString();
            vehiculoSelected.pbImageShow.Image = this.ImagenVehiculo;
            vehiculoSelected.lblMarcaShow.Text = this.Marca;
            vehiculoSelected.lblAñoShow.Text = this.AñoFabricacion;
            vehiculoSelected.lblEstadoShow.Text = this.EstadodelVehiculo;
            vehiculoSelected.lblDescripcionVehiculo1Show.Text = this.DescripcionVehiculo;
            vehiculoSelected.lblDescripcionVehiculo2Show.Text = this.DescripcionVehiculo2;
            vehiculoSelected.lblDescripcionVehiculo3Show.Text = this.DescripcionVehiculo3;
            vehiculoSelected.lblPrecioShow.Text = this.Precio;
            vehiculoSelected.ShowDialog();

        }

        //Funcionalidad del Boton Credito
        private void btnCredito_Click(object sender, EventArgs e)
        {
            //LLamamos al formulario de Credito
            frmCredito vehiculoSelected = new frmCredito();
            //Pasamos los valores del Item seleccionado para que se muestre en el formulario debito

            vehiculoSelected.lblId.Text = this.Id;
            vehiculoSelected.pbImageShow.Image = this.ImagenVehiculo;
            vehiculoSelected.lblMarcaShow.Text = this.Marca;
            vehiculoSelected.lblAñoShow.Text = this.AñoFabricacion;
            vehiculoSelected.lblEstadoShow.Text = this.EstadodelVehiculo;
            vehiculoSelected.lblDescripcionVehiculo1Show.Text = this.DescripcionVehiculo;
            vehiculoSelected.lblDescripcionVehiculo2Show.Text = this.DescripcionVehiculo2;
            vehiculoSelected.lblDescripcionVehiculo3Show.Text = this.DescripcionVehiculo3;
            vehiculoSelected.lblPrecioShow.Text = this.Precio;
            vehiculoSelected.ShowDialog();
        }

        private void pDatos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
