using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_2.CapaModelo
{
    public class ClsPuestos
    {
        // Constructor
        public ClsPuestos(int idPuesto, int idEmpleado, int codigoPuesto, string puestoDesempeñado)
        {
            IdPuesto = idPuesto;
            IdEmpleado = idEmpleado;
            CodigoPuesto = codigoPuesto;
            PuestoDesempeñado = puestoDesempeñado;
        }

        // Propiedades
        public int IdPuesto { get; set; }
        public int IdEmpleado { get; set; }
        public int CodigoPuesto { get; set; }
        public string PuestoDesempeñado { get; set; }
    }
}