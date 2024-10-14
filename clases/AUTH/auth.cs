using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MECANOGRAFIA.clases
{
    public class auth
    {
        clases.ENV ev;
        clases.helpers h;
        clases.db DB;
        mecanografia.ESCRITURA E;
        public List<string> palabras = new List<string>(c.Split(' '));
        public static string filePath = @"C:\ProgramData\SeeUsers.txt", c = File.ReadAllText(filePath);
        private string activado = "onn";
        Int16 res;
        public string usuario_sesion { get; set; }
        public string APPNAME = "ESCRITURA RAPIDA: ";

        public Int16 VerifyFile()
        {
            res = 0;
            E = new mecanografia.ESCRITURA();

            if (File.Exists(filePath))
            {
                string contenido = File.ReadAllText(filePath);
                if (palabras[0].ToString() == activado) { E.RDno.Checked = false; E.RDsi.Checked = true; E.CBusuario.Visible = true; }
                else { E.RDsi.Checked = false; E.RDno.Checked = true; }
                res++;
            }
            return res;
        }
        public Int16 SesionIniciada()
        {
            res = 0;
            ev = new clases.ENV();
            E = new mecanografia.ESCRITURA();
            if (ev.ExistsUser() > 0)
            {
                usuario_sesion = palabras[1].ToString();
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
            ev = new clases.ENV();
            E = new mecanografia.ESCRITURA();
            h = new helpers();
            DB = new db();
            if (ev.ExistsUser() > 0)
            {
                h.Info("SE HA CERRADO LA SESION"); 
                E.Text = APPNAME;
                usuario_sesion = string.Empty;
                DB.actualizar("USUARIOS", $"FECHASESION = '{DateTime.Now}'", $"USUARIO = '{palabras[1].ToString()}'");
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
