using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void ValidarLogin(String Usuario, string Clave)
        {
            ClsUsuarios.Setusuario(Usuario);
            ClsUsuarios.Setclave(Clave);

            String s = System.Configuration.ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();

            SqlCommand comando = new SqlCommand(
                "select usuario, clave from Usuarios where usuario = '" + ClsUsuarios.Getusuario() +
                "' and clave = '" + ClsUsuarios.Getclave() + "'", conexion);

            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                Response.Redirect("Inicio.aspx");
            }
            else
            {
                MostrarAlerta(this, "Usuario o contraseña incorrecta");
            }

            conexion.Close();
        }
        public static void MostrarAlerta(Page page, string message)
        {
            string script = $"<script type='texr/javascript'>alert('{message}');</script>";
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterStartupScript(page.GetType(), "AlertScript", script);
        }


        protected void bingresar_Click(object sender, EventArgs e)
        {
            ValidarLogin(tusuario.Text, tclave.Text);
        }

    }
}