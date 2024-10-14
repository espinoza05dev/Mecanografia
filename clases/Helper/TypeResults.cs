using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MECANOGRAFIA.clases
{
    public class TypeResults
    {
        clases.auth a = new clases.auth();
        clases.db DB = new clases.db();
        static private mecanografia.ESCRITURA E;
        static private mecanografia.DESAFIOS.FrmDificultades D;
        static private mecanografia.DESAFIOS.FrmPersonalizado P;
        static private mecanografia.DESAFIOS.FrmTematicasV T;
        private List<string> palabras = new List<string>();
        private List<string> palabras_escritas = new List<string>();
        private string[] TextTyped { get; set; }
        private string[] textshowed { get; set; }
        private string palabra_escrita, palabra_mostrada;

        public int[] CantGot { get; set; }
        public int correctas { get; set; }
        public int incorrectas { get; set; }
        public int pcompletadas { get; set; }
        public int L_omitidas { get; set; }
        public int L_PosM { get; set; }
        public int L_added { get; set; }
        public int i { get; set; }
        public int j { get; set; }
        public string p { get; set; } 
        public string p_escrita { get; set; }
        public string ppm { get; set; }
        public string pc { get; set; }
        public string pi { get; set; }
        public string Lomitida { get; set; }
        public string LPosM { get; set; }
        public string LAddedM { get; set; }

        public void LetterAddedWrongly(int frm)
        {
            TextBox[] txtpalabrasmostradas = { E.txtpalabrasmostradas, D.txtpalabrasmostradas, P.txtpalabrasmostradas, T.txtpalabrasmostradas };
            TextBox[] txtpalabrasescritas = { E.txtpalabrasescritas, D.txtpalabrasescritas, P.txtpalabrasescritas, T.txtpalabrasescritas };
            if (frm >= 0 && frm <=4)
            {
                palabras = new List<string>(txtpalabrasmostradas[frm].Text.Trim().Split(' '));
                palabras_escritas = new List<string>(txtpalabrasescritas[frm].Text.Trim().Split(' '));
            }

            p = palabras.Count > 0 ? palabras[0] : string.Empty;
            p_escrita = palabras_escritas.Count > 0 ? palabras_escritas[0] : string.Empty;

            i = p.Length;
            j = p_escrita.Length;

            while (j > i) { L_added++; j--; }
        }

        public int WrongLetterPosition(int frm)
        {
            TextBox[] txtpalabrasmostradas = { E.txtpalabrasmostradas, D.txtpalabrasmostradas, P.txtpalabrasmostradas, T.txtpalabrasmostradas };
            TextBox[] txtpalabrasescritas = { E.txtpalabrasescritas, D.txtpalabrasescritas, P.txtpalabrasescritas, T.txtpalabrasescritas };
            if (frm >= 0 && frm <=4)
            {
                textshowed = (txtpalabrasmostradas[frm].Text.Trim().Split(' '));
                TextTyped = (txtpalabrasescritas[frm].Text.Trim().Split(' '));
            }

            int minLength = Math.Min(textshowed.Length, TextTyped.Length);

            for (i = 0; i < minLength; i++)
            {
                p = textshowed[i];
                p_escrita = TextTyped[i];

                for (j = 0; j < Math.Min(p.Length, p_escrita.Length); j++) { if (p[j] != p_escrita[j]) { L_PosM++; } }
            }
            return L_PosM;
        }

        public void SkippedLetters(int frm)
        {
            TextBox[] txtpalabrasmostradas = { E.txtpalabrasmostradas, D.txtpalabrasmostradas, P.txtpalabrasmostradas, T.txtpalabrasmostradas };
            TextBox[] txtpalabrasescritas = { E.txtpalabrasescritas, D.txtpalabrasescritas, P.txtpalabrasescritas, T.txtpalabrasescritas };
            if (frm >= 0 && frm <=4)
            {
                palabras = new List<string>(txtpalabrasmostradas[frm].Text.Trim().Split(' '));
                palabras_escritas = new List<string>(txtpalabrasescritas[frm].Text.Trim().Split(' '));
            }

            p = palabras.Count > 0 ? palabras[0] : string.Empty;
            p_escrita = palabras_escritas.Count > 0 ? palabras_escritas[0] : string.Empty;

            i = p.Length;
            j = p_escrita.Length;

            while (i > j) { L_omitidas++; i--; }
        }

        public void Verificar_palabras(int frm)
        {
            TextBox[] txtpalabrasmostradas = { E.txtpalabrasmostradas, D.txtpalabrasmostradas, P.txtpalabrasmostradas, T.txtpalabrasmostradas };
            TextBox[] txtpalabrasescritas = { E.txtpalabrasescritas, D.txtpalabrasescritas, P.txtpalabrasescritas, T.txtpalabrasescritas };
            if (frm >= 0 && frm <= 4)
            {
                palabras = new List<string>(txtpalabrasmostradas[frm].Text.Trim().Split(' '));
                palabras_escritas = new List<string>(txtpalabrasescritas[frm].Text.Trim().Split(' '));
            }

            palabra_mostrada = palabras[0];

            if (palabra_escrita.Length == palabra_mostrada.Length || palabra_escrita.Length != palabra_mostrada.Length)
            {
                if (palabra_escrita == palabra_mostrada) correctas++;
                else incorrectas++;

                pcompletadas++;
                palabras.RemoveAt(0);
                if(frm == 0)E.txtpalabrasmostradas.Text = string.Join(" ", palabras);
                if(frm == 1)D.txtpalabrasmostradas.Text = string.Join(" ", palabras);
                if(frm == 2)P.txtpalabrasmostradas.Text = string.Join(" ", palabras);
                if(frm == 3)T.txtpalabrasmostradas.Text = string.Join(" ", palabras);

            }
        }

        public Int16 WrongWords()
        {
            Int16 res = 0;
            List<string> palabras = new List<string>(E.txtpalabrasmostradas.Text.Trim().Split(' '));
            string palabra_mostrada = palabras[0];

            if (E.txtpalabrasescritas.Text.Trim().Length == palabra_mostrada.Length || E.txtpalabrasescritas.Text.Trim().Length != palabra_mostrada.Length) if (E.txtpalabrasescritas.Text.Trim() != palabra_mostrada) res = 1;

            return res;
        }

        public void SaveWrongWords()
        {
            if (a.usuario_sesion != string.Empty) if (WrongWords() == 1) DB.guardar("LISTA_P_M_E", "USUARIO,P_MAL_E", $"'{a.usuario_sesion}','{E.txtpalabrasescritas.Text.Trim()}'");
        }
    }
}
