using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen_2.CapaNegocio
{
    public class Usuario_Logica : IntUsuario
    {
        public int Agregar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarUsuario", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsUsuarios.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@Usuario", ClsUsuarios.GetUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Clave", ClsUsuarios.GetClave));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public int Borrar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarUsuario", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsUsuarios.GetIdEmpleado));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public int Modificar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ModificarUsuario", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsUsuarios.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@Usuario", ClsUsuarios.GetUsuario));
                    cmd.Parameters.Add(new SqlParameter("@Clave", ClsUsuarios.GetClave));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public int Consultar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            SqlDataReader reader = null;

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ConsultarUsuarioPorId", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsUsuarios.GetIdEmpleado));

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClsUsuarios.SetUsuario = reader["Usuario"].ToString();
                        ClsUsuarios.SetClave = reader["Clave"].ToString();
                        retorno = 1;
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                retorno = -1;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                Conn.Close();
            }

            return retorno;
        }
    }
}