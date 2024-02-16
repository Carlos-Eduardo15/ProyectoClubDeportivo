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
            label12.Text=DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}
