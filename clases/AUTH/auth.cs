using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace MECANOGRAFIA.clases
{
    public class auth
    {
        clases.ENV ev;
        clases.helpers h;
        clases.db DB;
        static mecanografia.ESCRITURA E;
        public static string filePathJson = @"C:\ProgramData\SeeUsers.json";
        string contenido,user;
        Int16 res;
        public string APPNAME = "ESCRITURA RAPIDA";
        
        public Int16 VerifyFile()
        {
            E = new mecanografia.ESCRITURA();
            res = 0;
            if (!File.Exists(filePathJson)){
                Object JSON = new JObject { { "activado", "off" }, { "usuario", E.usuario_sesion } };
                string JsonString = JSON.ToString();
                File.WriteAllText(filePathJson,JsonString);
                res++;
            }
            return res;
        }
        public string SesionIniciada()
        {
            ev = new clases.ENV();
            contenido = File.ReadAllText(filePathJson);
            var palabras = JObject.Parse(contenido);
            return user = ev.ExistsUser() > 0 ? palabras["usuario"].ToString() : string.Empty;
        }

        public void SesionterminadaAuto()
        {
            DB = new db();
            h = new helpers();
            contenido = File.ReadAllText(filePathJson);
            var palabras = JObject.Parse(contenido);
            h.Info("SE HA CERRADO LA SESION");
            DB.actualizar("USUARIOS", $"FECHASESION = '{DateTime.Now}'", $"USUARIO = '{palabras["usuario"].ToString()}'");
        }

        public string MakeHash(string password)
        {
            string hash = "";
            SHA512 sha512 = new SHA512CryptoServiceProvider();
            byte[] inputbytes = (new UnicodeEncoding()).GetBytes(password);
            byte[] result = sha512.ComputeHash(inputbytes);
            hash = Convert.ToBase64String(result);
            return hash;
        }
    }
}
