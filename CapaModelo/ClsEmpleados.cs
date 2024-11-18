using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_2.CapaModelo
{
    public class ClsEmpleados
    {
        // Constructor
        public ClsEmpleados(int idEmpleado, string nombreEmpleado, string apellidoPaterno, string apellidoMaterno, DateTime fechaNacimiento)
        {
            IdEmpleado = idEmpleado;
            NombreEmpleado = nombreEmpleado;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            FechaNacimiento = fechaNacimiento;
        }

        // Propiedades
        public int IdEmpleado { get; set; }
        public string NombreEmpleado { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}