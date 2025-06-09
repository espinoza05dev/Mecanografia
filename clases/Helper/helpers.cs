﻿using System;
using System.Windows.Forms;

namespace MECANOGRAFIA.clases
{
    public class helpers
    {
        public void SeeRawSQLQuery(string query, int debug)
        {
            if (debug > 0){
                Clipboard.SetText(query);
                MessageBox.Show(query);
            }
        }

        public void ShowNumber<T>(T num) where T : struct, IComparable<T>{
            if (num.CompareTo(default(T)) > 0) MessageBox.Show(num.ToString());
        }

        public bool Question(string msg)
        {
            bool resp = false;
            MessageBoxButtons opciones = MessageBoxButtons.YesNo;
            MessageBoxIcon iconos = MessageBoxIcon.Question;
            if (MessageBox.Show(msg, "CONFIRMAR", opciones, iconos) == DialogResult.Yes)resp = true;
            
            return resp;
        }

        public void Succes(string msg, string titulo = "EXITO")
        {
            MessageBoxButtons boton = MessageBoxButtons.OK;
            MessageBoxIcon icono = MessageBoxIcon.Information;
            MessageBox.Show(msg, titulo, boton, icono);
        }

        public void Warning(string msg, string titulo = "ATENCION")=>MessageBox.Show(msg, titulo);
        

        public void Info(string msg, string titulo = "INFORMACION")
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

            for (i = 0; i < str.Length; i++){
                coinc = 0;
                for (j = 0; j < forbiddenchars.Length; j++){
                    coinc = str.Substring(i, 1) == forbiddenchars[j] ? coinc + 1 : coinc = 0;
                }
                strout = coinc == 0 ? strout + str.Substring(i, 1) : strout;
            }
            return strout;
        }

        public Boolean goodtyped(KeyPressEventArgs e)
        {
            Boolean res = false;

            if(char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar) || e.KeyChar == (char)8)res = true;

            return res;
        }

        public Boolean Onlystrings(KeyPressEventArgs e)
        {
            Boolean res = false;

            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)8) res = true;

            return res;
        }

    }
}
