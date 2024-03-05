﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClubDeportivo.Conectividad
{
    class MySQL
    {
        //Variable de instancia del tipo conexion
        public OdbcConnection cnx;

        //Método Constructor que establece la conexión con el origen de datos
        public MySQL()
        {
            cnx = new OdbcConnection("DRIVER={MySQL ODBC 8.0 Unicode Driver};SERVER=127.0.0.1; \"Server=localhost;Database=ClubDeportivo;Trusted_Connection=True\"");

            if (cnx.State == ConnectionState.Closed)
            {
                try
                {
                    cnx.Open();
                }
                catch (Exception ex)
                {
                    cnx.Close();
                    MessageBox.Show("Falló Conexión a Base de Datos MySQL!! \n\n" + ex.Message.ToString());
                }
            }
        }

        //Método que ejecuta un comando insert, update o delete a base de datos
        public void objetoCommand(String strcmd)
        {
            OdbcCommand sqlcmd = new OdbcCommand(strcmd, cnx);
            OdbcTransaction objTransacc = null;
            try
            {
                objTransacc = cnx.BeginTransaction();
                sqlcmd.Transaction = objTransacc;
                sqlcmd.ExecuteNonQuery();
                objTransacc.Commit();
            }
            catch (Exception ex)
            {
                objTransacc.Rollback();
                throw new Exception("MySQL:ObjetoCommand " + ex.Message);
            }
            finally
            {
                sqlcmd.Dispose();
                sqlcmd = null;
                objTransacc = null;
            }
        }

        //Método para efectuar lecturas y generar recordset de datos
        public OdbcDataReader objetoDataReader(String comando)
        {
            OdbcCommand cmd = new OdbcCommand(comando, cnx);
            OdbcDataReader resultadoSQL = cmd.ExecuteReader();
            try
            {
                return resultadoSQL;
            }
            catch (Exception ex)
            {
                throw new Exception("MySQL:ObjetoDataReader \n" + ex.Message);
            }
        }

        //Método para efectuar consultas a base de datos
        public DataTable objetoDataAdapter(String sqlcmd)
        {
            OdbcDataAdapter DA;
            DataTable DT;
            try
            {
                DA = new OdbcDataAdapter(sqlcmd, cnx);
                DT = new DataTable();
                DA.Fill(DT);
                return DT;
            } //retorna el conjunto de dato
            catch (Exception ex)
            {
                throw new Exception("MySQL:ObjetoDataAdapter " + ex.Message);
            }
            /*finally
            {
                DA = null;
                DT = null;
            }*/
        }



        //Método que ejecuta una función de grupo a la base de datos
        public Object objetoScalar(String strcmd)
        {
            OdbcCommand sqlcmd = new OdbcCommand(strcmd, cnx);
            try
            {
                return sqlcmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("MySQL:ObjetoScalar " + ex.Message);
            }
            finally
            {
                sqlcmd.Dispose();
            }
        }
    }
}
