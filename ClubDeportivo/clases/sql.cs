using System;
using System.Data;
using System.Data.Odbc;
using System.Windows.Forms;


    //CONEXI�N A LA BASE DE DATOS CREADA EN MySQL
    public class MySQL
{
    //Variable de instancia del tipo conexion
    public OdbcConnection cnx;

    //M�todo Constructor que establece la conexi�n con el origen de datos
    public MySQL()
    {
        cnx = new OdbcConnection("SERVER=127.0.0.1; DATABASE=DBAcademico; UID=root; PWD= its");

        if (cnx.State == ConnectionState.Closed)
        {
            try
            {
                cnx.Open();
            }
            catch (Exception ex)
            {
                cnx.Close();
                MessageBox.Show("Fall� Conexi�n a Base de Datos MySQL!! " + ex.Message.ToString());
            }
        }
    }

    //M�todo que ejecuta un comando insert, update o delete a base de datos
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

    //M�todo para efectuar lecturas y generar recordset de datos
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
            throw new Exception("MySQL:ObjetoDataReader " + ex.Message);
        }
        finally
        {
            cmd.Dispose();
            resultadoSQL.Dispose();
        }
    }

    //M�todo para efectuar consultas a base de datos
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
        finally
        {
            DA = null;
            DT = null;
        }
    }


    //M�todo que ejecuta una funci�n de grupo a la base de datos
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