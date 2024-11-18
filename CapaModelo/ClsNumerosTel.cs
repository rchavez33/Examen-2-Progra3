using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_2.CapaModelo
{
    public class ClsNumerosTel
    {
        // Constructor
        public ClsNumerosTel(int idTelefono, int idEmpleado, int codigoPais, string numTelefono)
        {
            IdTelefono = idTelefono;
            IdEmpleado = idEmpleado;
            CodigoPais = codigoPais;
            NumTelefono = numTelefono;
        }

        // Propiedades
        public int IdTelefono { get; set; }
        public int IdEmpleado { get; set; }
        public int CodigoPais { get; set; }
        public string NumTelefono { get; set; }
    }
}