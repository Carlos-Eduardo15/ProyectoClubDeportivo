using ClubDeportivo.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Formularios.SociosForms
{
    public partial class SocioNI : Form
    {

        public SocioNI()
        {
            InitializeComponent();
            dateTimeNacimiento.ValueChanged += DateTimePickerNacimiento_ValueChanged;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            // Desactivar las barras de desplazamiento automático en el formulario
            this.AutoScroll = false;

            // Desactivar las barras de desplazamiento horizontal y vertical en el formulario
            this.HorizontalScroll.Enabled = false;
            this.VerticalScroll.Enabled = false;

        }
        int edadFinal;
        SQLSocios comandos = new SQLSocios();
        int nuevoIdObtenido;
        private void ObtenerNuevoIdSocio()
        {
            // Llamamos al método de la instancia de SQLSocios para obtener el nuevo ID
            nuevoIdObtenido = comandos.ObtenerNuevoIdSocio();
            labelIdSocio.Text = nuevoIdObtenido.ToString();
        }
        private void DateTimePickerNacimiento_ValueChanged(object sender, EventArgs e)
        {
            CalcularEdad();

        }
        private void CalcularEdad()
        {
            DateTime fechaNacimiento = dateTimeNacimiento.Value;
            DateTime fechaActual = DateTime.Now;

            int edad = fechaActual.Year - fechaNacimiento.Year;

            // Ajusta la edad si aún no ha tenido su cumpleaños en este año
            if (fechaNacimiento > fechaActual.AddYears(-edad))
            {
                edad--;
            }

            // Actualiza el texto del Label
            labelEdad.Text = $"Edad: {edad} años";
             edadFinal=edad;
        }
     

        private bool VerificarCampos()
        {
            string nombre = textBoxNombre.Text;
            string apellido_Paterno = textBoxA_Paterno.Text;
            string apellido_Materno= textBoxA_Materno.Text;
            string curp = textBox_curp.Text;


            if (dateTimeNacimiento.Value == null)
            {
                MessageBox.Show("Por favor, selecciona una fecha de nacimiento válida.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return !string.IsNullOrEmpty(nombre) &&
                !string.IsNullOrEmpty(apellido_Paterno) &&
                !string.IsNullOrEmpty(apellido_Materno)&&
                !string.IsNullOrEmpty(curp);
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (VerificarCampos())
            {
                //MessageBox.Show("¡Los campos principales no estan vacios!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comandos.getNombre = textBoxNombre.Text.Trim();
                    comandos.getApellidoPaterno = textBoxA_Paterno.Text.Trim();
                    comandos.getApellidoMaterno = textBoxA_Materno.Text.Trim();
                    comandos.getCurp = textBox_curp.Text.Trim();
                    comandos.getFechaNacimiento = dateTimeNacimiento.Value.Date;
                    comandos.getEdad = edadFinal;
                    comandos.getTelefono = textBoxTelefono.Text.Trim();
                    comandos.getCorreo = textBoxCorreo.Text.Trim();
                    comandos.getDireccion = textBoxDireccion.Text.Trim();
                    comandos.getFechaIngreso = DateTime.Now;

                if (VerificarCampos()==true) 
                {
                    comandos.insertarSocio();
                    MessageBox.Show("Socio ingresado: "+ textBoxNombre, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Por favor, completa todos los campos antes de continuar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void SocioNI_Load(object sender, EventArgs e)
        {
            ObtenerNuevoIdSocio();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimeNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
