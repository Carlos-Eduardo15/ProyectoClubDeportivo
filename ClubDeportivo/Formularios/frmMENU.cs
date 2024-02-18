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


            // Configura el temporizador
            timer1 = new Timer();
            timer1.Interval = 1000; // Actualiza cada 1000 milisegundos (1 segundo)

            // Inicia el temporizador
            timer1.Start();
            // Desactivar las barras de desplazamiento automático en el formulario
            this.AutoScroll = false;

            // Desactivar las barras de desplazamiento horizontal y vertical en el formulario
            this.HorizontalScroll.Enabled = false;
            this.VerticalScroll.Enabled = false;

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
            this.Hide();

            //Mostrar frmSocios
            frmSocios frmSocios = new frmSocios();
            frmSocios.Show();
           
        }

        private void recibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            //Mostrar frmRecibos
            frmRecibos frmRecibos = new frmRecibos();
            frmRecibos.Show();
        }

        private void defunciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            //Mostrar frmDefunciones
            frmDefunciones frmDefunciones = new frmDefunciones();
            frmDefunciones.Show();
        }

        private void tarifasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            //Mostrar frmTarifas
            frmTarifas frmTarifas = new frmTarifas();
            frmTarifas.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //Cerrar aplicacion
            Application.Exit();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Actualizar labels con los datos correspondientes
            toolStripStatusLabel2.Text = DateTime.Now.ToString("dd/MM/yyyy");

            toolStripStatusLabel3.Text = DateTime.Now.ToString("HH:mm:ss");

            toolStripStatusLabel1.Text = "WELCOME";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
    }
}
