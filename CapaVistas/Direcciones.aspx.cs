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
    public partial class Direcciones : System.Web.UI.Page
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
            string tidDireccion = tidDireccion.Text;
            string tidEmpleado = tidEmpleado.Text;
            string tpais = tpais.Text;
            string testadoProvincia = testadoProvincia.Text;
            string tciudadDistrito = tciudadDistrito.Text;
            string tbarrioSuburbio = tbarrioSuburbio.Text;

            string query = "INSERT INTO Direcciones (IDDireccion, IDEmpleado, Pais, EstadoProvincia, CiudadDistrito, BarrioSuburbio) VALUES (@IDDireccion, @IDEmpleado, @Pais, @EstadoProvincia, @CiudadDistrito, @BarrioSuburbio)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDDireccion", tidDireccion);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@Pais", tpais);
                cmd.Parameters.AddWithValue("@EstadoProvincia", testadoProvincia);
                cmd.Parameters.AddWithValue("@CiudadDistrito", tciudadDistrito);
                cmd.Parameters.AddWithValue("@BarrioSuburbio", tbarrioSuburbio);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // Modificar
        {
            string tidDireccion = tidDireccion.Text;
            string tidEmpleado = tidEmpleado.Text;
            string tpais = tpais.Text;
            string testadoProvincia = testadoProvincia.Text;
            string tciudadDistrito = tciudadDistrito.Text;
            string tbarrioSuburbio = tbarrioSuburbio.Text;

            string query = "UPDATE Direcciones SET IDEmpleado = @IDEmpleado, Pais = @Pais, EstadoProvincia = @EstadoProvincia, CiudadDistrito = @CiudadDistrito, BarrioSuburbio = @BarrioSuburbio WHERE IDDireccion = @IDDireccion";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDDireccion", tidDireccion);
                cmd.Parameters.AddWithValue("@IDEmpleado", tidEmpleado);
                cmd.Parameters.AddWithValue("@Pais", tpais);
                cmd.Parameters.AddWithValue("@EstadoProvincia", testadoProvincia);
                cmd.Parameters.AddWithValue("@CiudadDistrito", tciudadDistrito);
                cmd.Parameters.AddWithValue("@BarrioSuburbio", tbarrioSuburbio);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // Borrar
        {
            string tidDireccion = tidDireccion.Text;

            string query = "DELETE FROM Direcciones WHERE IDDireccion = @IDDireccion";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDDireccion", tidDireccion);
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
            string query = "SELECT * FROM Direcciones";
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