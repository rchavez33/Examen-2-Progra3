using Examen_2.CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2.CapaVistas
{
    public partial class Usuarios : System.Web.UI.Page
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
            string script = $"<script type='texr/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }

        protected void Button1_Click(object sender, EventArgs e) // Agregar
        {
            string tidUsuario = tidUsuario.Text;
            string tnombreUsuario = tnombreUsuario.Text;
            string tclave = tclave.Text;
            string trol = trol.Text;

            string query = "INSERT INTO Usuarios (IDUsuario, NombreUsuario, Clave, Rol) VALUES (@IDUsuario, @NombreUsuario, @Clave, @Rol)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUsuario", tidUsuario);
                cmd.Parameters.AddWithValue("@NombreUsuario", tnombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", tclave);
                cmd.Parameters.AddWithValue("@Rol", trol);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button2_Click(object sender, EventArgs e) // Modificar
        {
            string tidUsuario = tidUsuario.Text;
            string tnombreUsuario = tnombreUsuario.Text;
            string tclave = tclave.Text;
            string trol = trol.Text;

            string query = "UPDATE Usuarios SET NombreUsuario = @NombreUsuario, Clave = @Clave, Rol = @Rol WHERE IDUsuario = @IDUsuario";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUsuario", tidUsuario);
                cmd.Parameters.AddWithValue("@NombreUsuario", tnombreUsuario);
                cmd.Parameters.AddWithValue("@Clave", tclave);
                cmd.Parameters.AddWithValue("@Rol", trol);
                conn.Open();
                cmd.ExecuteNonQuery();
                CargarDatos();
            }
        }

        protected void Button3_Click(object sender, EventArgs e) // Borrar
        {
            string tidUsuario = tidUsuario.Text;

            string query = "DELETE FROM Usuarios WHERE IDUsuario = @IDUsuario";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IDUsuario", tidUsuario);
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
            string query = "SELECT * FROM Usuarios";
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