using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net;

namespace MECANOGRAFIA.clases
{
    internal class conexion:ENV
    {
        static string ObtenerCadenaConexion()
        {
            string[] testConnections = { 
                $"Data Source={Dns.GetHostName()};Initial Catalog=MECANOGRAFIAA;Integrated Security=True;Connection",
                $"Data Source={Dns.GetHostName()}\\SQLEXPRESS;Initial Catalog=MECANOGRAFIAA;Integrated Security=True;Connection",
                $"Data Source=.;Initial Catalog=MECANOGRAFIAA;Integrated Security=True;Connection",
                $"Data Source=.\\SQLEXPRESS;Initial Catalog=MECANOGRAFIAA;Integrated Security=True;Connection"
                };

            foreach (string connStr in testConnections)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();
                        return connStr.Replace(";Connection", "");
                    }
                }
                catch
                {
                    continue;
                }
            }

            return "Data Source=" + Dns.GetHostName() + "\\SQLEXPRESS;Initial Catalog=MECANOGRAFIAA;Integrated Security=True";
        }

        // CADENA DE CONEXION PARA CONEXIONES LOCALES //static string cadena_de_conexion = $"Server=" + ENV.SERVER + ";Database=" + ENV.DB + ";User Id=" + ENV.USER + ";Password=" + ENV.PWD + ";TrustServerCertificate=True";
        static string cadena_conexion = ObtenerCadenaConexion();
        public static SqlConnection SQLCon = new SqlConnection(cadena_conexion);

        public void Abrirconexion()
        {
            try{
                SQLCon.Open();
            }catch (SqlException error){
                MessageBox.Show(error.Message);
            }
        }

        public void Cerrarconexion()
        {
            try{
                SQLCon.Close();
            }catch (SqlException error){
                MessageBox.Show(error.Message);
            }
        }

        public void Terminarconexion(){
            if (SQLCon.State == ConnectionState.Open)SQLCon.Close(); 
        }
    }
}
