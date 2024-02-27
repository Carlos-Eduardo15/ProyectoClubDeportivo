using ClubDeportivo.Conectividad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Clases
{
    public class Usuario
    {
        private string _id_usuario;
        private string _contrasena;
        private string _nombre_usuario;

        public Usuario()
        {
            _id_usuario = null;
            _contrasena = null;
            _nombre_usuario = null;
        }

        public Usuario(string idUsuario, string contrasena, string nombre)
        {
            _id_usuario = idUsuario;
            _contrasena = contrasena;
            _nombre_usuario = nombre;
        }

        //MÉTODOS PROPERTY
        public string getSetIdUsuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }

        public string getSetContrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }

        public string getSetNombreUsuario
        {
            get { return _nombre_usuario; }
            set { _nombre_usuario = value; }
        }

        //MÉTODOS OPERATIVOS
        public void insertaUsuario()
        {
            string strSql = null;
            MySQL xCnx = new MySQL();
            try
            {
                if (_id_usuario != null && _contrasena != null)
                {
                    //Realiza inserción de datos
                    strSql = "INSERT INTO usuarios (nombre_usuario, contrasena) " +
                             "VALUES ('" + _contrasena + "','" + _nombre_usuario + "')";
                    xCnx.objetoCommand(strSql);
                }
                else
                {
                    MessageBox.Show("Faltan datos del Usuario!!", "ATENCIÓN");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario:insertaUsuario " + ex.Message.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }


        public void actualizaUsuario()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_id_usuario != null && _contrasena != null)
                {
                    strSql = "UPDATE usuarios SET " +
                        "contrasena='" + _contrasena + "' " +
                        "WHERE id_usuario='" + _id_usuario + "'";
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan datos del Usuario!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario:actualizaUsuario " + ex.Message.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public void eliminaUsuario()
        {
            string strSql;
            MySQL xCnx = new MySQL();
            try
            {
                if (_id_usuario != null)
                {
                    strSql = "DELETE FROM usuarios WHERE usuario='" + _id_usuario + "'";
                    xCnx.objetoCommand(strSql);
                }
                else
                    MessageBox.Show("Faltan datos del Usuario!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario:eliminaUsuario " + ex.Message.ToString());
            }
            finally
            {
                xCnx = null;
            }
        }

        public Boolean consultaUsuario()
        {
            string strSQL;
            MySQL xCnx = new MySQL();
            DataTable xDT;
            try
            {
                strSQL = "SELECT nombre_usuario, contrasena " +
                         "FROM usuarios " +
                         "WHERE nombre_usuario='" + "'" + _nombre_usuario + "';";

                xDT = xCnx.objetoDataAdapter(strSQL);

                if (xDT.Rows.Count == 1)
                {

                    if (xDT.Rows[0]["id_usuario"] == DBNull.Value)
                        _id_usuario = null;
                    else
                        _id_usuario = xDT.Rows[0]["id_usuario"].ToString();

                    if (xDT.Rows[0]["password"] == DBNull.Value)
                        _contrasena = null;
                    else
                        _contrasena = xDT.Rows[0]["password"].ToString();
                 
                    if (xDT.Rows[0]["nombre_usuario"] == DBNull.Value)
                        _nombre_usuario = null;
                    else
                        _nombre_usuario = xDT.Rows[0]["nombre_usuario"].ToString();

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Usuario:consultaUsuario " + ex.Message.ToString());
                return false;
            }
            finally
            {
                xCnx = null;
                xDT = null;
            }
        }
    }
}
