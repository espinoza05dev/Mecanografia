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

        private void QueryExecutionProcess(string query,bool BringDataOrModification = true)
        {
            try
            {
                com = new SqlCommand(query, SQLCon);
                Abrirconexion();

                if (BringDataOrModification){
                    reader = com.ExecuteReader();
                    datos = new DataTable();
                    datos.Load(reader);
                    reader.Close();
                }
                else res = com.ExecuteNonQuery();              

                com.Dispose();
                Cerrarconexion();
            }
            catch (SqlException er)
            {
                h.Warning(er.Message);
            }
            finally
            {
                Terminarconexion();
            }
        }

        public Int32 guardar(string tabla,string campos,string valores,int debug = 0)
        {
            res = 0;
            h = new helpers();
            query = "INSERT INTO " + tabla + " (" + campos + ") VALUES (" + valores + ")";

            h.SeeRawSQLQuery(query, debug);
            QueryExecutionProcess(query,false);

            return res;
        }

        public Int32 actualizar(string tabla, string campos, string condicion = "", int debug = 0)
        {
            res = 0;
            h = new helpers();
            query = condicion == "" ? $"UPDATE {tabla} SET {campos}": $"UPDATE {tabla} SET {campos} WHERE {condicion} ";

            h.SeeRawSQLQuery(query, debug);
            QueryExecutionProcess(query, false);

            return res;
        }

        public DataTable recuperar(string tabla,string campos,string condicion ="",int debug = 0)
        {
            datos = new DataTable();
            h = new helpers();
            query = condicion == "" ? $"SELECT {campos} FROM {tabla}" : $"SELECT {campos} FROM {tabla} WHERE {condicion}";

            h.SeeRawSQLQuery(query, debug);
            QueryExecutionProcess(query, true);

            return datos;
        }

        public DataTable consulta(string query, int debug = 0)
        {
            datos = new DataTable();
            h = new helpers();
            h.SeeRawSQLQuery(query, debug);
            QueryExecutionProcess(query, true);

            return datos;
        }
    }
}
