using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen_2.CapaNegocio
{
    public class Direccion_Logica
    {
        public int Agregar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarDireccion", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsDirecciones.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@Pais", ClsDirecciones.GetPais));
                    cmd.Parameters.Add(new SqlParameter("@EstadoProvincia", ClsDirecciones.GetEstadoProvincia));
                    cmd.Parameters.Add(new SqlParameter("@CiudadDistrito", ClsDirecciones.GetCiudadDistrito));
                    cmd.Parameters.Add(new SqlParameter("@BarrioSuburbioCalleAvenida", ClsDirecciones.GetBarrioSuburbioCalleAvenida));

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
                    SqlCommand cmd = new SqlCommand("BorrarDireccion", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdDireccion", ClsDirecciones.GetIdDireccion));

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
                    SqlCommand cmd = new SqlCommand("ModificarDireccion", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdDireccion", ClsDirecciones.GetIdDireccion));
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsDirecciones.GetIdEmpleado));
                    cmd.Parameters.Add(new SqlParameter("@Pais", ClsDirecciones.GetPais));
                    cmd.Parameters.Add(new SqlParameter("@EstadoProvincia", ClsDirecciones.GetEstadoProvincia));
                    cmd.Parameters.Add(new SqlParameter("@CiudadDistrito", ClsDirecciones.GetCiudadDistrito));
                    cmd.Parameters.Add(new SqlParameter("@BarrioSuburbioCalleAvenida", ClsDirecciones.GetBarrioSuburbioCalleAvenida));

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
                    SqlCommand cmd = new SqlCommand("ConsultarDireccionPorId", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdDireccion", ClsDirecciones.GetIdDireccion));

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClsDirecciones.SetPais = reader["Pais"].ToString();
                        ClsDirecciones.SetEstadoProvincia = reader["EstadoProvincia"].ToString();
                        ClsDirecciones.SetCiudadDistrito = reader["CiudadDistrito"].ToString();
                        ClsDirecciones.SetBarrioSuburbioCalleAvenida = reader["BarrioSuburbioCalleAvenida"].ToString();
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