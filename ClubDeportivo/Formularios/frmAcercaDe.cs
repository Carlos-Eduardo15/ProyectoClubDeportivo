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
    public partial class frmAcercaDe : Form
    {
        public frmAcercaDe()
        {
            InitializeComponent();
        }

        private void frmAcercaDe_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMENU frmMenu = new frmMENU();
            frmMenu.Show();
        }

        private void frmAcercaDe_Load(object sender, EventArgs e)
        {

        }
    }
}
