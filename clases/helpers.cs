using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
=======
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
>>>>>>> Agregar archivos de proyecto.
using System.Windows.Forms;

namespace MECANOGRAFIA.clases
{
    internal class helpers
    {
<<<<<<< HEAD
=======
       
>>>>>>> Agregar archivos de proyecto.
        public void ShowNumber(int num = 0,double num1 = 0,float num2 = 0,long num3 = 0, short num4 = 0)
        {
            if (num > 0) MessageBox.Show(num.ToString());
            else if (num1 > 0) MessageBox.Show(num1.ToString());
            else if (num2 > 0) MessageBox.Show(num2.ToString());
            else if (num3 > 0) MessageBox.Show(num3.ToString());
            else if (num4 > 0) MessageBox.Show(num4.ToString());
        }

        public bool Question(string msg)
        {
            bool resp = false;
            MessageBoxButtons opciones = MessageBoxButtons.YesNo;
            MessageBoxIcon iconos = MessageBoxIcon.Question;
            if (MessageBox.Show(msg, "CONFIRMAR", opciones, iconos) == DialogResult.Yes)
            {
                resp = true;
            }
            return resp;
        }

        public void Succes(string msg, string titulo = "EXITO")
        {
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Information;
            MessageBox.Show(msg, titulo, boton, icono);
        }

        public void Warning(string msg, string titulo = "ATENCION")
        {
            MessageBox.Show(msg, titulo);
        }

<<<<<<< HEAD
<<<<<<< HEAD
        public void Info(string msg, string titulo = "INFORMACION")
=======
        public void Info(string msg, string titulo = "INFO")
>>>>>>> Agregar archivos de proyecto.
=======
        public void Info(string msg, string titulo = "INFORMACION")
>>>>>>> prueba
        {
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Information;
            MessageBox.Show(msg,titulo,boton,icono);
        }

        public string CleanSQL(string str)
        {
            string strout = "";
            string[] forbiddenchars = { "'", "=", "<", ">", ";", "\\", "?", "!", "´", "¿", "¡" ,"/"};
            int i, j;
            int coinc;

<<<<<<< HEAD
            for (i = 0; i < str.Length; i++){
                coinc = 0;
                for (j = 0; j < forbiddenchars.Length; j++){
                    coinc = str.Substring(i, 1) == forbiddenchars[j] ? coinc + 1 : coinc = 0;
=======
            for (i = 0; i < str.Length; i++)
            {
                coinc = 0;
                for (j = 0; j < forbiddenchars.Length; j++)
                {
                    coinc = str.Substring(i, 1) == forbiddenchars[j] ? coinc + 1 : coinc + 0;
>>>>>>> Agregar archivos de proyecto.
                }
                strout = coinc == 0 ? strout + str.Substring(i, 1) : strout;
            }
            return strout;
        }

        public Boolean goodtyped(KeyPressEventArgs e)
        {
            Boolean res = false;
<<<<<<< HEAD

            if(char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == (char)8)res = true;
=======
            if(char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == (char)8)
            {
                res = true;
            }
>>>>>>> Agregar archivos de proyecto.

            return res;
        }

        public Boolean Onlystrings(KeyPressEventArgs e)
        {
            Boolean res = false;
<<<<<<< HEAD

            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)8) res = true;

            return res;
        }

=======
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)8)
            {
                res = true;
            }

            return res;
        }
>>>>>>> Agregar archivos de proyecto.
    }
}
