using Examen_2.CapaModelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Examen_2.CapaNegocio
{
    public class Empleado_Logica
    {
        public int Agregar()
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DBconn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AgregarEmpleado", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsEmpleados.GetId));
                    cmd.Parameters.Add(new SqlParameter("@NombreEmpleado", ClsEmpleados.GetNombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", ClsEmpleados.GetApellidoPaterno));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", ClsEmpleados.GetApellidoMaterno));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", ClsEmpleados.GetFechaNacimiento));

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
                    SqlCommand cmd = new SqlCommand("BorrarEmpleado", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsEmpleados.GetId));

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
                    SqlCommand cmd = new SqlCommand("ModificarEmpleado", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsEmpleados.GetId));
                    cmd.Parameters.Add(new SqlParameter("@NombreEmpleado", ClsEmpleados.GetNombre));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoPaterno", ClsEmpleados.GetApellidoPaterno));
                    cmd.Parameters.Add(new SqlParameter("@ApellidoMaterno", ClsEmpleados.GetApellidoMaterno));
                    cmd.Parameters.Add(new SqlParameter("@FechaNacimiento", ClsEmpleados.GetFechaNacimiento));

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
                    SqlCommand cmd = new SqlCommand("ConsultarEmpleadoPorId", Conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@IdEmpleado", ClsEmpleados.GetId));

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClsEmpleados.SetNombre = reader["NombreEmpleado"].ToString();
                        ClsEmpleados.SetApellidoPaterno = reader["ApellidoPaterno"].ToString();
                        ClsEmpleados.SetApellidoMaterno = reader["ApellidoMaterno"].ToString();
                        ClsEmpleados.SetFechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]);
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