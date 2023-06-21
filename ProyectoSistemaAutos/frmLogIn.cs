using Autolote.Data;
using AutoloteAPI.Models;
using AutoloteAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ComrobarUser(txtUsuario.Text, txtContraseña.Text);
        }
        private async Task ComrobarUser(string usuario, string contraseña)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var Respuesta = await client.GetAsync("https://localhost:7166/api/User"))
                    {

                        if (Respuesta.IsSuccessStatusCode)
                        {
                            var UsuariosListaSerializados = await Respuesta.Content.ReadAsStringAsync();
                            var UsuariosLista = JsonConvert.DeserializeObject<List<UserDTO>>(UsuariosListaSerializados);

                            foreach (var obj in UsuariosLista)
                            {
                                if(obj.Username == usuario && obj.Password == contraseña)
                                {
                                    frmPrincipal principal = new frmPrincipal();
                                    this.Hide();
                                    principal.ShowDialog();
                                    this.Close();
                                    return;
                                }
                            }
                            MessageBox.Show("Usuario no existe o contraseña no coincide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (System.Net.Http.HttpRequestException)
                {
                    MessageBox.Show("Aún no se ha establecido la conexión con la API", "!Error¡", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
