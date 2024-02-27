using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClubDeportivo.Conectividad;

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

        public int getSetIdTarifa {
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
            MySQL cxn = new MySQL();
            try
            {
                sql = "INSERT INTO tarifas (concepto, monto, tipo_tarifa) " +
                                        "VALUES('" + concepto + "','" + monto + "','" + tipo_tarifa + "')";
                cxn.objetoCommand(sql);

                MessageBox.Show("Se guardaron los datos.");

            }catch(Exception e)
            {
                MessageBox.Show("Hubo un error al registrar la tarifa. \n" + e.Message.ToString());
            }
            finally
            {
                cxn = null;
            }
        }

        public void modificarTarifa(string concepto, double monto, int id_tarifa)
        {
            string sql = null;
            MySQL cxn = new MySQL();

            try 
            { 
                sql = "UPDATE tarifas SET concepto = '" + concepto +"', monto ='" + monto + "' WHERE id_tarifa ="+ id_tarifa +";";
                cxn.objetoCommand(sql);
                MessageBox.Show("Se han actualizado los datos.");
            }
            catch(Exception e)
            {
                MessageBox.Show("No se pudo modificar el dato.\n" + e.Message.ToString());
            }
        }

        public void consultarTarifas(DataGridView dgv, string tipo_tarifa)
        {
            string sql = null;
            DataTable data;
            MySQL cxn = new MySQL();

            try
            {
                sql = "SELECT id_tarifa, concepto, monto  FROM tarifas WHERE tipo_tarifa = '" + tipo_tarifa +"';";
                data = cxn.objetoDataAdapter(sql);
                dgv.DataSource = data;
            }
            catch(Exception e)
            {
                MessageBox.Show("Hubo un error en la consulta. \n" + e.Message.ToString());
            }
            
        }

    }
}
