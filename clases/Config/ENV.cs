using System.Data;
using System;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace MECANOGRAFIA.clases
{
    internal class ENV
    {
        clases.auth a;
        clases.db DB;
        Int32 res;

        public Int32 ExistsUser()
        {
            res = 0;
            DB = new db();
            a = new auth();
            string contenido = File.ReadAllText(auth.filePathJson);
            var palabras = JObject.Parse(contenido);
            foreach (DataRow r in DB.recuperar("USUARIOS", "USUARIO").Rows) { 
                if (palabras["usuario"].ToString() == r["USUARIO"].ToString()) res++; 
            }
            return res;
        }

        public Int32 VerifyDate()
        {
            res = 0;
            DB = new db();
            a = new auth();
            string contenido = File.ReadAllText(auth.filePathJson);
            var palabras = JObject.Parse(contenido);
            DataTable df = DB.recuperar("USUARIOS", "FECHASESION", $"USUARIO = '{palabras["usuario"].ToString()}'");
            foreach (DataRow rf in df.Rows) {
                DateTime DbDate = Convert.ToDateTime(rf["FECHASESION"]), nowDate = DateTime.Now;
                TimeSpan diferencia = nowDate - DbDate;
                if (diferencia.TotalHours >= 3) res++;
            }
            df.Dispose();
            return res;
        }
    }
}
