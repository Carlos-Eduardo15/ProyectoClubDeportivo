using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivo.Clases;
using ClubDeportivo.Conectividad;

namespace ClubDeportivo.Formularios
{
    public partial class frmTarifas : Form
    {
       
        //private MySQL cxn;

        public string concepto;
        public double monto;
        public string tipo_tarifa;
        public int _id_tarifa;
        public frmTarifas()
        {
            InitializeComponent();
            Tarifa _tarifa_cc = new Tarifa();
            _tarifa_cc.consultarTarifas(dgvTarifasCC, "cc");
            btnActualizarTarifaCC.Enabled = false;

            Tarifa _tarifa_am = new Tarifa();
            _tarifa_am.consultarTarifas(dgvTarifasAM, "am");
            btnActualizarTarifaAM.Enabled = false;
        }
        private void btnGuardarTarifaCC_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtConceptoCC.Text) || !string.IsNullOrEmpty(txtMontoCC.Text))
            {
                Tarifa _tarifa = new Tarifa();
           
                concepto = txtConceptoCC.Text;
                monto = Double.Parse(txtMontoCC.Text);
                tipo_tarifa = "cc";
                _tarifa.insertarTarifa(concepto, monto, tipo_tarifa);
                
                txtConceptoCC.Text = "";
                txtMontoCC.Text = "";

                _tarifa.consultarTarifas(dgvTarifasCC, "cc");
            }
            else
            {
                if (string.IsNullOrEmpty(txtConceptoCC.Text))
                {
                    ttMonto.Show("Campo vacío", txtConceptoCC, 2000);
                }
                if (string.IsNullOrEmpty(txtMontoCC.Text))
                {
                    ttMonto.Show("Campo vacío", txtMontoCC, 2000);
                }
            }
        }
        private void btnGuardarTarifaAM_Click(object sender, EventArgs e)
        {
            Tarifa _tarifa = new Tarifa();
            if (!string.IsNullOrEmpty(txtConceptoAM.Text) && !string.IsNullOrEmpty(txtMontoAM.Text))
            {
                concepto = txtConceptoAM.Text;
                monto = Double.Parse(txtMontoAM.Text);
                tipo_tarifa = "am";
                _tarifa.insertarTarifa(concepto, monto, tipo_tarifa);
            }
            else
            {
                MessageBox.Show("Faltan datos por capturar.", "Atención");
            }
            
            txtConceptoAM.Text = "";
            txtMontoAM.Text = "";

            _tarifa.consultarTarifas(dgvTarifasAM, "am");
        }

        private void frmTarifas_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*frmMENU frmMENU = new frmMENU();
            frmMENU.Show();*/
        }

        private void frmTarifas_Load(object sender, EventArgs e)
        {
        }
        
        private void dgvTarifasCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya hecho clic en una fila válida
            {
                _id_tarifa = int.Parse(dgvTarifasCC.CurrentRow.Cells[0].Value.ToString());
                txtConceptoCC.Text = dgvTarifasCC.CurrentRow.Cells[1].Value.ToString();
                txtMontoCC.Text = dgvTarifasCC.CurrentRow.Cells[2].Value.ToString();
                btnActualizarTarifaCC.Enabled = true;
                btnGuardarTarifaCC.Enabled = false;
            }
        }

        private void dgvTarifasAM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que se haya hecho clic en una fila válida
            {
                _id_tarifa = int.Parse(dgvTarifasAM.CurrentRow.Cells[1].Value.ToString());
                txtConceptoAM.Text = dgvTarifasAM.CurrentRow.Cells[2].Value.ToString();
                txtMontoAM.Text = dgvTarifasAM.CurrentRow.Cells[3].Value.ToString();
                btnActualizarTarifaAM.Enabled = true;
                btnGuardarTarifaAM.Enabled = false;
            }
        }

        private void btnActualizarTarifaAM_Click(object sender, EventArgs e)
        {
            Tarifa tarifa_am = new Tarifa();

            string concepto_tarifa_am = txtConceptoAM.Text;
            double monto_tarifa_am = double.Parse(txtMontoAM.Text);

            tarifa_am.modificarTarifa(concepto_tarifa_am, monto_tarifa_am, _id_tarifa);

            tarifa_am.consultarTarifas(dgvTarifasAM,"am");
        }

        private void btnActualizarTarifaCC_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtConceptoCC.Text) || !string.IsNullOrEmpty(txtMontoCC.Text))
            {
                Tarifa tarifa_am = new Tarifa();

                string concepto_tarifa_cc = txtConceptoCC.Text;
                double monto_tarifa_cc = double.Parse(txtMontoCC.Text);

                tarifa_am.modificarTarifa(concepto_tarifa_cc, monto_tarifa_cc, _id_tarifa);
            
                tarifa_am.consultarTarifas(dgvTarifasCC, "cc");
            }
            else
            {
                if (string.IsNullOrEmpty(txtConceptoCC.Text))
                {
                    ttMonto.Show("Campo vacío", txtConceptoCC, 2000);
                }
                if (string.IsNullOrEmpty(txtMontoCC.Text))
                {
                    ttMonto.Show("Campo vacío", txtMontoCC, 2000);
                }
            }
        }

        private void txtMontoCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el caracter ingresado no es un número o la tecla de retroceso (backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni la tecla de retroceso, se cancela el ingreso del carácter
                e.Handled = true;
                ttMonto.Show("Sólo se permiten números.",txtMontoCC,2000);
            }
        }
        private void txtMontoAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                // Si no es un número ni la tecla de retroceso, se cancela el ingreso del carácter
                e.Handled = true;
                ttMonto.Show("Sólo se permiten números.", txtMontoAM, 2000);
            }
        }
        private void dgvTarifasAM_MouseLeave(object sender, EventArgs e)
        {
           
        }
        private void txtConceptoCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el caracter ingresado no es una letra o la tecla de retroceso o la tecla 'Espacio'
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ')
            {
                // Si no es una letra, se cancela el ingreso del carácter
                e.Handled = true;
                ttMonto.Show("Sólo se permiten letras.", txtConceptoCC, 2000);
            }
        }
        private void txtConceptoAM_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verificar si el caracter ingresado no es una letra o la tecla de retroceso o la tecla 'Espacio'
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != ' ')
            {
                // Si no es una letra, se cancela el ingreso del carácter
                e.Handled = true;
                ttMonto.Show("Sólo se permiten letras.", txtConceptoAM, 2000);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
