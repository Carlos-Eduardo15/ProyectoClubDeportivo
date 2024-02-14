using ClubDeportivo.Formularios.SociosForms;

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
    public partial class frmSocios : Form
    {
        public frmSocios()
        {
            InitializeComponent();
        }

        private void CerrarFormulariosHijos()
        {
            foreach (Form frmAbierto in this.MdiChildren)
            {
                frmAbierto.Close();
            }
        }

        private void sociosNuevoIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();

            // Abre una nueva instancia de SocioNI
            SocioNI frm = new SocioNI();
            frm.MdiParent = this;
            frm.Show();
            frm.Size = this.ClientSize;
            frm.BringToFront();
        }

        private void invitadoNuevoIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();

            InvitadoNI frm = new InvitadoNI();
            frm.MdiParent = this;
            frm.Size = this.ClientSize;
            frm.Show();
            frm.BringToFront();
        }

        private void sociosDeReIngresoOInvitadosDeReIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();

            Reingreso frm = new Reingreso();
            frm.MdiParent = this;
            frm.Size = this.ClientSize;
            frm.Show();
            frm.BringToFront();
        }

        private void cambiarDeCategoríaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CerrarFormulariosHijos();

            CambiarCategoria frm = new CambiarCategoria();
            frm.MdiParent = this;
            frm.Size = this.ClientSize;
            frm.Show();
            frm.BringToFront();
        }

        private void consultarPadrónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultaPadron frm = new ConsultaPadron();
            frm.MdiParent = this;
            frm.Size = this.ClientSize;
            frm.Show();
            frm.BringToFront();
        }

        private void frmSocios_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMENU frm = new frmMENU();
            frm.Show();
        }
    }

    }
