using ClubDeportivo.ClubDeportivoDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Clases
{
    public class SQLSocios
    {
        private string numeroSocios;
        private string nombreSocios;
        private string apellidoPaternoSocios;
        private string apellidoMaternoSocios;
        private string curpSocios;
        private DateTime? fechaNacimientoSocios;
        private string telefonoSocios;
        private string correoSocios;
        private string direccionSocios;
        private DateTime? fechaIngresoSocios;
        private int edadSocios;
        private int idSocios;


        public SQLSocios()
        {
            numeroSocios = null;
            nombreSocios = null;
            apellidoPaternoSocios = null;
            apellidoMaternoSocios = null;
            curpSocios = null;
            fechaNacimientoSocios = null;
            telefonoSocios = null;
            correoSocios = null;
            direccionSocios = null;
            fechaIngresoSocios = null;
            edadSocios = 0;
            idSocios = 0;

        }
        public SQLSocios(string numero, string nombre, string apellidoPaterno, string apellidoMaterno, string curp,DateTime? fechaNacimiento, string telefono, string correo, string direccion, DateTime? fechaIngreso, int edad, int id)
        {
            this.numeroSocios = numero;
            this.nombreSocios = nombre;
            this.apellidoPaternoSocios = apellidoPaterno;
            this.apellidoMaternoSocios = apellidoMaterno;
            this.curpSocios = curp;
            this.fechaNacimientoSocios = fechaNacimiento;
            this.telefonoSocios = telefono;
            this.correoSocios = correo;
            this.direccionSocios = direccion;
            this.fechaIngresoSocios = fechaIngreso;
            this.edadSocios = edad;
            this.idSocios = id;
        }
        public string getNombre
        {
            get { return nombreSocios; }
            set { nombreSocios = value; }
        }
        public string getNumero
        {
            get { return numeroSocios; }
            set { numeroSocios = value; }
        }
        public string getApellidoPaterno
        {
            get { return apellidoPaternoSocios; }
            set { apellidoPaternoSocios = value; }
        }
        public string getApellidoMaterno
        {
            get { return apellidoMaternoSocios; }
            set { apellidoMaternoSocios = value; }

        }
        public string getCurp
        {
            get { return curpSocios; }
            set { curpSocios = value; }
        }
        public DateTime? getFechaNacimiento
        {
            get { return fechaNacimientoSocios; }
            set { fechaNacimientoSocios = value; }
        }
        public string getTelefono
        {
            get { return telefonoSocios; }
            set { telefonoSocios = value; }
        }
        public string getCorreo
        {
            get { return correoSocios; }
            set { correoSocios = value; }
        }
        public string getDireccion
        {
            get { return direccionSocios; }
            set { direccionSocios = value; }
        }

        public DateTime? getFechaIngreso
        {
            get { return fechaIngresoSocios; }
            set { fechaIngresoSocios = value; }
        }

        public int getEdad
        {
            get { return edadSocios; }
            set { edadSocios = value; }
        }

        public int getID 
        {
            get { return idSocios; }
            set {  idSocios = value; }
        }

        public int ObtenerNuevoIdSocio()
        {
            int nuevoId = 0;  // Inicializa la variable para evitar problemas en caso de que no se obtenga ningún ID

            using (SqlConnection conexion = new SqlConnection(VGlobal.getSetConexion))
            {
                string queryId = "SELECT MAX(id_socio) FROM Socios";

                try
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand(queryId, conexion))
                    {
                        // Ejecuta la consulta y obtén el resultado
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            // Convierte el resultado a un entero y suma 1
                            nuevoId = Convert.ToInt32(result) + 1;
                        }
                        else
                        {
                            // Maneja el caso donde no hay ningún socio en la tabla
                            // Puedes decidir qué hacer en esta situación
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error SQL al obtener el nuevo ID socio: " + sqlEx.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el nuevo ID socio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return nuevoId;
        }

        public void insertarSocio()
        {
            using (SqlConnection conexion = new SqlConnection(VGlobal.getSetConexion))
            {
                string queryInsert = "INSERT INTO Socios" +
                    "(nombre, ap_paterno, ap_materno, curp, fecha_nacimiento,edad, direccion, correo, telefono, fecha_ingreso, tipo_socio)" +
                    "VALUES(@nombre, @apellidoPaterno, @apellidoMaterno, @curp, @fechaNacimiento,@edad, @direccion, @correo, @telefono, @fechaIngreso, 'S')";

                try
                {
                    conexion.Open();

                    
                        if (!string.IsNullOrEmpty(getNombre) &&
                            !string.IsNullOrEmpty(getApellidoPaterno) &&
                            !string.IsNullOrEmpty(getApellidoMaterno) &&
                            !string.IsNullOrEmpty(getCurp)&&
                            getFechaNacimiento != null)
                        {
                            using (SqlCommand cmd = new SqlCommand(queryInsert, conexion))
                            {
                                cmd.Parameters.AddWithValue("@nombre", getNombre);
                                cmd.Parameters.AddWithValue("@apellidoPaterno", getApellidoPaterno);
                                cmd.Parameters.AddWithValue("@apellidoMaterno", getApellidoMaterno);
                                cmd.Parameters.AddWithValue("@curp", getCurp);
                                cmd.Parameters.AddWithValue("@fechaNacimiento", getFechaNacimiento);
                                 cmd.Parameters.AddWithValue("@edad", getEdad);
                                cmd.Parameters.AddWithValue("@direccion", getDireccion);
                                cmd.Parameters.AddWithValue("@correo", getCorreo);
                                cmd.Parameters.AddWithValue("@telefono", getTelefono);
                                cmd.Parameters.AddWithValue("@fechaIngreso", getFechaIngreso);

                                cmd.ExecuteNonQuery();
                            }
                        }
                                     
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error SQL al insertar socio: " + sqlEx.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar socio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        public void ActualizarSocio()
        {
            using (SqlConnection conexion = new SqlConnection(VGlobal.getSetConexion))
            {
                string queryUpdate = "UPDATE Socio SET " +
                    "nombre = @nombre, " +
                    "ap_paterno = @apellidoPaterno, " +
                    "ap_materno = @apellidoMaterno, " +
                    "curp = @curp, " +
                    "fecha_nacimiento = @fechaNacimiento, " +
                    "edad = @edad, " +
                    "direccion = @direccion, " +
                    "correo = @correo, " +
                    "telefono = @telefono, " +
                    "fecha_ingreso = @fechaIngreso " +
                    "WHERE id_socio = @idSocios";

                try
                {
                    conexion.Open();

                    if (idSocios != 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(queryUpdate, conexion))
                        {
                            cmd.Parameters.AddWithValue("@nombre",getNombre);
                            cmd.Parameters.AddWithValue("@apellidoPaterno", getApellidoPaterno);
                            cmd.Parameters.AddWithValue("@apellidoMaterno", getApellidoMaterno);
                            cmd.Parameters.AddWithValue("@curp", getCurp);
                            cmd.Parameters.AddWithValue("@fechaNacimiento", getFechaNacimiento);
                            cmd.Parameters.AddWithValue("@edad", getEdad);
                            cmd.Parameters.AddWithValue("@direccion", getDireccion);
                            cmd.Parameters.AddWithValue("@correo", getCorreo);
                            cmd.Parameters.AddWithValue("@telefono", getTelefono);
                            cmd.Parameters.AddWithValue("@fechaIngreso", getFechaIngreso);
                            cmd.Parameters.AddWithValue("@idSocios", getID);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese número de socio");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar socio: " + ex.Message);
                }
            }
        }

        public void EliminarSocio()
        {
            using (SqlConnection conexion = new SqlConnection(VGlobal.getSetConexion))
            {
                string queryDelete = "DELETE FROM Socio WHERE id_socio = @idSocios";

                try
                {
                    conexion.Open();

                    if (idSocios != 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(queryDelete, conexion))
                        {
                            cmd.Parameters.AddWithValue("@idSocios", idSocios);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese número de socio");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar socio: " + ex.Message);
                }
            }
        }

        public void ConsultarSocio()
        {
            using (SqlConnection conexion = new SqlConnection(VGlobal.getSetConexion))
            {
                string querySelect = "SELECT nombre, ap_paterno, ap_materno, curp, fecha_nacimiento, edad, direccion, correo, telefono, fecha_ingreso " +
                    "FROM Socio " +
                    "WHERE id_socio = @idSocios";

                try
                {
                    conexion.Open();

                    if (idSocios != 0)
                    {
                        using (SqlCommand cmd = new SqlCommand(querySelect, conexion))
                        {
                            cmd.Parameters.AddWithValue("@idSocios", idSocios);

                            // Usa un lector de datos para recuperar resultados
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nombre = reader["nombre"].ToString();
                                    string apellidoPaterno = reader["ap_paterno"].ToString();
                                
                                }
                                else
                                {
                                    MessageBox.Show("Socio no encontrado");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al consultar, ingrese datos válidos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar socio: " + ex.Message);
                }
            }
        }






    }
}
