using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Formularios.SociosForms
{
    public partial class ConsultaPadron : Form
    {
        private int selectedIndex;

        public ConsultaPadron()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
          
        }



        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = checkedListBox1.SelectedIndex;

            // Desmarcar todos los elementos
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            Console.WriteLine("Elemento seleccionado: " + checkedListBox1.Items[selectedIndex].ToString());

            CargarDatos();
        }

        private void CargarDatos()
        {
            // Conexión a la base de datos (ajusta la cadena de conexión según tu entorno)
            using (SqlConnection connection = new SqlConnection(VGlobal.getSetConexion))
            {
                // Construir la consulta SQL en función del índice seleccionado
                string query = ConstruirConsulta();

                // Crear el adaptador de datos y el DataTable
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                // Llenar el DataTable con los resultados de la consulta
                adapter.Fill(dataTable);

                dataGridView1.DataSource = null;

                // Asignar el DataTable como origen de datos para el DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private string ConstruirConsulta()
        {
            // Utilizar un switch para determinar la consulta según el índice seleccionado
            switch (selectedIndex)
            {
                case 0:
                    return @"
                    SELECT id_socio AS Id, nombre As Nombre, curp AS Curp, edad AS Edad , telefono AS Telefono, CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado
                    FROM Socios where tipo_socio = 'S'";
                case 1:
                    return @"
                    SELECT id_socio AS Id, nombre As Nombre, curp AS Curp, edad AS Edad , telefono AS Telefono, CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado
                    FROM Socios where tipo_socio = 'I'";
                case 2:
                    return @"
                    SELECT id_socio AS Id, nombre As Nombre, curp AS Curp, edad AS Edad , telefono AS Telefono, 
                        CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado
                    FROM Socios WHERE [fecha_cambio_estatus] IS NOT NULL";
                case 3:
                    return @"
                    SELECT id_socio AS Id, nombre As Nombre, curp AS Curp, edad AS Edad , telefono AS Telefono, 
                        CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS Estado
                    FROM Socios";
                default:
                    return "SELECT * FROM Socios";
            }
        }

        private void ConsultaPadron_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'clubDeportivoDataSet.Socios' table. You can move, or remove it, as needed.
            this.sociosTableAdapter.Fill(this.clubDeportivoDataSet.Socios);
            // Puedes agregar lógica de inicialización aquí si es necesario
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para generar el PDF.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;  // Salir del método si no hay datos
            }


            string subtitulo = "";
            string titulo = "";

            switch (selectedIndex)
            {
                case 0:
                    subtitulo = "TODOS LOS SOCIOS";
                    titulo = "LISTA SOCIOS";
                    break;
                case 1:
                    subtitulo = "TODOS LOS INVITADOS";
                    titulo = "LISTA INVITADOS";

                    break;
                case 2:
                    subtitulo = "TODOS LOS FALLECIDOS";
                    titulo = "LISTA FALLECIDOS";

                    break;
                case 3:
                    subtitulo = "TODOS LOS SOCIOS E INVITADOS";
                    titulo = "LISTA TODOS";

                    break;
            }

            // Crear un nuevo documento PDF con orientación vertical
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Defunciones";
            PdfPage page = document.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Portrait;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Arial", 12, XFontStyle.Bold); // Fuente para el título
            XFont font = new XFont("Arial", 8, XFontStyle.Bold); // Fuente para el encabezado
            XFont dataFont = new XFont("Arial", 6);

            // Obtener los datos del DataGridView
            DataTable dataTable = GetDataTableFromDataGridView(dataGridView1);

            // Establecer las dimensiones y la posición inicial de la tabla
            int startX = 20;
            int titleY = 10; // Posición para el título
            int startY = titleY + 30; // Ajustado para centrar la tabla
            int cellWidth = 100;
            int cellHeight = 20;

            // Calcular el ancho total de la tabla
            int tableWidth = cellWidth * dataTable.Columns.Count;

            // Calcular la posición inicial para centrar la tabla
            int centerX = (int)((page.Width - tableWidth) / 2);

            // Agregar el título

            string tituloCompleto = "LISTADO GENERAL DE " + subtitulo;

            gfx.DrawString(tituloCompleto, titleFont, XBrushes.Black, new XRect(centerX, titleY, tableWidth, 40), XStringFormats.Center);

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

            // Dibujar filas de datos y agregar bordes a cada fila y columna
            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                {
                    gfx.DrawRectangle(XBrushes.White, centerX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight, cellWidth, cellHeight);
                    gfx.DrawString(dataTable.Rows[rowIndex][colIndex].ToString(), dataFont, XBrushes.Black,
                                    new XRect(centerX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight, cellWidth, cellHeight), XStringFormats.Center);

                    // Agregar bordes a cada fila y columna
                    gfx.DrawLine(XPens.Black, centerX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight, centerX + (colIndex + 1) * cellWidth, startY + (rowIndex + 1) * cellHeight); // Horizontal
                    gfx.DrawLine(XPens.Black, centerX + colIndex * cellWidth, startY + rowIndex * cellHeight, centerX + colIndex * cellWidth, startY + (rowIndex + 1) * cellHeight); // Vertical
                }
            }

            // Agregar líneas de borde al final de cada fila
            for (int rowIndex = 0; rowIndex <= dataTable.Rows.Count; rowIndex++)
            {
                gfx.DrawLine(XPens.Black, centerX, startY + rowIndex * cellHeight, centerX + tableWidth, startY + rowIndex * cellHeight);
            }

            // Agregar bordes alrededor de toda la tabla
            gfx.DrawLine(XPens.Black, centerX, startY, centerX, startY + (dataTable.Rows.Count + 1) * cellHeight);
            gfx.DrawLine(XPens.Black, centerX + tableWidth, startY, centerX + tableWidth, startY + (dataTable.Rows.Count + 1) * cellHeight);
            gfx.DrawLine(XPens.Black, centerX, startY, centerX + tableWidth, startY);
            gfx.DrawLine(XPens.Black, centerX, startY + (dataTable.Rows.Count + 1) * cellHeight, centerX + tableWidth, startY + (dataTable.Rows.Count + 1) * cellHeight);

            // Guardar el documento PDF en un archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivos PDF|*.pdf",
                Title = "Guardar PDF",
                FileName = $"{titulo}.pdf"  
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                document.Save(saveFileDialog.FileName);
            }
        }



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
