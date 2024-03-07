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
 public class SQLRecibos 
    {
        private string concepto;
        private double monto;
        private char tipo_tarifa;
        private DateTime fecha;

        public SQLRecibos()
        {
           concepto = null;
            monto = 0.0;
            tipo_tarifa = ' ';

        }
        public SQLRecibos(string _concepto, double _monto, char _tipo_tarifas, DateTime _fecha)
        {
            this.concepto = _concepto;
            this.monto = _monto;
            this.tipo_tarifa= _tipo_tarifas;
            this.fecha = _fecha;
        }

        public string getConcepto
        {
            get { return concepto; }
            set {  concepto = value; }
        }

        public double getMonto 
        { 
            get { return monto; }
            set {  monto = value; }
        }

        public char getTipo_Tarifa
        { 
            get { return tipo_tarifa;}
            set { tipo_tarifa = value;} 
        }

        public DateTime getFecha
        {
            get { return fecha;}
            set { fecha = value;}
        }

        public void consultaMontos(out double monto) 
        {
            int contador = 1;

            using (SqlConnection conexion = new SqlConnection(VGlobal.getSetConexion))
            {
                string queryMonto = "SELECT monto from Tarifas where concepto=@concepto and tipo_tarifa = @tipo_tarifa";

                try
                {
                    conexion.Open();


                    using (SqlCommand cmd = new SqlCommand(queryMonto, conexion))
                    {
                        cmd.Parameters.AddWithValue("@concepto", getConcepto);
                        cmd.Parameters.AddWithValue("@tipo_tarifa", getTipo_Tarifa);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Obtén los valores de la consulta y asígnales a las variables
                                monto = Convert.ToDouble(reader["monto"]);

                            }
                            else
                            {
                                if (contador == 1)
                                {
                                    MessageBox.Show("Verifica que todos las tarifas esten asignadas", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    // Asigna valores por defecto o marca un indicador de que no se encontró el socio
                                    contador++;
                                }
                                monto = 0.0;

                            }
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar" + ex.Message);
                    monto = 0.0;

                }
            }
        }


       



    }

}
