using MECANOGRAFIA.clases;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using MECANOGRAFIA.clases.AUTH;

namespace MECANOGRAFIA.mecanografia
{
    public partial class ESCRITURA : Form , IEscritura
    {
        clases.ENV env = new clases.ENV();
        clases.helpers h = new clases.helpers();
        clases.auth a = new clases.auth();
        clases.TypeResults t = new clases.TypeResults();
        clases.db DB = new clases.db();
        clases.Helper.User u = new clases.Helper.User();
        clases.Helper.FormInstance FM = new clases.Helper.FormInstance();
        
        int correctas, incorrectas, pcompletadas, L_omitidas,L_PosM,L_added,i,j,res = 0;
        string contenido,palabra_mostrada, palabra_escrita;
        string[] TextTyped, textshowed;
        List<string> palabras,palabras_escritas;

        public ESCRITURA() => InitializeComponent();
                  
        private void zero_values(){
            correctas = 0; incorrectas = 0; pcompletadas = 0; L_omitidas = 0; L_PosM = 0; L_added = 0;
        }

        private void NO_SESION()
        {
            this.Text = a.APPNAME;
            SesionManager.usuario_sesion = string.Empty;
        }

        private void cargarformulario()
        {
            if (a.VerifyFile() == 0){
                if (env.VerifyDate() > 0)
                {
                    a.SesionterminadaAuto();
                    NO_SESION();
                }
                else{ 
                    this.Text = $"{a.APPNAME}: {a.SesionIniciada()}";
                    SesionManager.usuario_sesion = a.SesionIniciada();
                }
            }else NO_SESION();

            contenido = File.ReadAllText(auth.filePathJson);
            var palabras = JObject.Parse(contenido);

            if (palabras["activado"].ToString() == "onn") RDsi.Checked = true;
            else  RDno.Checked = true;
            
            this.Size = new Size(621, 366);
            this.P_ESCRITURA.Location = new Point(3, 3);
            P_ESCRITURA.Size = new Size(602, 297);
            lista_palabras();
            txtpalabrasescritas.Enabled = false;
            btnreiniciar.Enabled = false;
            P_REGISTRO.Visible = false;
            P_INICIOSESION.Visible = false;
            txtpalabrasmostradas.Enabled = false;
        }

