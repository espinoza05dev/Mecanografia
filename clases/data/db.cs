using System;
using System.Data;
using System.Data.SqlClient;

namespace MECANOGRAFIA.clases
{
    internal class db:conexion
    {
        string query;
        Int32 res;
        SqlCommand com;
        SqlDataReader reader;
        DataTable datos;
        clases.helpers h;

        public Int32 guardar(string tabla,string campos,string valores,int debug = 0)
        {
            res = 0;
            query = "INSERT INTO " + tabla + " (" + campos + ") VALUES (" + valores + ")";

            h.SeeRawSQLQuery(query, debug);

            try
            {
                com = new SqlCommand(query,SQLCon);
                SQLCon.Open();
                res = com.ExecuteNonQuery();
                SQLCon.Close();
                com.Dispose();
            }
            catch (SqlException er)
            {
                h.Warning(er.Message);
            }
            finally
            {
                Terminarconexion();
            }
            
            return res;
        }

        public Int32 actualizar(string tabla,string campos,string condicion = "",int debug = 0)
        {
            res = 0;
            h = new helpers();
            if (condicion == "") query = "UPDATE " + tabla + " SET " + campos;
            else query = "UPDATE " + tabla + " SET " + campos + " WHERE " + condicion;

            h.SeeRawSQLQuery(query, debug);

            try
            {
                com = new SqlCommand(query, SQLCon);
                Abrirconexion();
                res = com.ExecuteNonQuery();
                Cerrarconexion();
                com.Dispose();
            }
            catch (SqlException e)
            {
                h.Warning(e.Message);
            }
            finally
            {
                Terminarconexion();
            }

            return res;
        }

        public DataTable recuperar(string tabla,string campos,string condicion ="",int debug = 0)
        {
            datos = new DataTable();
            h = new helpers();
            if (condicion == "") query = "SELECT " + campos + " FROM " + tabla ;
            else query = "SELECT " + campos + " FROM " + tabla + " WHERE " + condicion;

            h.SeeRawSQLQuery(query, debug);

            try
            {
                com = new SqlCommand(query,SQLCon);
                SQLCon.Open();
                reader = com.ExecuteReader();
                datos.Load(reader);

                com.Dispose();
                reader.Close();
                SQLCon.Close();
            }
            catch (SqlException er)
            {
                h.Warning(er.Message);
            }
            finally
            {
                Terminarconexion();
            }

            return datos;
        }

        public DataTable consulta(string query, int debug = 0)
        {
            datos = new DataTable();
            h.SeeRawSQLQuery(query, debug);

            try
            {
                com = new SqlCommand(query, SQLCon);
                SQLCon.Open();
                reader = com.ExecuteReader();
                datos.Load(reader);

                com.Dispose();
                reader.Close();
                SQLCon.Close();
            }
            catch (SqlException er)
            {
                h.Warning(er.Message);
            }
            finally
            {
                Terminarconexion();
            }

            return datos;
        }
    }
}
