using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_2
{
    public class ClsUsuarios
    {
        // Constructor
        public ClsUsuarios(int idEmpleado, int idUsuario, string usuario, string clave)
        {
            IdEmpleado = idEmpleado;
            IdUsuario = idUsuario;
            Usuario = usuario;
            Clave = clave;
        }

        // Propiedades
        public int IdEmpleado { get; set; }
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
    }
}