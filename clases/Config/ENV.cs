using System.Data;
using System;
using System.IO;
using Newtonsoft.Json.Linq;

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
            string contenido = File.ReadAllText(auth.filePath);
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
            if (ExistsUser() > 0){
                string contenido = File.ReadAllText(auth.filePath);
                var palabras = JObject.Parse(contenido);
                DataTable df = DB.recuperar("USUARIOS", "FECHASESION", $"USUARIO = '{palabras["usuario"].ToString()}'");
                foreach (DataRow rf in df.Rows){
                    DateTime t = Convert.ToDateTime(rf["FECHASESION"]), now = DateTime.Now;
                    if (t.Day != now.Day || (now - t).TotalHours > 3) res++;
                }
                df.Dispose();
            }
            return res;
        }
    }
}
