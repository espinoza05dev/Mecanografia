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
            foreach (DataRow r in DB.recuperar("USUARIOS", "USUARIO").Rows) { 
                if (auth.filePath.Contains(r["USUARIO"].ToString())) res++; 
            }
            return res;
        }

        public Int32 VerifyDate()
        {
            res = 0;
            DB = new db();
            a = new auth();
            if (ExistsUser() > 0)
            {
                string contenido = auth.filePath;
                var palabras = JObject.Parse(contenido);
                DataTable df = DB.recuperar("USUARIOS", "FECHASESION", $"USUARIO = '{palabras["usuario"].ToString()}'");
                foreach (DataRow rf in df.Rows)
                {
                    DateTime t = Convert.ToDateTime(rf["FECHASESION"]);
                    string f = t.ToString("hh");
                    if (Convert.ToInt32(f) == (DateTime.Today.Hour - 3) || Convert.ToInt32(f) == (DateTime.Today.Hour + 3) || t.Day < DateTime.Today.Day || t.Day > DateTime.Today.Day) res++;
                }
                df.Dispose();
            }
            return res;
        }
    }
}
