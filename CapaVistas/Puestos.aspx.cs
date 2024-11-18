using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2.CapaVistas
{
    public partial class Puestos : System.Web.UI.Page
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
            string tidPuesto = tidPuesto.Text;
            string tdescripcion = tdescripcion.Text;

            string query = "INSERT INTO Puestos (IDPuesto, Descripcion) VALUES (@IDPuesto, @Descripcion)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDPuesto", tidPuesto);
                cmd.Parameters.AddWithValue("@Descripcion", tdescripcion);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // Modificar
        {
            string tidPuesto = tidPuesto.Text;
            string tdescripcion = tdescripcion.Text;

            string query = "UPDATE Puestos SET Descripcion = @Descripcion WHERE IDPuesto = @IDPuesto";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDPuesto", tidPuesto);
                cmd.Parameters.AddWithValue("@Descripcion", tdescripcion);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // Borrar
        {
            string tidPuesto = tidPuesto.Text;

            string query = "DELETE FROM Puestos WHERE IDPuesto = @IDPuesto";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDPuesto", tidPuesto);
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
            string query = "SELECT * FROM Puestos";
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
}