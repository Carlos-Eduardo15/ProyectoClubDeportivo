using ClubDeportivo.Clases;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Pdf;
using System.IO;

namespace ClubDeportivo.Formularios
{
    public partial class frmRecibos : Form
    {
        public frmRecibos()
        {
            InitializeComponent();
            pestañaSocio.Enabled = false; // Deshabilitar pestaña del socio
            pestañaInvitado.Enabled = false; // Deshabilitar pestaña del invitado

        }
        SQLSocios comandos = new SQLSocios();
        string  nombre, apellidoPaterno, apellidoMaterno, curp, direccion, correo, telefono;
        DateTime fechaIngreso;
        DateTime fechaNacimiento;
        int edad;
        char tipo;
        int precio1 = 1600;
        int precio2 = 1500;
        int precio3 = 1700;
        int precio4 = 2000;


        private void ObtenerDatosSocio()
        {


            // Llama al método ConsultarSocio para obtener los datos
            comandos.ConsultarSocio(out nombre, out apellidoPaterno, out apellidoMaterno, out curp, out fechaNacimiento, out edad, out direccion, out correo, out telefono, out fechaIngreso, out tipo);

            //imprime en los labels especificos información especifica
            labelNombre.Text = nombre;
            labelA_Paterno.Text = apellidoPaterno;
            labelA_Materno.Text = apellidoMaterno;
            labelCurp.Text = curp;
            labelFechaNacimiento.Text = fechaNacimiento.ToString();
            labelEdad.Text = edad.ToString();
            labelDireccion.Text = direccion;
            labelCorreo.Text = correo;
            labelTelefono.Text = telefono;


            if (tipo == 'S') // Si es socio
            {
                pestañaSocio.Enabled = true; // Habilitar pestaña del socio
                pestañaInvitado.Enabled = true; // Habilitar pestaña del invitado
            }
            else if (tipo == 'I') // Si es invitado
            {
                pestañaSocio.Enabled = true; // Habilitar pestaña del socio
                pestañaInvitado.Enabled = false; // Deshabilitar pestaña del invitado
            }
            else // Si no es ni socio ni invitado
            {
                pestañaSocio.Enabled = false; // Deshabilitar pestaña del socio
                pestañaInvitado.Enabled = false; // Deshabilitar pestaña del invitado
            }


        }

        //aqui se realizaran las sumas
        private void frmRecibos_Load(object sender, EventArgs e)
        {
            
        }

        //BUSQUEDA DE NUMEROS Y NOMBRE
        //label
        private void label11_Click(object sender, EventArgs e)
        {

        }
        //input de la busqueda
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //boton de busqueda
        private void button1_Click(object sender, EventArgs e)
        {


            if (VerificarCampos())
            {
                comandos.getID = int.TryParse(textBoxIdSocio.Text.Trim(), out int idSocio) ? idSocio : 0;
                if (VerificarCampos() == true)
                {
                    labelNum.Text = idSocio.ToString();
                    ObtenerDatosSocio();
                }

            }
            else
            {
                MessageBox.Show("Ingresa un id de trabajador", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


        private bool VerificarCampos()
        {
            string id = textBoxIdSocio.Text;
            return !string.IsNullOrEmpty(id);
        }


     

        private int sumatoria = 0;

        private void checkedListBoxCC_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int indice = e.Index;
            bool estadoNuevo = e.NewValue == CheckState.Checked;

            switch (indice)
            {
                case 0:
                    // Manejar la lógica para el caso 0 (índice 0)
                    sumatoria += estadoNuevo ? precio1 : -precio1;
                    break;

                case 1:
                    // Manejar la lógica para el caso 1 (índice 1)
                    sumatoria += estadoNuevo ? precio2 : -precio2;
                    break;

                case 2:
                    // Manejar la lógica para el caso 2 (índice 2)
                    sumatoria += estadoNuevo ? precio3 : -precio3;
                    break;

                case 3:
                    // Manejar la lógica para el caso 3 (índice 3)
                    sumatoria += estadoNuevo ? precio4 : -precio4;
                    break;

                default:
                    Console.WriteLine("ERROR EN LA SUMATORIA");
                    break;
            }
            Console.WriteLine("Chequemos is hace esto");

            sumatoria = Math.Max(0, sumatoria); // Asegura que el valor mínimo sea 0

            labelTotalCC.Text = sumatoria.ToString();
          //  Console.WriteLine($"Sumatoria final: {sumatoria}");
        }

 

   

        private void checkedListBoxAM_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            int indice = e.Index;
            bool estadoNuevo = e.NewValue == CheckState.Checked;

            switch (indice)
            {
                case 0:
                    // Manejar la lógica para el caso 0 (índice 0)
                    sumatoria2 += estadoNuevo ? precio1 : -precio1;
                    break;

                case 1:
                    // Manejar la lógica para el caso 1 (índice 1)
                    sumatoria2 += estadoNuevo ? precio2 : -precio2;
                    break;

                case 2:
                    // Manejar la lógica para el caso 2 (índice 2)
                    sumatoria2 += estadoNuevo ? precio3 : -precio3;
                    break;

                default:
                    Console.WriteLine("ERROR EN LA SUMATORIA");
                    break;
            }
            Console.WriteLine("Chequemos is hace esto");

            sumatoria2 = Math.Max(0, sumatoria2); // Asegura que el valor mínimo sea 0

            labelTotalAM.Text = sumatoria2.ToString();
        }

        //lista de checkbox

        private int sumatoria2 = 0;



      




        //descargar pdf
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //boton de guardar
        private void button4_Click(object sender, EventArgs e)
        {
            // Ruta del archivo PDF de salida
            // Obtener la ruta del escritorio
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Concatenar el nombre del archivo al final de la ruta del escritorio
            string outputPath = Path.Combine(desktopPath, "archivo.pdf");

            // Crear un documento PDF
            using (var document = new PdfDocument())
            {
                // Añadir una página al documento
                var page = document.AddPage();

                // Obtener un objeto XGraphics para dibujar en la página
                using (var gfx = XGraphics.FromPdfPage(page))
                {
                    // Definir la fuente y el tamaño
                    var font = new XFont("Arial", 12);

                    // Dibujar un texto en la página
                    gfx.DrawString("Hola, este es un documento PDF generado con PDFsharp.", font, XBrushes.Black,
                        new XRect(10, 10, page.Width, page.Height), XStringFormats.TopLeft);
                }

                // Guardar el documento PDF en el archivo
                document.Save(outputPath);
            }

            // Mostrar un mensaje indicando que el PDF se generó con éxito
            MessageBox.Show("PDF generado con éxito en: " + outputPath, "Generación de PDF");
        }

        //boton de salir
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRecibos_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMENU frmMenu = new frmMENU();
            frmMenu.Show();
        }
    }
}

        
        
     