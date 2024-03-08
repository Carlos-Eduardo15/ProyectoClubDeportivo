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
    public partial class frmDefunciones : Form
    {
        public frmDefunciones()
        {
            InitializeComponent();
        }
        private void frmDefunciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMENU frmMENU = new frmMENU();    
            frmMENU.Show();
        }

        private void btnBuscarSocio_Click(object sender, EventArgs e)
        {
            if (!(txtNumeroSocio.Text == ""))
            {
                Defuncion defuncion = new Defuncion();
                Tarifa tarifa = new Tarifa();

                int id_socio = int.Parse(txtNumeroSocio.Text);
                defuncion.consultarSocio(id_socio, txtNombre, txtApPaterno, txtApMaterno, txtCurp, txtEdad, txtDireccion, txtCorreo, txtTelefono, txtFechaIngreso, txtTipo);
                tarifa.consultarTarifaEspecifica("Defunción", txtMonto);
                defuncion.consultarBeneficiario(id_socio, txtBeneficiario, txtMonto, dtDefuncion);
                
                dtDefuncion.Enabled = true;
                txtBeneficiario.Enabled = true;
                btnGuardar.Enabled = true;
            }
            else 
            {
                ttIdSocio.Show("Campo vacío",txtNumeroSocio,2000);
            }

        }

  
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBeneficiario.Text))
            {
                Defuncion defuncion = new Defuncion();

                int id_socio;
                DateTime fecha_defuncion;
                string beneficiario;
                double monto;

                id_socio = int.Parse(txtNumeroSocio.Text);
                fecha_defuncion = dtDefuncion.Value.Date;
                beneficiario = txtBeneficiario.Text;
                monto = Double.Parse(txtMonto.Text);
                //Formato permitido en MySQL para guardar fechas
                string formatoFecha = fecha_defuncion.ToString("yyyy-MM-dd");

                defuncion.registrarDefuncion(id_socio, formatoFecha, beneficiario, monto);
                defuncion.registrarDefuncionUsuario(id_socio, formatoFecha);
            }
            else
            {
                ttIdSocio.Show("Campo vacío", txtBeneficiario, 2000);
            }
            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            frmSociosFallecidos formFallecidos = new frmSociosFallecidos();
            formFallecidos.Show();
        }

        private void txtNumeroSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el caracter ingresado no es un número o la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni la tecla de retroceso, se cancela el ingreso del carácter
                e.Handled = true;
                ttIdSocio.Show("Sólo se permiten números.", txtNumeroSocio, 2000);
            }
        }
        private void txtBeneficiario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el caracter ingresado no es una letra o la tecla de retroceso o la tecla 'Espacio'
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ')
            {
                // Si no es una letra, se cancela el ingreso del carácter
                e.Handled = true;
                ttIdSocio.Show("Sólo se permiten letras.", txtBeneficiario, 2000);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
