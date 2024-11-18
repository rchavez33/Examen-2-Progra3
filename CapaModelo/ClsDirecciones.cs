using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_2.CapaModelo
{
    public class ClsDirecciones
    {
        // Constructor
        public ClsDirecciones(int idDireccion, int idEmpleado, string pais, string estadoProvincia, string ciudadDistrito, string barrioSuburbioCalleAvenida)
        {
            IdDireccion = idDireccion;
            IdEmpleado = idEmpleado;
            Pais = pais;
            EstadoProvincia = estadoProvincia;
            CiudadDistrito = ciudadDistrito;
            BarrioSuburbioCalleAvenida = barrioSuburbioCalleAvenida;
        }

        // Propiedades
        public int IdDireccion { get; set; }
        public int IdEmpleado { get; set; }
        public string Pais { get; set; }
        public string EstadoProvincia { get; set; }
        public string CiudadDistrito { get; set; }
        public string BarrioSuburbioCalleAvenida { get; set; }
    }
}