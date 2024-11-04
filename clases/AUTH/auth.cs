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
        mecanografia.ESCRITURA E;
        public static string filePath = @"C:\ProgramData\SeeUsers.json";
        private string activado = "onn";
        public Object JSON = new JObject { { "activado", "off" }, { "usuario",  usuario_sesion} };
        string contenido;
        Int16 res;
        public static string usuario_sesion { get; set; }
        public string APPNAME = "ESCRITURA RAPIDA: ";
        

        public Int16 VerifyFile()
        {
            res = 0;
            E = new mecanografia.ESCRITURA();
            
            if (File.Exists(filePath))
            {
                contenido = File.ReadAllText(filePath);
                var palabras = JObject.Parse(contenido);
                    
                res = palabras["activado"].ToString() == activado ? E.Activate(true): E.Activate(false);
            }else{
                string JsonString = JSON.ToString();
                File.WriteAllText(filePath,JsonString);
                res++;
            }
            return res;
        }
        public Int16 SesionIniciada()
        {
            res = 0;
            ev = new clases.ENV();
            E = new mecanografia.ESCRITURA(); 
            contenido = File.ReadAllText(filePath);
            var palabras = JObject.Parse(contenido);
            if (ev.ExistsUser() > 0)
            {
                usuario_sesion = palabras["usuario"].ToString();
                E.Text = APPNAME + usuario_sesion; 
                res++;
            }
            else
            {
                E.Text = APPNAME;
            }

            return res;
        }

        public void SesionterminadaAuto()
        {
            E = new mecanografia.ESCRITURA();
            DB = new db();
            h = new helpers();
            ev = new ENV();
            string contenido = File.ReadAllText(filePath);
            var palabras = JObject.Parse(contenido);
            if (ev.ExistsUser() > 0)
            {
                h.Info("SE HA CERRADO LA SESION"); 
                E.Text = APPNAME;
                usuario_sesion = string.Empty;
                DB.actualizar("USUARIOS", $"FECHASESION = '{DateTime.Now}'", $"USUARIO = '{palabras["usuario"].ToString()}'");
            }
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
