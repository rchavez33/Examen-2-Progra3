using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2.CapaVistas
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }
        protected void Button1_Click(object sender, EventArgs e) // Agregar
        {
            string tidEmpleado = tidEmpleado.Text;
            string tnombreEmpleado = tnombreEmpleado.Text;
            string tapellidoPaterno = tapellidoPaterno.Text;
            string tapellidoMaterno = tapellidoMaterno.Text;
            string tfechaNacimiento = tfechaNacimiento.Text;

            string query = "INSERT INTO Empleados (IDEmpleado, Nombre, ApellidoPaterno, ApellidoMaterno, FechaNacimiento) VALUES (@IDEmpleado, @Nombre, @ApellidoPaterno, @ApellidoMaterno, @FechaNacimiento)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", tnombreEmpleado);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", tapellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", tapellidoMaterno);
                cmd.Parameters.AddWithValue("@FechaNacimiento", tfechaNacimiento);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // Modificar
        {
            string tidEmpleado = tidEmpleado.Text;
            string tnombreEmpleado = tnombreEmpleado.Text;
            string tapellidoPaterno = tapellidoPaterno.Text;
            string tapellidoMaterno = tapellidoMaterno.Text;
            string tfechaNacimiento = tfechaNacimiento.Text;

            string query = "UPDATE Empleados SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, ApellidoMaterno = @ApellidoMaterno, FechaNacimiento = @FechaNacimiento WHERE IDEmpleado = @IDEmpleado";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@Nombre", tnombreEmpleado);
                cmd.Parameters.AddWithValue("@ApellidoPaterno", tapellidoPaterno);
                cmd.Parameters.AddWithValue("@ApellidoMaterno", tapellidoMaterno);
                cmd.Parameters.AddWithValue("@FechaNacimiento", tfechaNacimiento);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // Borrar
        {
            string tidEmpleado = tidEmpleado.Text;

            string query = "DELETE FROM Empleados WHERE IDEmpleado = @IDEmpleado";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button4_Click(object sender, EventArgs e) // Consultar
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            string query = "SELECT * FROM Empleados";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}
