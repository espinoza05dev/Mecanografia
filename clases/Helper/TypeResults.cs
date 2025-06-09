using MECANOGRAFIA.clases.AUTH;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MECANOGRAFIA.clases
{
    public class TypeResults
    {
        clases.auth a = new clases.auth();
        clases.db DB = new clases.db();
        mecanografia.ESCRITURA E;
        List<string> palabras;
        public int[] CantGot { get; set; }
        public string ppm { get; set; }
        public string pc { get; set; }
        public string pi { get; set; }
        public string Lomitida { get; set; }
        public string LPosM { get; set; }
        public string LAddedM { get; set; }

        
        public Int16 WrongWords()
        {
            Int16 res = 0;
            E = new mecanografia.ESCRITURA();
            palabras = new List<string>(E.txtpalabrasescritas.Text.Trim().Split(' '));
            string palabra_mostrada = palabras[0];

            if (E.txtpalabrasescritas.Text.Trim().Length == palabra_mostrada.Length || E.txtpalabrasescritas.Text.Trim().Length != palabra_mostrada.Length)
            {
                if (E.txtpalabrasescritas.Text.Trim() != palabra_mostrada){
                    res = 1;
                }
            } 
        
            return res;
        }

        public void SaveWrongWords()
        {
            E = new mecanografia.ESCRITURA();
            if (SesionManager.usuario_sesion != string.Empty) if (WrongWords() == 1) DB.guardar("LISTA_P_M_E", "USUARIO,P_MAL_E", $"'{SesionManager.usuario_sesion}','{E.txtpalabrasescritas.Text.Trim()}'");
        }
    }
}
