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
        SQLRecibos comandosRecibos = new SQLRecibos();
        SQLSocios comandos = new SQLSocios();

        string  nombre, apellidoPaterno, apellidoMaterno, curp, direccion, correo, telefono;
        DateTime fechaIngreso;
        DateTime fechaNacimiento;
        int edad;
        char tipo;

        double monto = 0.0;
        double monto1CC = 0.0;
        double monto2CC = 0.0;
        double monto3CC = 0.0;
        double monto4CC = 0.0;

        double monto1AM = 0.0;
        double monto2AM = 0.0;
        double monto3AM = 0.0;


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

            for(int i = 1; i < 5; i++) 
            {
                switch (i) 
                {
                    
                    case 1:

                        comandosRecibos.getConcepto = "Coperación-selección";
                        comandosRecibos.getTipo_Tarifa = 'c';
                        comandosRecibos.consultaMontos(out monto);
                        monto1CC = monto;
                        labelCopSel.Text = monto1CC.ToString();

                        break;

                        case 2:
                        comandosRecibos.getConcepto = "Coperación-terrenos";
                        comandosRecibos.getTipo_Tarifa = 'c';
                        comandosRecibos.consultaMontos(out monto);
                        monto2CC = monto;
                        labelCopTer.Text = monto2CC.ToString();
                        break; 

                    case 3:
                        comandosRecibos.getConcepto = "Membresía";
                        comandosRecibos.getTipo_Tarifa = 'c';
                        comandosRecibos.consultaMontos(out monto);
                        monto3CC = monto;
                        labelMembresia.Text = monto3CC.ToString();
                        break; 

                    case 4:
                         comandosRecibos.getConcepto = "Defunción";
                        comandosRecibos.getTipo_Tarifa = 'c';
                        comandosRecibos.consultaMontos(out monto);
                        monto4CC = monto;
                        labelDefuncion.Text = monto4CC.ToString();
                        break;

                }
            }

            for (int i = 1; i < 4; i++)
            {
                switch (i)
                {

                    case 1:

                        comandosRecibos.getConcepto = "Coperación-selección";
                        comandosRecibos.getTipo_Tarifa = 'a';
                        comandosRecibos.consultaMontos(out monto);
                        monto1AM = monto;
                        labelSecAM.Text = monto1AM.ToString();
                        break;

                    case 2:
                        comandosRecibos.getConcepto = "Coperación-terrenos";
                        comandosRecibos.getTipo_Tarifa = 'a';
                        comandosRecibos.consultaMontos(out monto);
                        monto2AM = monto;
                        labelTEAM.Text = monto2AM.ToString();
                        break;

                    case 3:
                        comandosRecibos.getConcepto = "Membresía";
                        comandosRecibos.getTipo_Tarifa = 'a';
                        comandosRecibos.consultaMontos(out monto);
                        monto2AM = monto;
                        labelAMMem.Text = monto2AM.ToString();
                        break;

                   

                }
            }
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


     

        private double sumatoria = 0;

        private void checkedListBoxCC_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int indice = e.Index;
            bool estadoNuevo = e.NewValue == CheckState.Checked;

            switch (indice)
            {
                case 0:
                    // Manejar la lógica para el caso 0 (índice 0)
                    sumatoria += estadoNuevo ? monto1CC : -monto1CC;
                    break;

                case 1:
                    // Manejar la lógica para el caso 1 (índice 1)
                    sumatoria += estadoNuevo ? monto2CC : -monto2CC;
                    break;

                case 2:
                    // Manejar la lógica para el caso 2 (índice 2)
                    sumatoria += estadoNuevo ? monto3CC : -monto3CC;
                    break;

                case 3:
                    // Manejar la lógica para el caso 3 (índice 3)
                    sumatoria += estadoNuevo ? monto4CC : -monto4CC;
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


        private void button2_Click(object sender, EventArgs e)
        {
            if (labelNum.Text == null)
            {
                MessageBox.Show("No hay datos para generar el PDF.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Salir del método si no hay datos
            }


            // Crear un nuevo documento PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "RECIBO CASA CLUB";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Arial", 12, XFontStyle.Bold); // Fuente para el título
            XFont font = new XFont("Arial", 8, XFontStyle.Bold); // Fuente para los datos
            int startX = 20;
            int titleY = 20;
            int startY = titleY + 30;
            int cellWidth = 100;
            int cellHeight = 20;

            // Agregar el título
            gfx.DrawString("RECIBO CASA CLUB", titleFont, XBrushes.Black, new XRect(startX, titleY, page.Width - startX * 2, 20), XStringFormats.Center);

            int maxLabelWidth = 200; // Ajusta según el ancho máximo permitido

            // Información de los Labels
            string[,] datosLabels = {
        { "TITULO", "DATOS" },
        { "Numero de socio", labelNum.Text },
        { "Nombre", labelNombre.Text },
        { "Apellido paterno", labelA_Paterno.Text },
        { "Apellido materno", labelA_Materno.Text },
        { "Fecha de Nacimiento", labelFechaNacimiento.Text },
        { "Telefono", labelTelefono.Text },
        { "Correo", labelCorreo.Text },
        { "Curp", labelCurp.Text },
        { "Direccion", labelDireccion.Text },
        { "Suma monto", sumatoria.ToString() }

            };

            // Dibujar encabezados de columna y agregar bordes a la primera fila
            for (int colIndex = 0; colIndex < datosLabels.GetLength(1); colIndex++)
            {
                gfx.DrawRectangle(XBrushes.LightGray, startX + colIndex * cellWidth, startY, cellWidth, cellHeight);
                gfx.DrawString(datosLabels[0, colIndex], font, XBrushes.Black,
                                new XRect(startX + colIndex * cellWidth, startY, cellWidth, cellHeight), XStringFormats.Center);

                // Agregar bordes a la primera fila
                gfx.DrawLine(XPens.Black, startX + colIndex * cellWidth, startY, startX + colIndex * cellWidth, startY + cellHeight);
                gfx.DrawLine(XPens.Black, startX + (colIndex + 1) * cellWidth, startY, startX + (colIndex + 1) * cellWidth, startY + cellHeight);
            }

            // Dibujar datos de los Labels
            for (int rowIndex = 1; rowIndex < datosLabels.GetLength(0); rowIndex++) // Comenzar desde la fila 1 para evitar repetir el encabezado
            {
                for (int colIndex = 0; colIndex < datosLabels.GetLength(1); colIndex++)
                {
                    gfx.DrawRectangle(XBrushes.White, startX + colIndex * cellWidth, startY + rowIndex * cellHeight, cellWidth, cellHeight);
                    string valueText = datosLabels[rowIndex, colIndex];

                    // Reducir el tamaño de la fuente si el texto es demasiado largo para caber en la celda
                    float fontSize = 8; // Tamaño de fuente inicial
                    XFont cellFont = new XFont("Arial", fontSize);
                    while (gfx.MeasureString(valueText, cellFont).Width > cellWidth - 2) // 2 es un margen para evitar que se sobrepase
                    {
                        fontSize -= 1;
                        cellFont = new XFont("Arial", fontSize);
                    }

                    gfx.DrawString(valueText, cellFont, XBrushes.Black,
                                    new XRect(startX + colIndex * cellWidth, startY + rowIndex * cellHeight, cellWidth, cellHeight), XStringFormats.Center);

                    // Agregar bordes a cada fila y columna
                    gfx.DrawLine(XPens.Black, startX + colIndex * cellWidth, startY + rowIndex * cellHeight, startX + (colIndex + 1) * cellWidth, startY + rowIndex * cellHeight); // Horizontal
                    gfx.DrawLine(XPens.Black, startX + colIndex * cellWidth, startY + rowIndex * cellHeight, startX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight); // Vertical
                }
            }

            // Agregar líneas de borde al final de cada fila
            for (int rowIndex = 0; rowIndex < datosLabels.GetLength(0); rowIndex++)
            {
                gfx.DrawLine(XPens.Black, startX, startY + rowIndex * cellHeight, startX + datosLabels.GetLength(1) * cellWidth, startY + rowIndex * cellHeight);
            }

            // Agregar bordes alrededor de toda la tabla
            gfx.DrawLine(XPens.Black, startX, startY, startX, startY + datosLabels.GetLength(0) * cellHeight);
            gfx.DrawLine(XPens.Black, startX + datosLabels.GetLength(1) * cellWidth, startY, startX + datosLabels.GetLength(1) * cellWidth, startY + datosLabels.GetLength(0) * cellHeight);
            gfx.DrawLine(XPens.Black, startX, startY, startX + datosLabels.GetLength(1) * cellWidth, startY);
            gfx.DrawLine(XPens.Black, startX, startY + datosLabels.GetLength(0) * cellHeight, startX + datosLabels.GetLength(1) * cellWidth, startY + datosLabels.GetLength(0) * cellHeight);

            // Guardar el documento PDF en un archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF|*.pdf",
                Title = "Guardar PDF",
                FileName = "RECIBO CASA CLUB.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
            }
        }



        //lista de checkbox

        private double sumatoria2 = 0;


        private void checkedListBoxAM_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            int indice = e.Index;
            bool estadoNuevo = e.NewValue == CheckState.Checked;

            switch (indice)
            {
                case 0:
                    // Manejar la lógica para el caso 0 (índice 0)
                    sumatoria2 += estadoNuevo ? monto1AM : -monto1AM;
                    break;

                case 1:
                    // Manejar la lógica para el caso 1 (índice 1)
                    sumatoria2 += estadoNuevo ? monto2AM : -monto2AM;
                    break;

                case 2:
                    // Manejar la lógica para el caso 2 (índice 2)
                    sumatoria2 += estadoNuevo ? monto3AM : -monto3AM;
                    break;

                default:
                    Console.WriteLine("ERROR EN LA SUMATORIA");
                    break;
            }

            sumatoria2 = Math.Max(0, sumatoria2); // Asegura que el valor mínimo sea 0

            labelTotalAM.Text = sumatoria2.ToString();
        }


 



      




        //descargar pdf
        private void button3_Click(object sender, EventArgs e)
        {
            if (labelNum.Text == null)
            {
                MessageBox.Show("No hay datos para generar el PDF.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Salir del método si no hay datos
            }

            // Crear un nuevo documento PDF
            PdfDocument document = new PdfDocument();
            document.Info.Title = "RECIBO AYUDA MUTUA";
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Arial", 12, XFontStyle.Bold); // Fuente para el título
            XFont font = new XFont("Arial", 8, XFontStyle.Bold); // Fuente para los datos
            int startX = 20;
            int titleY = 20;
            int startY = titleY + 30;
            int cellWidth = 100;
            int cellHeight = 20;

            // Agregar el título
            gfx.DrawString("RECIBO AYUDA MUTUA", titleFont, XBrushes.Black, new XRect(startX, titleY, page.Width - startX * 2, 20), XStringFormats.Center);

            int maxLabelWidth = 200; // Ajusta según el ancho máximo permitido

            // Información de los Labels
            string[,] datosLabels = {
        { "TITULO", "DATOS" },
        { "Numero de socio", labelNum.Text },
        { "Nombre", labelNombre.Text },
        { "Apellido paterno", labelA_Paterno.Text },
        { "Apellido materno", labelA_Materno.Text },
        { "Fecha de Nacimiento", labelFechaNacimiento.Text },
        { "Telefono", labelTelefono.Text },
        { "Correo", labelCorreo.Text },
        { "Curp", labelCurp.Text },
        { "Direccion", labelDireccion.Text },
        { "Suma monto", sumatoria2.ToString() }

            };

            // Dibujar encabezados de columna y agregar bordes a la primera fila
            for (int colIndex = 0; colIndex < datosLabels.GetLength(1); colIndex++)
            {
                gfx.DrawRectangle(XBrushes.LightGray, startX + colIndex * cellWidth, startY, cellWidth, cellHeight);
                gfx.DrawString(datosLabels[0, colIndex], font, XBrushes.Black,
                                new XRect(startX + colIndex * cellWidth, startY, cellWidth, cellHeight), XStringFormats.Center);

                // Agregar bordes a la primera fila
                gfx.DrawLine(XPens.Black, startX + colIndex * cellWidth, startY, startX + colIndex * cellWidth, startY + cellHeight);
                gfx.DrawLine(XPens.Black, startX + (colIndex + 1) * cellWidth, startY, startX + (colIndex + 1) * cellWidth, startY + cellHeight);
            }

            // Dibujar datos de los Labels
            for (int rowIndex = 1; rowIndex < datosLabels.GetLength(0); rowIndex++) // Comenzar desde la fila 1 para evitar repetir el encabezado
            {
                for (int colIndex = 0; colIndex < datosLabels.GetLength(1); colIndex++)
                {
                    gfx.DrawRectangle(XBrushes.White, startX + colIndex * cellWidth, startY + rowIndex * cellHeight, cellWidth, cellHeight);
                    string valueText = datosLabels[rowIndex, colIndex];

                    // Reducir el tamaño de la fuente si el texto es demasiado largo para caber en la celda
                    float fontSize = 8; // Tamaño de fuente inicial
                    XFont cellFont = new XFont("Arial", fontSize);
                    while (gfx.MeasureString(valueText, cellFont).Width > cellWidth - 2) // 2 es un margen para evitar que se sobrepase
                    {
                        fontSize -= 1;
                        cellFont = new XFont("Arial", fontSize);
                    }

                    gfx.DrawString(valueText, cellFont, XBrushes.Black,
                                    new XRect(startX + colIndex * cellWidth, startY + rowIndex * cellHeight, cellWidth, cellHeight), XStringFormats.Center);

                    // Agregar bordes a cada fila y columna
                    gfx.DrawLine(XPens.Black, startX + colIndex * cellWidth, startY + rowIndex * cellHeight, startX + (colIndex + 1) * cellWidth, startY + rowIndex * cellHeight); // Horizontal
                    gfx.DrawLine(XPens.Black, startX + colIndex * cellWidth, startY + rowIndex * cellHeight, startX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight); // Vertical
                }
            }

            // Agregar líneas de borde al final de cada fila
            for (int rowIndex = 0; rowIndex < datosLabels.GetLength(0); rowIndex++)
            {
                gfx.DrawLine(XPens.Black, startX, startY + rowIndex * cellHeight, startX + datosLabels.GetLength(1) * cellWidth, startY + rowIndex * cellHeight);
            }

            // Agregar bordes alrededor de toda la tabla
            gfx.DrawLine(XPens.Black, startX, startY, startX, startY + datosLabels.GetLength(0) * cellHeight);
            gfx.DrawLine(XPens.Black, startX + datosLabels.GetLength(1) * cellWidth, startY, startX + datosLabels.GetLength(1) * cellWidth, startY + datosLabels.GetLength(0) * cellHeight);
            gfx.DrawLine(XPens.Black, startX, startY, startX + datosLabels.GetLength(1) * cellWidth, startY);
            gfx.DrawLine(XPens.Black, startX, startY + datosLabels.GetLength(0) * cellHeight, startX + datosLabels.GetLength(1) * cellWidth, startY + datosLabels.GetLength(0) * cellHeight);

            // Guardar el documento PDF en un archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF|*.pdf",
                Title = "Guardar PDF",
                FileName = "RECIBO AYUDA MUTUA.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
            }
        }

        //boton de guardar
        private void button4_Click(object sender, EventArgs e)
        {
           
                comandos.getID = int.TryParse(textBoxIdSocio.Text.Trim(), out int result) ? result : 0;
            try
            {
                comandos.pagado();
            } catch 
            {
                MessageBox.Show("Error en la actualizacion", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


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

        
        
     