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

namespace ClubDeportivo.Formularios.SociosForms
{
    public partial class Reingreso : Form
    {
        public Reingreso()
        {
            InitializeComponent();
            labelFechaReIngreso.Text=DateTime.Now.ToString("yyyy-MM-dd");
            dateTimeNacimiento.ValueChanged += DateTimeNacimiento_ValueChanged;
        }
        int edadFinal;
        SQLSocios comandos = new SQLSocios();
        // Declara variables para almacenar los resultados
        string nombre, apellidoPaterno, apellidoMaterno, curp, direccion, correo, telefono;
        DateTime fechaIngreso;
        DateTime fechaNacimiento;
        int edad;
        char tipo;

        private void DateTimeNacimiento_ValueChanged(object sender, EventArgs e)
        {
            CalcularEdad();
            VerificarCamposUpdate();


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
            labelEdad.Text = $"Edad Actualizada: {edad} años";
            edadFinal = edad;
        }


        private bool VerificarCampos()
        {
            string id = textBoxIdSocio.Text;
            return !string.IsNullOrEmpty(id);
        }
        private bool VerificarCamposUpdate()
        {
            
            string curp = textBoxCurp.Text;

            return  !string.IsNullOrEmpty(curp);

        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {

                comandos.getID = int.TryParse(textBoxIdSocio.Text.Trim(), out int idSocio) ? idSocio : 0;

                if (VerificarCampos()==true)
                {
                    ObtenerDatosSocio();
                }
            }
            else
            {
                MessageBox.Show("Ingresa un id de trabajador", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // En el formulario donde quieres recibir los resultados de la consulta
        private void ObtenerDatosSocio()
        {
           

            // Llama al método ConsultarSocio para obtener los datos
            comandos.ConsultarSocio(out nombre, out apellidoPaterno, out apellidoMaterno, out curp, out  fechaNacimiento, out edad, out direccion, out correo, out telefono, out fechaIngreso,out tipo);

          
            labelNombre.Text = nombre;
            labelA_Paterno.Text = apellidoPaterno;
            labelA_Materno.Text = apellidoMaterno;
            textBoxCurp.Text = curp;
            dateTimeNacimiento.Value = fechaNacimiento;
            labelEdad.Text = edad.ToString();
            textBoxDireccion.Text = direccion;
            textBoxCorreo.Text = correo;
            textBoxTelefono.Text= telefono;
            label12FechaIngreso.Text=fechaIngreso.ToString("yyyy-MM-dd");


        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (VerificarCamposUpdate())
            {
                comandos.getID = int.TryParse(textBoxIdSocio.Text.Trim(), out int idSocio) ? idSocio : 0;

                comandos.getCurp = textBoxCurp.Text.Trim();
                comandos.getFechaNacimiento = dateTimeNacimiento.Value.Date;
                comandos.getEdad = edadFinal;
                comandos.getTelefono = textBoxTelefono.Text.Trim();
                comandos.getCorreo = textBoxCorreo.Text.Trim();
                comandos.getDireccion = textBoxDireccion.Text.Trim();
                comandos.getFechaReingreso = DateTime.Now.Date;
                try
                {
                    comandos.actualizarSocio();
                    MessageBox.Show("Socio Actualizado: " + labelNombre.Text, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch 
                {
                    MessageBox.Show("Error al insertar datos.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Ingresa una CURP", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
