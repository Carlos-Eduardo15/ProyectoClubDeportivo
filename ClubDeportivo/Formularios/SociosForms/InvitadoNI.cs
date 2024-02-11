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
    public partial class InvitadoNI : Form
    {
        private static InvitadoNI instancia = null;
        public static InvitadoNI ventana_unica1()
        {
            if(instancia == null)
            {
                instancia = new InvitadoNI();
                return instancia;
            }
            return instancia;
        }

        public InvitadoNI()
        {
            InitializeComponent();
        }

    }
}
