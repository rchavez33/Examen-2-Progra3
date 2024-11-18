using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_2.CapaModelo
{
    public class ClsAniosTrabajados
    {
        // Constructor
        public ClsAniosTrabajados(int idEmpleado, int aniosTrabajados, int aniosTrabajadosPuestosDiferentes)
        {
            IdEmpleado = idEmpleado;
            AniosTrabajados = aniosTrabajados;
            AniosTrabajadosPuestosDiferentes = aniosTrabajadosPuestosDiferentes;
        }

        // Propiedades
        public int IdEmpleado { get; set; }
        public int AniosTrabajados { get; set; }
        public int AniosTrabajadosPuestosDiferentes { get; set; }
    }
}