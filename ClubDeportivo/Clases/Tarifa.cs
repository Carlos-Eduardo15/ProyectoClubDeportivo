using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Clases
{
    class Tarifa
    {
        private int _id_tarifa;
        private string _concepto;
        private double _monto;
        private string _tipo_tarifa;

        //Constructores
        public Tarifa()
        {
            _id_tarifa = 0;
            _concepto = null;
            _monto = 0.00;
            _tipo_tarifa = null;
        }

        public Tarifa(int idTarifa, string concepto, double monto, string tipoTarifa)
        {
            _id_tarifa = idTarifa;
            _concepto = concepto;
            _monto = monto;
            _tipo_tarifa = tipoTarifa;
        }

        public int getSetIdTarifa
        {
            get { return _id_tarifa; }
            set { _id_tarifa = value; }
        }
        public string getSetConcepto
        {
            get { return _concepto; }
            set { _concepto = value; }
        }
        public double getSetMonto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        public string getSetTipoTarifa
        {
            get { return _tipo_tarifa; }
            set { _tipo_tarifa = value; }
        }

        //Métodos operativos
        public void insertarTarifa(string concepto, double monto, string tipo_tarifa)
        {
            string sql = null;
            string connectionString = VGlobal.getSetConexion; // Obtiene la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Prepara la consulta SQL con parámetros para evitar la inyección de SQL
                    sql = "INSERT INTO tarifas (concepto, monto, tipo_tarifa) VALUES (@Concepto, @Monto, @TipoTarifa)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Agrega los parámetros a la consulta SQL
                        command.Parameters.AddWithValue("@Concepto", concepto);
                        command.Parameters.AddWithValue("@Monto", monto);
                        command.Parameters.AddWithValue("@TipoTarifa", tipo_tarifa);

                        // Ejecuta la consulta SQL
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Se guardaron los datos.");
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error al registrar la tarifa. \n" + e.Message.ToString());
            }
        }

        public void modificarTarifa(string concepto, double monto, int id_tarifa)
        {
            string sql = null;
            string connectionString = VGlobal.getSetConexion; // Obtener la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Prepara la consulta SQL con parámetros para evitar la inyección de SQL
                    sql = "UPDATE tarifas SET concepto = @Concepto, monto = @Monto WHERE id_tarifa = @IdTarifa";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Agrega los parámetros a la consulta SQL
                        command.Parameters.AddWithValue("@Concepto", concepto);
                        command.Parameters.AddWithValue("@Monto", monto);
                        command.Parameters.AddWithValue("@IdTarifa", id_tarifa);

                        // Ejecuta la consulta SQL
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Se han actualizado los datos.");
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo modificar el dato.\n" + e.Message.ToString());
            }
        }

        public void consultarTarifas(DataGridView dgv, string tipo_tarifa)
        {
            string sql = "SELECT id_tarifa, concepto, monto FROM tarifas WHERE tipo_tarifa = @TipoTarifa";
            DataTable data = new DataTable();
            string connectionString = VGlobal.getSetConexion; // Obtener la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TipoTarifa", tipo_tarifa);

                        // Crea un SqlDataAdapter para ejecutar la consulta y llenar el DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(data);
                    }
                }

                // Establece el origen de datos del DataGridView
                dgv.DataSource = data;
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error en la consulta. \n" + e.Message.ToString());
            }
        }

        public void consultarTarifaEspecifica(int id_tarifa, TextBox monto)
        {
            string sql = "SELECT id_tarifa, concepto, monto FROM tarifas WHERE id_tarifa = @IdTarifa";
            string connectionString = VGlobal.getSetConexion; // Obtener la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@IdTarifa", id_tarifa);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                monto.Text = reader["monto"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("No se encontró el resultado.");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error en la consulta. \n" + e.Message.ToString());
            }
        }
    }   
}
