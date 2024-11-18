using Examen_2.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2.CapaVistas
{
    public partial class AniosTrabajados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }
        }

        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='text/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        protected void Button1_Click(object sender, EventArgs e) // Agregar
        {
            string tidEmpleado = tidEmpleado.Text;
            string taniosTrabajados = taniosTrabajados.Text;
            string taniosPuestosDiferentes = taniosPuestosDiferentes.Text;

            string query = "INSERT INTO AniosTrabajados (IDEmpleado, AniosTrabajados, AniosPuestosDiferentes) VALUES (@IDEmpleado, @AniosTrabajados, @AniosPuestosDiferentes)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@AniosTrabajados", taniosTrabajados);
                cmd.Parameters.AddWithValue("@AniosPuestosDiferentes", taniosPuestosDiferentes);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos(); // Recargar datos en el GridView
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // Modificar
        {
            string tidEmpleado = tidEmpleado.Text;
            string taniosTrabajados = taniosTrabajados.Text;
            string taniosPuestosDiferentes = taniosPuestosDiferentes.Text;

            string query = "UPDATE AniosTrabajados SET AniosTrabajados = @AniosTrabajados, AniosPuestosDiferentes = @AniosPuestosDiferentes WHERE IDEmpleado = @IDEmpleado";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@AniosTrabajados", taniosTrabajados);
                cmd.Parameters.AddWithValue("@AniosPuestosDiferentes", taniosPuestosDiferentes);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // Borrar
        {
            string tidEmpleado = tidEmpleado.Text;

            string query = "DELETE FROM AniosTrabajados WHERE IDEmpleado = @IDEmpleado";

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
            string query = "SELECT * FROM AniosTrabajados";
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