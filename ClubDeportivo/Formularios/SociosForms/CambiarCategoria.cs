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
    public partial class CambiarCategoria : Form
    {
        public CambiarCategoria()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

        }
        SQLSocios comandos = new SQLSocios();
        string nombre, apellidoPaterno, apellidoMaterno, curp, direccion, correo, telefono;
        DateTime fechaIngreso;
        DateTime fechaNacimiento;
        int edad;
        char tipo;

        private void button1_Click(object sender, EventArgs e)
        {
            // Después de obtener el valor de 'tipo'
            checkBoxSocio.Checked = (tipo == 'S');
            checkBoxInvitado.Checked = (tipo == 'I');
            
            if (VerificarCampos())
            {

                comandos.getID = int.TryParse(textBoxIdSocio.Text.Trim(), out int idSocio) ? idSocio : 0;
                comandos.getTipo = tipo;

                if (VerificarCampos() == true)
                {
                    comandos.actualizarTipo();
                    MessageBox.Show("Usuario: "+labelNombre+" Actualizado a: " + tipo, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Ingresa un id de trabajador", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelA_Paterno_Click(object sender, EventArgs e)
        {

        }

        private void labelA_Materno_Click(object sender, EventArgs e)
        {

        }

        private void labelDireccion_Click(object sender, EventArgs e)
        {

        }

        private void labelCorreo_Click(object sender, EventArgs e)
        {

        }

        private void labelCurp_Click(object sender, EventArgs e)
        {

        }

        private void labelFechaNacimiento_Click(object sender, EventArgs e)
        {

        }

        private void labelEdad_Click(object sender, EventArgs e)
        {

        }

        private void labelNombre_Click(object sender, EventArgs e)
        {

        }

        private void labelTelefono_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxSocio_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxSocio.Checked)
            {
                // Si checkBoxSocio se activa, desactiva checkBoxInvitado
                checkBoxInvitado.Checked = false;
                tipo = 'S';
            }
        }

        private void checkBoxInvitado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInvitado.Checked)
            {
                // Si checkBoxInvitado se activa, desactiva checkBoxSocio
                checkBoxSocio.Checked = false;
                tipo = 'I';
            }
        }

        private void CambiarCategoria_Load(object sender, EventArgs e)
        {

        }

        private void ObtenerDatosSocio()
        {


            // Llama al método ConsultarSocio para obtener los datos
            comandos.ConsultarSocio(out nombre, out apellidoPaterno, out apellidoMaterno, out curp, out fechaNacimiento, out edad, out direccion, out correo, out telefono, out fechaIngreso,out tipo);


            labelNombre.Text = nombre;
            labelA_Paterno.Text = apellidoPaterno;
            labelA_Materno.Text = apellidoMaterno;
            labelCurp.Text = curp;
            labelFechaNacimiento.Text = fechaNacimiento.ToString();
            labelEdad.Text = edad.ToString();
            labelDireccion.Text = direccion;
            labelCorreo.Text = correo;
            labelTelefono.Text = telefono;

            if (tipo == 'S')
            {
                checkBoxSocio.Checked = true;
                checkBoxInvitado.Checked = false;
            }
            else if (tipo == 'I')
            {
                checkBoxSocio.Checked = false;
                checkBoxInvitado.Checked = true;
            }
            else
            {
                checkBoxSocio.Checked = false;
                checkBoxInvitado.Checked = false;
            }


        }

        private bool VerificarCampos()
        {
            string id = textBoxIdSocio.Text;
            return !string.IsNullOrEmpty(id);
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            if (VerificarCampos())
            {

                comandos.getID = int.TryParse(textBoxIdSocio.Text.Trim(), out int idSocio) ? idSocio : 0;

                if (VerificarCampos() == true)
                {
                    ObtenerDatosSocio();
                }

            }
            else
            {
                MessageBox.Show("Ingresa un id de trabajador", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

      


    }
}
