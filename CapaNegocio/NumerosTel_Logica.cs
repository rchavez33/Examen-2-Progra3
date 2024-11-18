using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen_2.CapaNegocio
{
    public class NumerosTel_Logica
    {
        public int Agregar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarNumeroTel", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsNumerosTel.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CodigoPais", ClsNumerosTel.GetCodigoPais));
                    cmd.Parameters.Add(new SqlParameter("@NumTelefono", ClsNumerosTel.GetNumTelefono));

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
                    SqlCommand cmd = new SqlCommand("BorrarNumeroTel", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdTelefono", ClsNumerosTel.GetIdTelefono));

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
                    SqlCommand cmd = new SqlCommand("ModificarNumeroTel", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdTelefono", ClsNumerosTel.GetIdTelefono));
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsNumerosTel.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CodigoPais", ClsNumerosTel.GetCodigoPais));
                    cmd.Parameters.Add(new SqlParameter("@NumTelefono", ClsNumerosTel.GetNumTelefono));

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
                    SqlCommand cmd = new SqlCommand("ConsultarNumeroTelPorId", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdTelefono", ClsNumerosTel.GetIdTelefono));

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClsNumerosTel.SetCodigoPais = Convert.ToInt32(reader["CodigoPais"]);
                        ClsNumerosTel.SetNumTelefono = reader["NumTelefono"].ToString();
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