        public void lista_palabras()
        {
            string[] words = { "casa", "perro", "gato", "sol", "luna", "árbol", "flor", "mesa", "silla", "coche", "amarillo", "rojo", "verde", "azul", "feliz", "triste", "amor", "odio", "jugar", "correr", "comer", "dormir", "agua", "fuego", "nieve", "tierra", "aire", "soltero", "casado", "niño", "niña", "escuela", "libro", "maestro", "estudiante", "cielo", "nube", "montaña", "río", "mar", "lago", "ciudad", "país", "musica", "baile", "pintura", "dibujo", "pelota", "juego", "risa", "llanto", "familia", "amigo", "hermano", "hermana", "padre", "madre", "abuelo", "abuela", "comida", "bebida", "manzana", "naranja", "banana", "uva", "pollo", "pescado", "carne", "vegetal", "fruta", "computadora", "teléfono", "internet", "television", "radio", "calle", "avenida", "parque", "bosque", "camino", "viaje", "avión", "tren", "autobús", "bicicleta", "caminar", "correr", "nadar", "viajar", "trabajo", "dinero", "compra", "venta", "mercado", "tienda", "ropa", "zapatos", "camisa", "película", "teatro", "arte", "historia", "ciencia", "idioma", "palabra", "frase", "párrafo", "número", "letra", "color", "forma", "tamaño", "peso", "altura", "ancho", "largo", "corto", "rápido", "lento", "fuerte", "débil", "alto", "bajo", "grande", "pequeño", "nuevo", "viejo", "bueno", "malo", "amable", "cruel", "feliz", "triste", "fácil", "difícil", "claro", "oscuro", "caliente", "frío", "rico", "pobre", "limpio", "sucio", "salud", "paz", "guerra", "educación", "trabajador", "dormitorio", "peluche", "lápiz", "nube", "teléfono", "silla", "bicicleta", "deporte", "reloj", "calendario", "periódico", "ventana", "puerta", "llave", "candado", "jardín", "mañana", "tarde", "noche", "verano", "invierno", "otoño", "relación", "romance", "teclado", "mouse", "pantalla", "luz", "energía", "gas", "aire", "respirar", "sonrisa", "dentista", "cabello", "cepillo", "espejo", "perfume", "música", "radio", "melodía", "piano", "violín", "juego", "carta", "dado", "moneda", "billete", "cambio", "comida", "bebida", "cuchillo", "tenedor", "cuchara", "plato", "vaso", "taza", "cena", "almuerzo", "desayuno", "bolsa", "zapatos", "botas", "sombrero", "gorro", "bufanda", "guantes", "abrigo", "falda", "camiseta", "calcetines", "zapatillas", "cine", "película", "escena", "actor", "actriz", "director", "guion", "cámara", "fotografía", "pintura", "lienzo", "colores", "pincel", "forma", "espacio", "tiempo", "reloj", "arena", "océano", "isla", "costa", "montaña", "valle", "cima", "abismo", "pasaporte", "frontera", "viaje", "turista", "hotel", "cama", "almohada", "cobija", "sueño", "pesadilla", "vuelo", "aeropuerto", "boleto", "avión", "autobús", "tren", "estación", "automóvil", "bicicleta", "caminata", "excursión", "aventura", "explorar", "descubrir", "viaje", "destino", "mapa", "brújula", "norte", "sur", "este", "oeste", "flecha", "señal", "tráfico", "peatón", "vehículo", "carretera", "calle", "avenida", "trabajo", "oficina", "jefe", "empleado", "colega", "negocio", "éxito", "fracaso", "metas", "logro", "proyecto", "equipo", "reunión", "cliente", "producto", "servicio", "venta", "sol", "luna", "cielo", "mar", "montaña", "árbol", "flor", "río", "nieve", "viento", "animal", "perro", "gato", "pez", "pájaro", "oso", "casa", "calle", "coche", "bicicleta", "comida", "manzana", "pan", "queso", "leche", "agua", "carne", "fruta", "verdura", "arroz", "juego", "pelota", "muñeca", "juguete", "canción", "música", "baile", "libro", "letra", "número", "color", "rojo", "azul", "verde", "amarillo", "blanco", "negro", "gris", "naranja", "rosa", "día", "noche", "hora", "minuto", "segundo", "mes", "año", "ayer", "hoy", "mañana", "feliz", "triste", "enojado", "asustado", "sorpresa", "contento", "aburrido", "cansado", "dormir", "despertar", "trabajo", "estudio", "escuela", "maestro", "alumno", "clase", "proyecto", "tarea", "examen", "respuesta", "deporte", "fútbol", "baloncesto", "natación", "carrera", "ejercicio", "salud", "medicina", "doctor", "hospital", "ropa", "camisa", "pantalón", "zapatos", "sombrero", "chaqueta", "abrigo", "vestido", "calcetines", "ropa", "interior", "calzado", "tecnología", "teléfono", "computadora", "internet", "aplicación", "mensaje", "correo", "redes", " sociales", "cámara", "pantalla", "viaje", "avión", "coche", "tren", "barco", "hotel", "vacaciones", "turista", "mapa", "guía", "familia", "padre", "madre", "hermano", "hermana", "abuelo", "abuela", "hijo", "hija", "niño", "niña", "cariño", "amigo", "amiga", "amor", "beso", "abrazo", "risa", "llanto", "fiesta", "regalo", "podemos", "entonces", "cosas", "años", "porque", "sin", "un", "ella", "porque", "estas", "me", "hasta", "yo", "tiempo" };

            Random randomwords = new Random();
            for (i = words.Length - 1; i > 0; i--){
                j = randomwords.Next(0, i + 1);
                string temp = words[i];
                words[i] = words[j];
                words[j] = temp;
            }
            txtpalabrasmostradas.Text = string.Join(" ", words);
        }

