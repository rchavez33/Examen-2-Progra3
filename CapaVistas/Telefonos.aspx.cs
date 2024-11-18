using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2.CapaVistas
{
    public partial class Telefonos : System.Web.UI.Page
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
            string tidTelefono = tidTelefono.Text;
            string tidEmpleado = tidEmpleado.Text;
            string ttelefono = ttelefono.Text;

            string query = "INSERT INTO Telefonos (IDTelefono, IDEmpleado, Telefono) VALUES (@IDTelefono, @IDEmpleado, @Telefono)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDTelefono", tidTelefono);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@Telefono", ttelefono);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // Modificar
        {
            string tidTelefono = tidTelefono.Text;
            string tidEmpleado = tidEmpleado.Text;
            string ttelefono = ttelefono.Text;

            string query = "UPDATE Telefonos SET IDEmpleado = @IDEmpleado, Telefono = @Telefono WHERE IDTelefono = @IDTelefono";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDTelefono", tidTelefono);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@Telefono", ttelefono);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // Borrar
        {
            string tidTelefono = tidTelefono.Text;

            string query = "DELETE FROM Telefonos WHERE IDTelefono = @IDTelefono";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDTelefono", tidTelefono);
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
            string query = "SELECT * FROM Telefonos";
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
