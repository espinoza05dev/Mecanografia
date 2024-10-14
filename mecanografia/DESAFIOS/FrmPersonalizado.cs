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
            this.Text = "Modo Personalizado " + a.usuario_sesion;
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

            if (conteo == 45 && t.pcompletadas == 0){
                RELOJ.Stop();
                h.Info("Te encuentras lejos del teclado?");
                txtpalabrasescritas.Clear();
                lblSEGUNDOS.Text = "60";
                btnIniciar.Enabled = false;
                btnreiniciar.Enabled = true;
                btnsubirtexto.Enabled = true;
                txtpalabrasescritas.Enabled = false;
            }else if (t.incorrectas >= 10){
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

                    ListViewItem item = item = lvPalabras.Items.Add(t.pcompletadas.ToString());
                    item.SubItems.Add(t.correctas.ToString());
                    item.SubItems.Add(t.incorrectas.ToString());
                    item.SubItems.Add(Math.Round(((float)t.correctas / t.pcompletadas) * 100, 3).ToString() + "%");
                    item.SubItems.Add(t.L_omitidas.ToString());
                    item.SubItems.Add(t.L_PosM.ToString());
                    item.SubItems.Add(t.L_added.ToString());

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

                    if (a.usuario_sesion != string.Empty) SaveRecords();
                }
            }
        }

        private void SaveRecords()
        {
            DataTable datos_records_repetidos = DB.recuperar("R_RECORDS_PERSONALIZADO", "*", "R_NFILE = '" + Path.GetFileName(filePath) + "'");
            DataTable datos_records = DB.recuperar("RECORDS_PERSONALIZADO", "*", "NFILE = '" + Path.GetFileName(filePath) + "'");

            if (datos_records.Rows.Count == 0 && datos_records_repetidos.Rows.Count == 0){
                DB.guardar("RECORDS_PERSONALIZADO", "USUARIO,NFILE,PPM,C,I,PREC,L_O,L_POS_M,L_ADDED", $"'{a.usuario_sesion}','{Path.GetFileName(filePath)}',{Convert.ToInt32(t.ppm)},{Convert.ToInt32(t.pc)},{Convert.ToInt32(t.pi)},'{Math.Round(((float)t.correctas / t.pcompletadas) * 100, 3).ToString() + "%"}',{Convert.ToInt32(t.Lomitida)},{Convert.ToInt32(t.LPosM)},{Convert.ToInt32(t.LAddedM)}");
                DB.guardar("R_RECORDS_PERSONALIZADO", "USUARIO,R_NFILE", $"'{a.usuario_sesion}','{Path.GetFileName(filePath)}'");
            }else if (datos_records.Rows.Count > 0 && datos_records_repetidos.Rows.Count == 1 )DB.guardar("RECORDS_PERSONALIZADO", "USUARIO,NFILE,PPM,C,I,PREC,L_O,L_POS_M,L_ADDED", $"'{a.usuario_sesion}','{Path.GetFileName(filePath)}',{Convert.ToInt32(t.ppm)},{Convert.ToInt32(t.pc)},{Convert.ToInt32(t.pi)},'{Math.Round(((float)t.correctas / t.pcompletadas) * 100, 3).ToString() + "%"}',{Convert.ToInt32(t.Lomitida)},{Convert.ToInt32(t.LPosM)},{Convert.ToInt32(t.LAddedM)}");
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (content != ""){
                btnIniciar.Enabled = false;
                btnreiniciar.Enabled = false;
                txtpalabrasescritas.Enabled = true;
                txtpalabrasescritas.Focus();
                txtpalabrasescritas.Clear();
                t.correctas = 0;
                t.incorrectas = 0;
                t.pcompletadas = 0;
                t.L_omitidas = 0; t.L_PosM = 0; t.L_added = 0;
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
            t.correctas = 0; t.incorrectas = 0; t.pcompletadas = 0; t.L_omitidas = 0; t.L_PosM = 0; t.L_added = 0;
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

        private void txtpalabrasescritas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space){
                t.WrongLetterPosition(2);
                t.SkippedLetters(2);
                t.LetterAddedWrongly(2);
                t.Verificar_palabras(2);
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
