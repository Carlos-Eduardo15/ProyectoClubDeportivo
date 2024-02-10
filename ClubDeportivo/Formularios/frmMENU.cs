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
    public partial class frmMENU : Form
    {
        public frmMENU()
        {
            InitializeComponent();
        }

        private void frmMENU_Load(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void sociosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSocios frmSocios = new frmSocios();
            frmSocios.Show();
        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecibos frmRecibos = new frmRecibos();
            frmRecibos.Show();
        }

        private void defunciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDefunciones frmDefunciones = new frmDefunciones();
            frmDefunciones.Show();
        }

        private void tarifasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTarifas frmTarifas = new frmTarifas();
            frmTarifas.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }
    }
}
