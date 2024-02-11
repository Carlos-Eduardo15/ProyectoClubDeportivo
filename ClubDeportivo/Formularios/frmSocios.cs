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

        private void sociosNuevoIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SocioNI frm = new SocioNI();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();

        }

        private void invitadoNuevoIngresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvitadoNI frm = new InvitadoNI();
            frm.MdiParent = this;
            frm.Show();
            frm.BringToFront();
        }
    }

}
