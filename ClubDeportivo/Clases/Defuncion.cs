using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Clases
{
    class Defuncion
    {
        public int _id_defuncion;
        public int _id_socio;
        public string _fecha_defuncion;
        public string _beneficiario;
        public double _monto;

        public Defuncion()
        {
            _id_defuncion = 0;
            _id_socio = 0;
            _fecha_defuncion = null;
            _beneficiario = null;
            _monto = 0;
        }
        public Defuncion(int id_defuncion, int id_socio, string fecha_defuncion, string beneficiario, double monto)
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
        public string getSetFechaDefuncion
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

        public void 
    }
}
