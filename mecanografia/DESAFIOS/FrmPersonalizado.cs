using MECANOGRAFIA.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MECANOGRAFIA.mecanografia.DESAFIOS
{
    public partial class FrmPersonalizado : Form
    {
        clases.auth a = new clases.auth();
        clases.helpers h = new clases.helpers();
        clases.db DB = new clases.db();
        clases.TypeResults t = new clases.TypeResults();
        string content = "",filePath = "";
        int correctas, incorrectas, pcompletadas, L_omitidas, L_PosM, L_added, i, j;
        string palabra_mostrada, palabra_escrita;
        string[] TextTyped, textshowed;
        List<string> palabras, palabras_escritas;
        
        public FrmPersonalizado()
        {
            InitializeComponent();
        }

        private void BTNsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarfrm()
        {
            txtpalabrasescritas.Enabled = false;
            this.Text = "Modo Personalizado " + auth.usuario_sesion;
            btnreiniciar.Enabled = false;
        }

        private void FrmPersonalizado_Load(object sender, EventArgs e)
        {
            cargarfrm();
        }

        private void RELOJ_Tick(object sender, EventArgs e)
        {
            int conteo = Convert.ToInt32(lblSEGUNDOS.Text);
            conteo--;
            lblSEGUNDOS.Text = conteo.ToString();

            if (conteo == 45 && pcompletadas == 0){
                RELOJ.Stop();
                h.Info("Te encuentras lejos del teclado?");
                txtpalabrasescritas.Clear();
                lblSEGUNDOS.Text = "60";
                btnIniciar.Enabled = false;
                btnreiniciar.Enabled = true;
                btnsubirtexto.Enabled = true;
                txtpalabrasescritas.Enabled = false;
            }else if (incorrectas >= 10){
                RELOJ.Stop();
                h.Warning("!Demasiadas palabras t.incorrectas!");
                txtpalabrasescritas.Clear();
                lblSEGUNDOS.Text = "60";
                btnreiniciar.Enabled = true;
                txtpalabrasescritas.Enabled = false;
                btnsubirtexto.Enabled = true;
            }else{
                if (conteo == 0){
                    RELOJ.Stop();
                    MessageBox.Show("!Se ha agotado el tiempo!");
                    double porcentaje = Convert.ToDouble(Math.Round(((double)correctas / pcompletadas) * 100, 3));
                    string ShowPorcentaje = porcentaje.ToString() + "%";
                    ListViewItem item = item = lvPalabras.Items.Add(pcompletadas.ToString());
                    item.SubItems.Add(correctas.ToString());
                    item.SubItems.Add(incorrectas.ToString());
                    item.SubItems.Add(ShowPorcentaje);
                    item.SubItems.Add(L_omitidas.ToString());
                    item.SubItems.Add(L_PosM.ToString());
                    item.SubItems.Add(L_added.ToString());

                    btnsubirtexto.Enabled = true;
                    txtpalabrasescritas.Clear();
                    lblSEGUNDOS.Text = "60";
                    btnIniciar.Enabled = false;
                    btnreiniciar.Enabled = true;
                    txtpalabrasescritas.Enabled = false;

                    foreach (ListViewItem datosLV in lvPalabras.Items){
                        t.ppm = datosLV.SubItems[0].Text;
                        t.pc = datosLV.SubItems[1].Text;
                        t.pi = datosLV.SubItems[2].Text;
                        t.Lomitida = datosLV.SubItems[4].Text;
                        t.LPosM = datosLV.SubItems[5].Text;
                        t.LAddedM = datosLV.SubItems[6].Text;
                    }

                    if (auth.usuario_sesion != string.Empty) SaveRecords();
                }
            }
        }

        private void SaveRecords()
        {
            DataTable datos_records_repetidos = DB.recuperar("R_RECORDS_PERSONALIZADO", "*", "R_NFILE = '" + Path.GetFileName(filePath) + "'");
            DataTable datos_records = DB.recuperar("RECORDS_PERSONALIZADO", "*", "NFILE = '" + Path.GetFileName(filePath) + "'");
            double porcentaje = Convert.ToDouble(Math.Round(((double)correctas / pcompletadas) * 100, 3));
            string ShowPorcentaje = porcentaje.ToString() + "%";
            if (datos_records.Rows.Count == 0 && datos_records_repetidos.Rows.Count == 0){
                DB.guardar("RECORDS_PERSONALIZADO", "USUARIO,NFILE,PPM,C,I,PREC,L_O,L_POS_M,L_ADDED", $"'{auth.usuario_sesion}','{Path.GetFileName(filePath)}',{Convert.ToInt32(t.ppm)},{Convert.ToInt32(t.pc)},{Convert.ToInt32(t.pi)},'{ShowPorcentaje}',{Convert.ToInt32(t.Lomitida)},{Convert.ToInt32(t.LPosM)},{Convert.ToInt32(t.LAddedM)}");
                DB.guardar("R_RECORDS_PERSONALIZADO", "USUARIO,R_NFILE", $"'{auth.usuario_sesion}','{Path.GetFileName(filePath)}'");
            }else if (datos_records.Rows.Count > 0 && datos_records_repetidos.Rows.Count == 1 )DB.guardar("RECORDS_PERSONALIZADO", "USUARIO,NFILE,PPM,C,I,PREC,L_O,L_POS_M,L_ADDED", $"'{auth.usuario_sesion}','{Path.GetFileName(filePath)}',{Convert.ToInt32(t.ppm)},{Convert.ToInt32(t.pc)},{Convert.ToInt32(t.pi)},'{ShowPorcentaje}',{Convert.ToInt32(t.Lomitida)},{Convert.ToInt32(t.LPosM)},{Convert.ToInt32(t.LAddedM)}");
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (content != ""){
                btnIniciar.Enabled = false;
                btnreiniciar.Enabled = false;
                txtpalabrasescritas.Enabled = true;
                txtpalabrasescritas.Focus();
                txtpalabrasescritas.Clear();
                correctas = 0;
                incorrectas = 0;
                pcompletadas = 0;
                L_omitidas = 0; L_PosM = 0; L_added = 0;
                lvPalabras.Items.Clear();
                btnsubirtexto.Enabled = false;
                RELOJ.Start();
            }else h.Warning("Presione el boton de buscar texto y seleccione algun texto que tenga");
        }

        private void RandomWords()
        {
            content = File.ReadAllText(filePath);
            string[] c = content.Split(' ');

            Random randomwords = new Random();
            for (int i = c.Length - 1; i > 0; i--)
            {
                int j = randomwords.Next(0, i + 1);
                string temp = c[i];
                c[i] = c[j];
                c[j] = temp;
            }

            txtpalabrasmostradas.Text = string.Join(" ", c);
        }

        private void botonR()
        {
            lblSEGUNDOS.Text = "60";
            btnreiniciar.Enabled = false;
            txtpalabrasescritas.Enabled = true;
            txtpalabrasescritas.Focus();
            txtpalabrasescritas.Clear();
            correctas = 0; incorrectas = 0; pcompletadas = 0; L_omitidas = 0; L_PosM = 0; L_added = 0;
            btnsubirtexto.Enabled = false;
            RELOJ.Start();
        }
       
        private void btnreiniciar_Click(object sender, EventArgs e)
        {
            if (h.Question("¿Desea que el texto del archivo sea aleatorio?")){
                RandomWords();
                botonR();
            }else{
                content = File.ReadAllText(filePath);
                txtpalabrasescritas.Text = content;
                botonR();
            }
        }

        private int LetterAddedWrongly()
        {
            palabras = new List<string>(txtpalabrasmostradas.Text.Trim().Split(' '));
            palabras_escritas = new List<string>(txtpalabrasescritas.Text.Trim().Split(' '));

            palabra_mostrada = palabras.Count > 0 ? palabras[0] : string.Empty;
            palabra_escrita = palabras_escritas.Count > 0 ? palabras_escritas[0] : string.Empty;

            i = palabra_mostrada.Length;
            j = palabra_escrita.Length;

            while (j > i) { L_added++; j--; }
            return L_added;
        }

        private int WrongLetterPosition()
        {
            textshowed = (txtpalabrasmostradas.Text.Trim().Split(' '));
            TextTyped = (txtpalabrasescritas.Text.Trim().Split(' '));


            int minLength = Math.Min(textshowed.Length, TextTyped.Length);

            for (i = 0; i < minLength; i++)
            {
                palabra_mostrada = textshowed[i];
                palabra_escrita = TextTyped[i];

                for (j = 0; j < Math.Min(palabra_mostrada.Length, palabra_escrita.Length); j++) { if (palabra_mostrada[j] != palabra_escrita[j]) { L_PosM++; } }
            }
            return L_PosM;
        }

        private int SkippedLetters()
        {
            palabras = new List<string>(txtpalabrasmostradas.Text.Trim().Split(' '));
            palabras_escritas = new List<string>(txtpalabrasescritas.Text.Trim().Split(' '));

            palabra_mostrada = palabras.Count > 0 ? palabras[0] : string.Empty;
            palabra_escrita = palabras_escritas.Count > 0 ? palabras_escritas[0] : string.Empty;

            i = palabra_mostrada.Length;
            j = palabra_escrita.Length;

            while (i > j) { L_omitidas++; i--; }
            return L_omitidas;
        }

        void Verificar_palabras()
        {
            palabras = new List<string>(txtpalabrasmostradas.Text.Trim().Split(' '));
            palabras_escritas = new List<string>(txtpalabrasescritas.Text.Trim().Split(' '));

            palabra_mostrada = palabras[0];
            palabra_escrita = palabras_escritas[0];

            if (palabra_escrita.Length == palabra_mostrada.Length || palabra_escrita.Length != palabra_mostrada.Length)
            {
                if (palabra_escrita == palabra_mostrada) { correctas++; }
                else { incorrectas++; }

                pcompletadas++;
                palabras.RemoveAt(0);
                txtpalabrasmostradas.Text = string.Join(" ", palabras);
            }
        }

        private void txtpalabrasescritas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space){
                WrongLetterPosition();
                SkippedLetters();
                LetterAddedWrongly();
                Verificar_palabras();
                txtpalabrasescritas.Clear();
            }
        }

        private void txtpalabrasescritas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = h.goodtyped(e) ? false : true;
        }

        private bool ContienePalabras(string filePath)
        {
            try{
                string content = File.ReadAllText(filePath);
                return !string.IsNullOrWhiteSpace(content);
            }catch (Exception ex){
                MessageBox.Show($"Error al leer el archivo: {ex.Message}");
                return false;
            }
        }

        private void MostrarPalabrasEnTextBox(string filePath)
        {
            try{
                 content = File.ReadAllText(filePath);
                txtpalabrasmostradas.Text = content;
            }catch (Exception ex) { h.Warning($"Error al leer el archivo: {ex.Message}"); }
        }

        private void btnsubirtexto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK){
                filePath = openFileDialog.FileName;

                if (ContienePalabras(filePath)) MostrarPalabrasEnTextBox(filePath);
                else h.Warning("El archivo no contiene palabras.");
            }
        }
    }
}
