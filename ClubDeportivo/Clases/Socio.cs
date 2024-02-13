using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Clases
{
    class Socio
    {
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Curp { get; set; }
        public string PdfCurp { get; set; }
        public int FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int FechaIngreso { get; set; }
        public int FechaReingreso { get; set; }
        public int FechaCambioEstatus { get; set; }
        public char TipoSocio { get; set; }
    }
}
