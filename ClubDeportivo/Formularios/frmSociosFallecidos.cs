﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivo.Clases;

namespace ClubDeportivo.Formularios
{
    public partial class frmSociosFallecidos : Form
    {
        public frmSociosFallecidos()
        {
            InitializeComponent();
            Defuncion defuncion = new Defuncion();
            defuncion.consultarDefunciones(dgvDefunciones);
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {

        }
    }
}