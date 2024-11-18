using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen_2.CapaNegocio
{
    public class Puesto_Logica
    {
        public int Agregar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarPuesto", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsPuestos.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CodigoPuesto", ClsPuestos.GetCodigoPuesto));
                    cmd.Parameters.Add(new SqlParameter("@PuestoDesempeñado", ClsPuestos.GetPuestoDesempeñado));

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
                    SqlCommand cmd = new SqlCommand("BorrarPuesto", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdPuesto", ClsPuestos.GetIdPuesto));

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
                    SqlCommand cmd = new SqlCommand("ModificarPuesto", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdPuesto", ClsPuestos.GetIdPuesto));
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsPuestos.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@CodigoPuesto", ClsPuestos.GetCodigoPuesto));
                    cmd.Parameters.Add(new SqlParameter("@PuestoDesempeñado", ClsPuestos.GetPuestoDesempeñado));

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
                    SqlCommand cmd = new SqlCommand("ConsultarPuestoPorId", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdPuesto", ClsPuestos.GetIdPuesto));

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClsPuestos.SetIdEmpleado = Convert.ToInt32(reader["IdEmpleado"]);
                        ClsPuestos.SetCodigoPuesto = Convert.ToInt32(reader["CodigoPuesto"]);
                        ClsPuestos.SetPuestoDesempeñado = reader["PuestoDesempeñado"].ToString();
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