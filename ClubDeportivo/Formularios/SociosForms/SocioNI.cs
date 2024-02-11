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
    public partial class SocioNI : Form
    {
        private static SocioNI instancia = null;
        public static SocioNI ventana_unica2()
        {
            if (instancia == null)
            {
                instancia = new SocioNI();
                return instancia;
            }
            return instancia;
        }

        public SocioNI()
        {
            InitializeComponent();
        }

    }
}