        private int validar_sesion()
        {
            if (txtusuario_sesion.Text.Length == 0 && CBusuario.Visible == false){
                h.Warning("el usuario es obligatorio");
                txtusuario.Focus();
                res++;
            }else if (txtcontra_sesion.Text.Length == 0 ){
                h.Warning("la contraseña es obligatoria");
                txtcontra.Focus();
                res++;
            }
            return res;
        }

        private int validar_registro()
        {
            if (txtcontra.Text.Length == 0){
                h.Warning("la contraseña es obligatoria");
                txtcontra.Focus();
                res++;
            }else if (txtusuario.Text.Length == 0){
                h.Warning("el usuario es obligatorio");
                txtusuario.Focus();
                res++;
            }

            return res;
        }

        private void SetColors(IEnumerable<Control> controls, Color backColor, Color foreColor)
        {
            foreach (var control in controls)
            {
                control.BackColor = backColor;
                control.ForeColor = foreColor;
            }
        }

        public void cambiarmodos()
        {
            var labels = new[] { lblSEGUNDOS, lblINCIAR_SESION, lbl1, lbl3, lbl4, lbl5, lbl6 };
            var buttons = new[] { btncambiarmodos, btnIniciar, btnreiniciar, btncancelar, btnentrar_REGISTRO, btnentrar_INCIOSESION, btncancelar_sesion, btnver, btnverSesion, btnVolverAEscritura, btnVolverASesion };
            var textboxes = new[] { txtpalabrasescritas, txtpalabrasmostradas, txtcontra, txtcontra_sesion, txtusuario, txtusuario_sesion };
            var combos = new[] { CBusuario };
            var panels = new[] { P_ESCRITURA, P_INICIOSESION, P_REGISTRO, panel1 };

            if (P_OFF.BackColor == Color.Red)
            {
                P_ON.BackColor = Color.Green;
                P_OFF.BackColor = Color.Gray;

                SetColors(labels, Color.Black, Color.White);
                SetColors(buttons, Color.Black, Color.White);
                SetColors(textboxes, Color.Black, Color.White);
                SetColors(combos, Color.Black, Color.White);
                SetColors(new[] { lvPalabras }, Color.Black, Color.White);
                SetColors(panels, Color.Black, Color.White);

                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                MenuOpciones.ForeColor = Color.Black;
            }
            else if (P_ON.BackColor == Color.Green)
            {
                P_ON.BackColor = Color.Gray;
                P_OFF.BackColor = Color.Red;

                SetColors(labels, Color.Navy, Color.White);
                SetColors(buttons, Color.Navy, Color.White);
                SetColors(textboxes, Color.SteelBlue, Color.White);
                SetColors(new[] { txtpalabrasescritas }, Color.SteelBlue, Color.Black); // Excepción
                SetColors(new[] { lvPalabras }, Color.SteelBlue, Color.Black);
                SetColors(combos, Color.SteelBlue, Color.White);
                SetColors(panels, Color.Navy, Color.White);

                this.BackColor = Color.Navy;
                this.ForeColor = Color.Black;
                MenuOpciones.ForeColor = Color.Black;
            }
        }

        public void iniciar(int inicio)
        {
            //reinicio
            if (inicio == 1){
                lblSEGUNDOS.Text = "60";
                lista_palabras();
            }
            //inicio
            if (inicio == 2){
                btnIniciar.Enabled = false;
                txtpalabrasmostradas.Enabled = true;
                lvPalabras.Items.Clear();
            }

            MenuOpciones.Enabled = false;
            btnreiniciar.Enabled = false;
            txtpalabrasescritas.Enabled = true;
            txtpalabrasescritas.Focus();
            txtpalabrasescritas.Clear();
            zero_values();
            lblINCIAR_SESION.Enabled = false;
            lblregistro.Enabled = false;
            btncambiarmodos.Enabled = false;
            RELOJ.Start();
        }

        public void registry_achievements_C(string pc)
        {
            t.CantGot = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            foreach (int threshold in t.CantGot)
            {
                DataTable datos = DB.recuperar("LOGROS_USUARIOS", "*", $"CANT = {threshold} AND LOGRO = 'PC' AND USUARIO = '{SesionManager.usuario_sesion}'");
                if (datos.Rows.Count == 0 && Convert.ToInt32(pc) >= threshold)
                {
                    DB.guardar("LOGROS_USUARIOS", "USUARIO,LOGRO,CANT", $"'{SesionManager.usuario_sesion}','PC',{threshold}");
                }
            }
        }

