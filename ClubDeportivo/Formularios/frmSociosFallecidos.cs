using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivo.Clases;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
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
            if (dgvDefunciones.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el PDF.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Salir del método si no hay datos
            }

            // Crear un nuevo documento PDF con orientación horizontal
            PdfDocument document = new PdfDocument();
            document.Info.Title = "DEFUNCIONES";
            PdfPage page = document.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Arial", 12, XFontStyle.Bold); // Fuente para el título
            XFont font = new XFont("Arial", 8, XFontStyle.Bold); // Fuente para el encabezado
            XFont dataFont = new XFont("Arial", 6);

            // Obtener los datos del DataGridView
            DataTable dataTable = GetDataTableFromDataGridView(dgvDefunciones);

            // Establecer las dimensiones y la posición inicial de la tabla
            //const int startX = 20;
            const int titleY = 20; // Posición para el título
            int startY = titleY + 30; // Ajustado para centrar la tabla
            const int cellWidth = 100;
            const int cellHeight = 20;

            // Calcular el ancho total de la tabla
            int tableWidth = cellWidth * dataTable.Columns.Count;

            // Calcular la posición inicial para centrar la tabla
            int centerX = (int)((page.Width - tableWidth) / 2);

            // Agregar el título
            gfx.DrawString("Lista de Defunciones", titleFont, XBrushes.Black, new XRect(centerX, titleY, tableWidth, 20), XStringFormats.Center);

            // Dibujar encabezados de columna y agregar bordes a la primera fila
            for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
            {
                gfx.DrawRectangle(XBrushes.LightGray, centerX + colIndex * cellWidth, startY, cellWidth, cellHeight);
                gfx.DrawString(dataTable.Columns[colIndex].ColumnName, font, XBrushes.Black,
                                new XRect(centerX + colIndex * cellWidth, startY, cellWidth, cellHeight), XStringFormats.Center);

                // Agregar bordes a la primera fila
                gfx.DrawLine(XPens.Black, centerX + colIndex * cellWidth, startY, centerX + colIndex * cellWidth, startY + cellHeight);
                gfx.DrawLine(XPens.Black, centerX + (colIndex + 1) * cellWidth, startY, centerX + (colIndex + 1) * cellWidth, startY + cellHeight);
            }

            // Dibujar filas de datos y agregar bordes a cada fila
            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    gfx.DrawRectangle(XBrushes.White, centerX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight, cellWidth, cellHeight);
                    gfx.DrawString(dataTable.Rows[rowIndex][colIndex].ToString(), dataFont, XBrushes.Black,
                                    new XRect(centerX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight, cellWidth, cellHeight), XStringFormats.Center);

                    // Agregar bordes a cada fila
                    gfx.DrawLine(XPens.Black, centerX, startY + (rowIndex + 1) * cellHeight, centerX + tableWidth, startY + (rowIndex + 1) * cellHeight);
                    gfx.DrawLine(XPens.Black, centerX + colIndex * cellWidth, startY, centerX + colIndex * cellWidth, startY + cellHeight);
                    gfx.DrawLine(XPens.Black, centerX + (colIndex + 1) * cellWidth, startY, centerX + (colIndex + 1) * cellWidth, startY + cellHeight);
                }
            }

            // Agregar bordes alrededor de toda la tabla
            gfx.DrawLine(XPens.Black, centerX, startY, centerX, startY + cellHeight * (dataTable.Rows.Count + 1));
            gfx.DrawLine(XPens.Black, centerX + tableWidth, startY, centerX + tableWidth, startY + cellHeight * (dataTable.Rows.Count + 1));
            gfx.DrawLine(XPens.Black, centerX, startY, centerX + tableWidth, startY);
            gfx.DrawLine(XPens.Black, centerX, startY + cellHeight * (dataTable.Rows.Count + 1), centerX + tableWidth, startY + cellHeight * (dataTable.Rows.Count + 1));

            // Guardar el documento PDF en un archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF|*.pdf",
                Title = "Guardar PDF",
                FileName = "DEFUNCIONES.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
            }
        }


        // Método para obtener DataTable desde DataGridView
        private DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Agregar columnas a la tabla
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            // Agregar filas a la tabla
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var dataRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dataRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }


    }
}
