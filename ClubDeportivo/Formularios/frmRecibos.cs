using ClubDeportivo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Formularios
{
    public partial class frmRecibos : Form
    {
        public frmRecibos()
        {
            InitializeComponent();
            pestañaSocio.Enabled = false; // Deshabilitar pestaña del socio
            pestañaInvitado.Enabled = false; // Deshabilitar pestaña del invitado

        }
        SQLSocios comandos = new SQLSocios();
        string  nombre, apellidoPaterno, apellidoMaterno, curp, direccion, correo, telefono;
        DateTime fechaIngreso;
        DateTime fechaNacimiento;
        int edad;
        char tipo;


        private void ObtenerDatosSocio()
        {


            // Llama al método ConsultarSocio para obtener los datos
            comandos.ConsultarSocio(out nombre, out apellidoPaterno, out apellidoMaterno, out curp, out fechaNacimiento, out edad, out direccion, out correo, out telefono, out fechaIngreso, out tipo);

            //imprime en los labels especificos información especifica
            labelNombre.Text = nombre;
            labelA_Paterno.Text = apellidoPaterno;
            labelA_Materno.Text = apellidoMaterno;
            labelCurp.Text = curp;
            labelFechaNacimiento.Text = fechaNacimiento.ToString();
            labelEdad.Text = edad.ToString();
            labelDireccion.Text = direccion;
            labelCorreo.Text = correo;
            labelTelefono.Text = telefono;


            if (tipo == 'S') // Si es socio
            {
                pestañaSocio.Enabled = true; // Habilitar pestaña del socio
                pestañaInvitado.Enabled = true; // Habilitar pestaña del invitado
            }
            else if (tipo == 'I') // Si es invitado
            {
                pestañaSocio.Enabled = true; // Habilitar pestaña del socio
                pestañaInvitado.Enabled = false; // Deshabilitar pestaña del invitado
            }
            else // Si no es ni socio ni invitado
            {
                pestañaSocio.Enabled = false; // Deshabilitar pestaña del socio
                pestañaInvitado.Enabled = false; // Deshabilitar pestaña del invitado
            }


        }

        private void frmRecibos_Load(object sender, EventArgs e)
        {

        }

        //BUSQUEDA DE NUMEROS Y NOMBRE
        //label
        private void label11_Click(object sender, EventArgs e)
        {

        }
        //input de la busqueda
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //boton de busqueda
        private void button1_Click(object sender, EventArgs e)
        {


            if (VerificarCampos())
            {
                comandos.getID = int.TryParse(textBoxIdSocio.Text.Trim(), out int idSocio) ? idSocio : 0;
                if (VerificarCampos() == true)
                {
                    labelNum.Text = idSocio.ToString();
                    ObtenerDatosSocio();
                }

            }
            else
            {
                MessageBox.Show("Ingresa un id de trabajador", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


        private bool VerificarCampos()
        {
            string id = textBoxIdSocio.Text;
            return !string.IsNullOrEmpty(id);
        }


        //CASA CLUB
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        //lista de checkbox
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //etiqueta coperacion seleccion
        private void label26_Click(object sender, EventArgs e)
        {

        }


        //etiqueta coperacion terrenos
        private void label27_Click(object sender, EventArgs e)
        {

        }
        //etiqueta membresia
        private void label28_Click(object sender, EventArgs e)
        {

        }
        //etiqueta de casa
        private void label12_Click(object sender, EventArgs e)
        {

        }
        //total
        private void label24_Click(object sender, EventArgs e)
        {

        }
        //descargar pdf
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //AYUDA MUTUA
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        //lista de checkbox
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //etiqueta coperacion seleccion
        private void label33_Click(object sender, EventArgs e)
        {

        }
        //etiqueta coperacion terrenos
        private void label32_Click(object sender, EventArgs e)
        {

        }
        //etiqueta membresia
        private void label31_Click(object sender, EventArgs e)
        {

        }
        //etiqueta de ayuda
        private void label34_Click(object sender, EventArgs e)
        {

        }
        //total
        private void label35_Click(object sender, EventArgs e)
        {

        }
        //descargar pdf
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //boton de guardar
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //boton de salir
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecibos_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMENU frmMenu = new frmMENU();
            frmMenu.Show();
        }
    }
}

        
        
     