        public void registry_achievements(string ppm)
        {
            t.CantGot = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 120, 140, 150 };

            foreach (int threshold in t.CantGot)
            {
                DataTable datos = DB.recuperar("LOGROS_USUARIOS", "*", $"CANT = {threshold} AND LOGRO = 'PPM' AND USUARIO = '{SesionManager.usuario_sesion}'");
                if (datos.Rows.Count == 0 && Convert.ToInt32(ppm) >= threshold)
                {
                    DB.guardar("LOGROS_USUARIOS", "USUARIO,LOGRO,CANT", $"'{SesionManager.usuario_sesion}','PPM',{threshold}");
                }
            }
        }

        private void ESCRITURA_Load(object sender, EventArgs e) => cargarformulario();

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

        private void Verificar_palabras()
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
                t = new TypeResults();
                WrongLetterPosition();
                SkippedLetters();
                LetterAddedWrongly();
                Verificar_palabras();
                t.SaveWrongWords();
                txtpalabrasescritas.Clear();
            }
        }

        private void ExceptionsKeyBoard(int msg = 0)
        {
            if(msg == 1) h.Info("Te encuentras lejos del teclado?");
            if(msg == 2) h.Warning("!Demasiadas palabras incorrectas!");
            if(msg == 3) h.Info("!Se ha agotado el tiempo!");

            RELOJ.Stop();
            txtpalabrasescritas.Clear();
            lblSEGUNDOS.Text = "60";
            btnIniciar.Enabled = false;
            btnreiniciar.Enabled = true;
            txtpalabrasescritas.Enabled = false;
            lblINCIAR_SESION.Enabled = true;
            lblregistro.Enabled = true;
            MenuOpciones.Enabled = true;
            btncambiarmodos.Enabled = true;

        }
        
        private void RELOJ_Tick(object sender, EventArgs e)
        {
            int conteo = Convert.ToInt32(lblSEGUNDOS.Text);
            conteo--;
            lblSEGUNDOS.Text = conteo.ToString();

            if (conteo <= 45 && pcompletadas == 0) ExceptionsKeyBoard(1);
            else if (incorrectas >= 10) ExceptionsKeyBoard(2);
            else
            {
                if (conteo == 0)
                {
                    ExceptionsKeyBoard(3);

                    double porcentaje = Convert.ToDouble(Math.Round(((double)correctas / pcompletadas) * 100, 3));
                    string ShowPorcentaje = porcentaje.ToString() + "%";
                    ListViewItem item =
                    item = lvPalabras.Items.Add(pcompletadas.ToString());
                    item.SubItems.Add(correctas.ToString());
                    item.SubItems.Add(incorrectas.ToString());
                    item.SubItems.Add(ShowPorcentaje);
                    item.SubItems.Add(L_omitidas.ToString());
                    item.SubItems.Add(L_PosM.ToString());
                    item.SubItems.Add(L_added.ToString());

                    foreach (ListViewItem datosLV in lvPalabras.Items)
                    {
                        t.ppm = datosLV.SubItems[0].Text;
                        t.pc = datosLV.SubItems[1].Text;
                        t.pi = datosLV.SubItems[2].Text;
                        t.Lomitida = datosLV.SubItems[4].Text;
                        t.LPosM = datosLV.SubItems[5].Text;
                        t.LAddedM = datosLV.SubItems[6].Text;
                    }

                    if (SesionManager.usuario_sesion != string.Empty)
                    {
                        DB.guardar("RECORDS_USUARIOS", "USUARIO,PALABRAS_POR_MINUTO,PALABRAS_CORRECTAS,PALABRAS_INCORRECTAS,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{SesionManager.usuario_sesion}','{t.ppm}','{t.pc}','{t.pi}','{ShowPorcentaje}','{t.Lomitida}','{t.LPosM}','{t.LAddedM}'");
                        registry_achievements(t.ppm);
                        registry_achievements_C(t.pc);
                    }
                }
            }
        }

        private void lblINCIAR_SESION_Click(object sender, EventArgs e)
        {
            if (SesionManager.usuario_sesion == string.Empty)DesingSesion();
            else if (h.Question(u.msg) == true)DesingSesion(true);
        }

        private void btnIniciar_Click(object sender, EventArgs e) => iniciar(2);

        private void btncancelar_Click(object sender, EventArgs e)
        {
            txtusuario.Clear(); txtcontra.Clear();
        }

        private void btnver_Click(object sender, EventArgs e) => txtcontra.UseSystemPasswordChar = txtcontra.UseSystemPasswordChar ? false : true;

        private void btnentrar_REGISTRO_Click(object sender, EventArgs e)
        {
            if (validar_registro() == 0)
            {
                u.tabla = "USUARIOS";
                u.campos = $"USUARIO,NAME_PC,CONTRA,FECHASESION";
                u.valores = $"'{h.CleanSQL(txtusuario.Text.Trim())}','{Dns.GetHostName()}','{a.MakeHash(txtcontra.Text)}','{DateTime.Now}'";
                u.condicion = $"USUARIO = '{txtusuario.Text.Trim()}'";
                DataTable datos = DB.recuperar(u.tabla, "*", u.condicion);

                if (datos.Rows.Count > 0)
                {
                    h.Warning("El usuario " + txtusuario.Text.Trim() + " ya existe ingrese otro");
                    txtusuario.Focus();
                }
                else
                {
                    if (DB.guardar(u.tabla, u.campos, u.valores) > 0)
                    {
                        h.Succes("Se ha registrado con exito");
                        MenuOpciones.Enabled = true;
                        SesionManager.usuario_sesion = txtusuario.Text;

                        DataTable d = DB.recuperar("RACHA_USUARIOS_DS", "*", $"USUARIO = '{SesionManager.usuario_sesion}'");
                        if (d.Rows.Count == 0)
                        {
                            u.dias_seguido++;
                            DB.guardar("RACHA_USUARIOS_DS", "USUARIO,DIAS_S", $"'{SesionManager.usuario_sesion}','{u.dias_seguido}'");
                        }
                        d.Dispose();

                        this.Text = a.APPNAME + ": "+ txtusuario.Text;
                        lvPalabras.Items.Clear();
                        P_REGISTRO.Visible = false;
                        P_ESCRITURA.Visible = true;
                        txtcontra.Clear();
                        txtusuario.Clear();

                        this.Size = new Size(621, 366);
                        MenuOpciones.Visible = true;
                        this.FormBorderStyle = FormBorderStyle.FixedSingle;
                    }
                }
                datos.Dispose();
            }
        }

        private void btnentrar_INCIOSESION_Click(object sender, EventArgs e)
        {
            if (validar_sesion() == 0)
            {
                u.usuario = h.CleanSQL(txtusuario_sesion.Text); u.usuariocmb = CBusuario.Text; u.contra = a.MakeHash(txtcontra_sesion.Text);
                u.condicion = $"USUARIO = '{u.usuario}' AND CONTRA = '{u.contra}' OR USUARIO = '{u.usuariocmb}' AND CONTRA = '{u.contra}'";

                DataTable datos = DB.recuperar("USUARIOS", "USUARIO,CONTRA", u.condicion);
                if (datos.Rows.Count > 0)
                {

                    DataRow r = datos.Rows[0];
                    u.user2 = r["USUARIO"].ToString();
                    u.contra2 = r["CONTRA"].ToString();

                    if (u.usuario == u.user2 && u.contra == u.contra2 || u.usuariocmb == u.user2 && u.contra == u.contra2)
                    {
                        h.Succes("Ha inciado sesion con exito");

                        if (CBusuario.Text.Length == 0)
                        {
                            this.Text = a.APPNAME + ": " + txtusuario_sesion.Text;
                            SesionManager.usuario_sesion = txtusuario_sesion.Text;
                        }
                        else if (txtusuario_sesion.Text.Length == 0)
                        {
                            this.Text = a.APPNAME + ": " + CBusuario.Text;
                            SesionManager.usuario_sesion = CBusuario.Text;
                            var JSON = JObject.Parse(contenido);
                            JSON["activado"] = "onn";
                            JSON["usuario"] = CBusuario.Text;
                            File.WriteAllText(auth.filePathJson, JSON.ToString());
                        }

                        if (SesionManager.usuario_sesion != string.Empty)
                        {
                            DataTable d_seguidos = DB.recuperar("RACHA_USUARIOS_DS", "*", $"USUARIO = '{SesionManager.usuario_sesion}'");

                            if (d_seguidos.Rows.Count > 0)
                            {
                                foreach (DataRow row in d_seguidos.Rows)
                                {
                                    DateTime fec_registro_usuario;
                                    int fec = DateTime.Today.Day;

                                    fec_registro_usuario = Convert.ToDateTime(row["FECHA"]);
                                    u.dias_seguido = Convert.ToInt32(row["DIAS_S"]);
                                    int diasTranscurridos = (fec - fec_registro_usuario.Day);

                                    if (fec_registro_usuario.Date.Day == fec) break;
                                    else if (diasTranscurridos >= 2 && diasTranscurridos <= 30) StreakDays(false);
                                    else if (fec_registro_usuario.Date.Day < fec || fec_registro_usuario.Date.Day > fec) StreakDays(true);
                                }
                                d_seguidos.Dispose();
                            }

                            RDsi.Checked = false;
                            lvPalabras.Items.Clear();
                            P_ESCRITURA.Visible = true;
                            P_INICIOSESION.Visible = false;
                            txtusuario_sesion.Clear();
                            txtcontra_sesion.Clear();

                            this.Size = new Size(621, 366);
                            MenuOpciones.Visible = true;

                            MenuOpciones.Enabled = true;
                            this.FormBorderStyle = FormBorderStyle.FixedSingle;
                            DB.actualizar("USUARIOS", $"FECHASESION = '{DateTime.Now}'", $"USUARIO = '{SesionManager.usuario_sesion}'");
                        }else FailSesion();
                    }else FailSesion();
                    datos.Dispose();
                }
            }
        }

        private void FailSesion()
        {
            h.Warning("el Usuario y/o contraña son incorrectas");
            txtusuario_sesion.Focus();
        }

        private void StreakDays(bool streak)
        {
            if (streak == false){u.dias_seguido = 0; h.Info($"Tu racha se acabado");}
            if (streak == true){u.dias_seguido++; h.Info($"! Tienes una racha de {u.dias_seguido} días seguidos ¡");}
            DB.actualizar("RACHA_USUARIOS_DS", $"DIAS_S = '{u.dias_seguido}',FECHA = '{DateTime.Today}'", $"USUARIO = '{SesionManager.usuario_sesion}'");
        }

        private void btnverSesion_Click(object sender, EventArgs e) => txtcontra_sesion.UseSystemPasswordChar = txtcontra_sesion.UseSystemPasswordChar ? false : true;
        
        private void btncancelar_sesion_Click(object sender, EventArgs e)
        {
            txtusuario_sesion.Clear(); txtcontra_sesion.Clear();
        }

        private void OPTlogros_Click(object sender, EventArgs e)=>FM.ShowForm<mecanografia.LOGROS.FrmLogrosGeneral>(this.AddOwnedForm);

        private void mODOPERSONALIZADOToolStripMenuItem_Click(object sender, EventArgs e)=>FM.ShowForm<mecanografia.DESAFIOS.FrmPersonalizado>(this.AddOwnedForm);

        private void txtpalabrasescritas_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = h.Onlystrings(e) ? false : true;
  
        private void rECORDSMODOPERSONALIZADOToolStripMenuItem_Click(object sender, EventArgs e)=>FM.ShowForm<mecanografia.RECORS_USUARIOS.FrmRecordsPersonalizado>(this.AddOwnedForm);

        private void pALABRASMALESCRITASToolStripMenuItem_Click(object sender, EventArgs e)=>FM.ShowForm<mecanografia.PALABRAS_MAL_ESCRITAS.FrmP_M_E>(this.AddOwnedForm);

        private void tEMATICASToolStripMenuItem_Click(object sender, EventArgs e) => FM.ShowForm<mecanografia.DESAFIOS.FrmTematicasV>(this.AddOwnedForm);

        private void OPTdificultades_Click(object sender, EventArgs e) => FM.ShowForm<mecanografia.DESAFIOS.FrmDificultades>(this.AddOwnedForm);

        private void rECORDSToolStripMenuItem_Click_1(object sender, EventArgs e) => FM.ShowForm<mecanografia.RECORS_USUARIOS.RECORDS>(this.AddOwnedForm);

        private void OPTrecordsdifi_Click(object sender, EventArgs e) => FM.ShowForm<mecanografia.RECORS_USUARIOS.FrmRecordsDificultades>(this.AddOwnedForm);

        private void rECORDSTEMATICASToolStripMenuItem_Click(object sender, EventArgs e) => FM.ShowForm<mecanografia.RECORS_USUARIOS.FrmRecordsTematicas>(this.AddOwnedForm);


        private void DesingSesion(bool boot = false)
        {
            if (boot == true)
            {
                SesionManager.usuario_sesion = string.Empty;
                btnreiniciar.Enabled = false;
                btnIniciar.Enabled = true;
            }
            P_INICIOSESION.Size = new Size(324, 244);
            P_INICIOSESION.Location = new Point(-0, -2);
            this.Size = new Size(340, 310);
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            lvPalabras.Items.Clear();
            P_ESCRITURA.Visible = false;
            P_INICIOSESION.Visible = true;
            this.Text = " INICIO DE SESION ";
            MenuOpciones.Enabled = false;
        }

        private void lblregistro_Click(object sender, EventArgs e){
            MenuOpciones.Enabled = false;
            this.Text = "   REGISTRARSE";
            P_INICIOSESION.Visible = false;
            P_REGISTRO.Visible = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            P_REGISTRO.Size = new Size(230, 170);
            P_REGISTRO.Location = new Point(-5, -4);
            this.Size = new Size(240, 230);
        }

        private void btnVolverASesion_Click(object sender, EventArgs e){
            MenuOpciones.Enabled = true;
            this.Text = a.APPNAME + SesionManager.usuario_sesion;
            P_REGISTRO.Visible = false;
            txtusuario.Clear();
            txtcontra.Clear();

            this.Size = new Size(621, 366);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnVolverAEscritura_Click(object sender, EventArgs e){
            MenuOpciones.Enabled = true;
            this.Text = a.APPNAME;
            MenuOpciones.Visible = true;
            P_INICIOSESION.Visible = false;
            P_ESCRITURA.Visible = true;
            txtusuario_sesion.Clear();
            txtcontra_sesion.Clear();

            this.Size = new Size(621, 366);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btncambiarmodos_Click_1(object sender, EventArgs e) => cambiarmodos();

        private void OPTLogoSAEG_Click_1(object sender, EventArgs e)
        {
            h.Info("Este proyecto es de Mecanografia con el objetivo de escribir la maxima cantidad de palabras y que estas sean correctas.");
            h.Info("Ademas de contar con diferentes tematicas y desafios para hacerlo entretenido");
        }

        
        private void RDsi_CheckedChanged(object sender, EventArgs e)
        {
            if (RDsi.Checked == true)
            {
                DataTable d = DB.recuperar("USUARIOS", "USUARIO", $"NAME_PC = '{Dns.GetHostName()}'");
                if (d.Rows.Count > 0)
                {
                    CBusuario.Visible = true;
                    CBusuario.DataSource = d;
                    CBusuario.DisplayMember = "USUARIO";
                    RDno.Checked = false;
                    var JSON = JObject.Parse(contenido);
                    JSON["activado"] = "onn";
                    File.WriteAllText(auth.filePathJson, JSON.ToString());
                }
            }
        }

        private void RDno_CheckedChanged(object sender, EventArgs e)
        {
            if (RDno.Checked == true){ 
                CBusuario.Visible = false; 
                RDsi.Checked = false;
                var JSON = JObject.Parse(contenido);
                JSON["activado"] = "off";
                File.WriteAllText(auth.filePathJson, JSON.ToString());
            }
        }

        private void btnreiniciar_Click(object sender, EventArgs e)=>iniciar(1);
    }
}