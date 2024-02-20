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
            //Validar que solo sean numeros en el txtUsuarios
            txtUsuario.KeyPress += new KeyPressEventHandler(ValidarNumeros);

            // TextBox para contraseña
            txtPassword.PasswordChar = '*'; // Carácter para ocultar la contraseña
            txtPassword.UseSystemPasswordChar = true; // Utiliza el carácter de contraseña del sistema

        }
        public string NombreUsuario;

        // Propiedad para la variable
        
        //Cadena de conexion 

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //TXT para las variables y verificar el login
            string idUsuario = txtUsuario.Text;
            string password = txtPassword.Text;
            
            // Verifica el login en la base de datos
            if (VerificarCredenciales(idUsuario, password))
            {
                //Mensaje para el usuario que las credenciales son correctas
                MessageBox.Show("Inicio de sesión exitoso.");

                //Mostrar el frmMENU 
                frmMENU frmMenu = new frmMENU();
                frmMenu.nombre = NombreUsuario;
                frmMenu.Show();

                //Ocultar el frmLogin
                this.Hide();

            }
            else
            {
                //Mensaje de credenciales incorrectas 
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar aplicacion
            Application.Exit();
        }

        //Validacion que solo sean numeros para el txtUsuario
        private void ValidarNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite solo números
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //Verificar credenciales del usuario para el boton aceptar
        private bool VerificarCredenciales(string idUsuario, string password)
        {
            //Utilizar las cadenas de conexion que anteriormente se le dio 
            using (SqlConnection conexion = new SqlConnection(VGlobal.getSetConexion))
            {
                try
                {
                    //Abrir cadena de conexin
                    conexion.Open();

                    // Verifica las credenciales en la base de datos con una consulta general en la base de datos
                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE id_usuario = @idUsuario AND Contrasena = @password";
                    string obtenerNombre = "SELECT nombre FROM Usuarios WHERE id_usuario = @idUsuario AND Contrasena = @password";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        // Mandar parámetros a la consulta para verificar
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@password", password);

                        // Regresar el resultado para entrar al sistema
                        int resultado = (int)cmd.ExecuteScalar();

                        // Si las credenciales son correctas, obtener el nombre
                        if (resultado > 0)
                        {
                            using (SqlCommand cmdNombre = new SqlCommand(obtenerNombre, conexion))
                            {
                                // Mandar parámetros a la consulta para obtener el nombre
                                cmdNombre.Parameters.AddWithValue("@idUsuario", idUsuario);
                                cmdNombre.Parameters.AddWithValue("@password", password);

                                // Obtener el nombre
                                NombreUsuario = cmdNombre.ExecuteScalar() as string;

                                Console.WriteLine(NombreUsuario);
                                // Aquí puedes usar la variable 'nombreUsuario' como necesites
                            }

                            // Devolver true si las credenciales son correctas
                            return true;
                        }

                        // Devolver false si las credenciales son incorrectas
                        return false;
                    }
                }
                catch 
                {
                    return false;
                }
            }
        }


       
        private void frmLogin_Load(object sender, EventArgs e)
        {

        }


    }



        }

