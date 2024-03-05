using ClubDeportivo.Conectividad;
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
    class Defuncion
    {
        public int _id_defuncion;
        public int _id_socio;
        public DateTime _fecha_defuncion;
        public string _beneficiario;
        public double _monto;

        public Defuncion()
        {
            _id_defuncion = 0;
            _id_socio = 0;
            _fecha_defuncion = DateTime.MinValue;
            _beneficiario = null;
            _monto = 0;
        }
        public Defuncion(int id_defuncion, int id_socio, DateTime fecha_defuncion, string beneficiario, double monto)
        {
            _id_defuncion = id_defuncion;
            _id_socio = id_socio;
            _fecha_defuncion = fecha_defuncion;
            _beneficiario = beneficiario;
            _monto = monto;
        }

        public int getSetIdDefuncion
        {
            get { return _id_defuncion; }
            set { _id_defuncion = value; }
        }

        public int getSetIdSocio
        {
            get { return _id_socio; }
            set { _id_socio = value; }
        }
        public DateTime getSetFechaDefuncion
        {
            get { return _fecha_defuncion; }
            set { _fecha_defuncion = value; }
        }
        public string getSetBeneficiario
        {
            get { return _beneficiario; }
            set { _beneficiario = value; }
        }
        public double getSetMonto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public void consultarSocio(int id_socio, TextBox nombre, TextBox paterno, TextBox materno, TextBox curp, TextBox fecha_nacimiento,TextBox direccion, TextBox correo, TextBox telefono, TextBox fecha_ingreso, TextBox tipo_socio)
        {
            string sql = "SELECT id_socio, nombre, ap_paterno, ap_materno, curp, fecha_nacimiento, direccion, correo, telefono, fecha_ingreso, tipo_socio " +
                        "FROM Socios WHERE id_socio = @IdSocio";
            string connectionString = VGlobal.getSetConexion; // Obtener la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@IdSocio", id_socio);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                nombre.Text = reader["nombre"] is DBNull ? "" : reader["nombre"].ToString();
                                paterno.Text = reader["ap_paterno"] is DBNull ? "" : reader["ap_paterno"].ToString();
                                materno.Text = reader["ap_materno"] is DBNull ? "" : reader["ap_materno"].ToString();
                                curp.Text = reader["curp"] is DBNull ? "" : reader["curp"].ToString();
                                fecha_nacimiento.Text = calcularEdad(reader["fecha_nacimiento"]);
                                direccion.Text = reader["direccion"] is DBNull ? "" : reader["direccion"].ToString();
                                correo.Text = reader["correo"] is DBNull ? "" : reader["correo"].ToString();
                                telefono.Text = reader["telefono"] is DBNull ? "" : reader["telefono"].ToString();
                                fecha_ingreso.Text = formatoFechas(reader["fecha_ingreso"]);
                                tipo_socio.Text = formatoTipoSocio(reader["tipo_socio"]);
                            }
                            else
                            {
                                MessageBox.Show("No se encontró ningún dato asociado al número de socio.");
                                nombre.Text = "";
                                paterno.Text = "";
                                materno.Text = "";
                                fecha_nacimiento.Text = "";
                                direccion.Text = "";
                                correo.Text = "";
                                telefono.Text = "";
                                fecha_ingreso.Text = "";
                                tipo_socio.Text = "";
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

        public void registrarDefuncion(int id_socio, string defuncion, string beneficiario, double monto)
        {
            string sql = "INSERT INTO Defunciones (id_socio, fecha_defuncion, beneficiario, monto) " +
                            "VALUES (@IdSocio, @FechaDefuncion, @Beneficiario, @Monto)";
            string connectionString = VGlobal.getSetConexion; // Obtener la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@IdSocio", id_socio);
                        command.Parameters.AddWithValue("@FechaDefuncion", defuncion);
                        command.Parameters.AddWithValue("@Beneficiario", beneficiario);
                        command.Parameters.AddWithValue("@Monto", monto);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Se guardaron los datos");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Hubo un error al registrar la defunción. \n" + e.Message.ToString());
            }
        }

        public void consultarBeneficiario(int id_socio, TextBox beneficiario, TextBox monto, DateTimePicker fecha_defuncion)
        {
            string sql = "SELECT fecha_defuncion, beneficiario, monto FROM Defunciones WHERE id_socio = @IdSocio";
            string connectionString = VGlobal.getSetConexion; // Obtener la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@IdSocio", id_socio);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read() && !reader.IsDBNull(0))
                        {
                            fecha_defuncion.Value = reader.GetDateTime(0);
                            beneficiario.Text = reader.GetString(1);
                            monto.Text = reader.GetDouble(2).ToString();
                        }
                        else
                        {
                            beneficiario.Text = "Nombre completo";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al consultar los datos.\n" + e.Message);
            }

        }

        public void consultarDefunciones( DataGridView dgv)
        {
            string sql = "SELECT s.id_socio, CONCAT(s.nombre, ' ', s.ap_paterno, ' ', s.ap_materno) AS nombre_completo, s.fecha_nacimiento, d.fecha_defuncion, d.beneficiario, d.monto " +
                            "FROM Socios s INNER JOIN Defunciones d ON s.id_socio = d.id_socio";

            string connectionString = VGlobal.getSetConexion; // Obtener la cadena de conexión de la clase VGlobal

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    dgv.DataSource = data;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cargar los datos.\n\n" + e.Message);
            }
        }
        private string formatoFechas(object dateValue)
        {
            if (dateValue is DBNull)
                return "";

            DateTime date = (DateTime)dateValue;
            return date.ToString("dd/MM/yyyy"); // Formato de fecha deseado (día/mes/año)
        }
        private string formatoTipoSocio(object tipoSocio)
        {
            if (tipoSocio.ToString() == "s" || tipoSocio.ToString() == "S")
            {
                return "Socio";
            }
            else
            {
                return "Invitado";
            }
        }
        private string calcularEdad(object dateValue)
        {
            if (dateValue is DBNull)
            {
                return "";
            }

            DateTime fechaNacimiento = (DateTime)dateValue;
            DateTime fechaActual = DateTime.Today;

            int años = fechaActual.Year - fechaNacimiento.Year;

            // Ajustar la edad si todavía no ha pasado el cumpleaños de este año
            if (fechaNacimiento.Date > fechaActual.AddYears(-años))
            {
                años--;
            }

            return años.ToString(); // Edad como una cadena
        }


    }
}
