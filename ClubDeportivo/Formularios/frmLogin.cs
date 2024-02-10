using ClubDeportivo.Formularios;
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

namespace ClubDeportivo
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            txtUsuario.KeyPress += new KeyPressEventHandler(ValidarNumeros);

            // TextBox para contraseña
            txtPassword.PasswordChar = '*'; // Carácter para ocultar la contraseña
            txtPassword.UseSystemPasswordChar = true; // Utiliza el carácter de contraseña del sistema

        }
        private const string cadenaConexion = "Data Source=DerekGA;Initial Catalog=ClubDeportivo;Integrated Security=True;Encrypt=False;TrustServerCertificate=True"; 
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string idUsuario = txtUsuario.Text;
            string password = txtPassword.Text;

          

            // Verifica el login en la base de datos
            if (VerificarCredenciales(idUsuario, password))
            {
                MessageBox.Show("Inicio de sesión exitoso.");
                frmMENU frmMenu = new frmMENU();
                frmMenu.Show();
                frmLogin frmLogin = new frmLogin();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ValidarNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite solo números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool VerificarCredenciales(string idUsuario, string password)
        {
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    // Verifica las credenciales en la base de datos
                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE id_usuario = @idUsuario AND Contrasena = @password";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@password", password);

                        int resultado = (int)cmd.ExecuteScalar();
                        return resultado > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al verificar las credenciales: " + ex.Message);
                    return false;
                }
            }
        }
    }



        }

