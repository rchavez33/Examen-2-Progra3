using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen_2.CapaNegocio
{
    public class AniosTrabajados_Logica
    {
        public int Agregar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarAniosTrabajados", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsAniosTrabajados.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@AniosTrabajados", ClsAniosTrabajados.GetAniosTrabajados));
                    cmd.Parameters.Add(new SqlParameter("@AniosTrabajadosPuestosDiferentes", ClsAniosTrabajados.GetAniosTrabajadosPuestosDiferentes));

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
                    SqlCommand cmd = new SqlCommand("BorrarAniosTrabajados", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsAniosTrabajados.GetIdEmpleado));

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
                    SqlCommand cmd = new SqlCommand("ModificarAniosTrabajados", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsAniosTrabajados.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@AniosTrabajados", ClsAniosTrabajados.GetAniosTrabajados));
                    cmd.Parameters.Add(new SqlParameter("@AniosTrabajadosPuestosDiferentes", ClsAniosTrabajados.GetAniosTrabajadosPuestosDiferentes));

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
                    SqlCommand cmd = new SqlCommand("ConsultarAniosTrabajadosPorId", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsAniosTrabajados.GetIdEmpleado));

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClsAniosTrabajados.SetAniosTrabajados = Convert.ToInt32(reader["AniosTrabajados"]);
                        ClsAniosTrabajados.SetAniosTrabajadosPuestosDiferentes = Convert.ToInt32(reader["AniosTrabajadosPuestosDiferentes"]);
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