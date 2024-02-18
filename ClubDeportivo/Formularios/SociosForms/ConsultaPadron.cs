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
                    SELECT id_socio, nombre, curp, edad, telefono, CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS estado
                    FROM Socios where tipo_socio = 'S'";
                case 1:
                    return @"
                    SELECT id_socio, nombre, curp, edad, telefono, CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS estado
                    FROM Socios where tipo_socio = 'I'";
                case 2:
                    return @"
                    SELECT id_socio, nombre, curp, edad, telefono, 
                        CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS estado
                    FROM Socios WHERE [fecha_cambio_estatus] IS NOT NULL";
                case 3:
                    return @"
                    SELECT id_socio, nombre, curp, edad, telefono, 
                        CASE WHEN [fecha_cambio_estatus] IS NULL THEN 'Activo' ELSE 'Inactivo' END AS estado
                    FROM Socios";
                default:
                    return "SELECT * FROM Socios";
            }
        }

        private void ConsultaPadron_Load(object sender, EventArgs e)
        {
            // Puedes agregar lógica de inicialización aquí si es necesario
        }
    }
}
