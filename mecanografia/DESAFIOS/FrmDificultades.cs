using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MECANOGRAFIA.mecanografia.DESAFIOS
{
    public partial class FrmDificultades : Form
    {
        clases.auth a = new clases.auth();
        clases.helpers h = new clases.helpers();
        clases.db DB = new clases.db();
<<<<<<< HEAD
        int correctas = 0, incorrectas = 0, pcompletadas = 0,L_added = 0, L_PosM = 0, L_omitidas = 0,i,j;
        string p, p_escrita;
<<<<<<< HEAD
<<<<<<< HEAD
        mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
=======
>>>>>>> Agregar archivos de proyecto.
=======
        mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
>>>>>>> actualizacion
=======
        clases.TypeResults t = new clases.TypeResults();
>>>>>>> optimizacion de codigo en ESCRITURA se agregaron carpetas  una interface y se optimizo la arquitectura arquitectura
        public FrmDificultades()
        {
            InitializeComponent();
        }

        private void listar_palabras(int dificultad,int random = 0)
        {
            Dictionary<int, string[]> dificultades = new Dictionary<int, string[]>
            {
                { 0,new string[] { "gato", "perro", "casa", "sol", "luna", "rojo", "azul", "flor", "árbol", "hoja", "manzana", "banana", "pelota", "juego", "risa", "amigo", "feliz", "triste", "cielo", "tierra", "mar", "montaña", "camino", "río", "verde", "blanco", "negro", "nube", "viento", "nieve", "fruta", "dulce", "salado", "luz", "oscuridad", "calor", "frío", "nadar", "correr", "saltar", "bailar", "cantar", "comer", "beber", "dormir", "despertar", "leer", "escribir", "pintar", "jugar", "estudiar", "trabajar", "viajar", "ayudar", "abrazo", "beso", "familia", "amor", "paz", "alegría", "sorpresa", "miedo", "enfado", "risueño", "travieso", "inteligente", "fuerte", "rápido", "lento", "alto", "bajo", "ancho", "estrecho", "joven", "viejo", "nuevo", "viejo", "amable", "valiente", "tímido", "simpático", "gracioso", "serio", "feliz", "triste", "grande", "pequeño", "ligero", "pesado", "rico", "pobre", "limpio", "sucio", "claro", "oscuro", "bueno", "malo", "amistad", "sueño", "magia", "cuento", "jardín", "juguete", "canción", "baile", "fiesta", "cine", "teatro", "música", "arte", "poesía", "mariposa", "abeja", "elefante", "leon", "tigre", "oso", "pájaro", "pez", "caballo", "vaca", "oveja", "pollo", "cerdo", "delfín", "tortuga", "serpiente", "ratón", "lechuza", "solución", "problema", "respuesta", "pregunta", "exploración", "éxito", "fracaso", "esfuerzo", "motivación", "logro", "triunfo", "desafío", "aventura", "emoción", "sorpresa", "alegría", "tristeza", "paz", "amor", "amabilidad", "compañerismo", "amistad", "respeto", "tolerancia", "paciente", "justicia", "honestidad", "humildad", "valentía", "sabiduría", "humor", "gratitud", "optimismo", "paciencia", "compasión", "curiosidad", "admiración", "asombro","belleza", "armonía", "equilibrio", "naturaleza", "medio"," ambiente", "cuidado"} },
                { 1,new string[] { "efímero", "paradigma", "innuendo", "efervescente", "insípido", "apacible", "eficaz", "obstinado", "procrastinación", "reverberar", "quimera", "deslumbrante", "efluvio", "reminiscencia", "intransigente", "melancolía", "voraz", "anacronismo", "paradoja", "ubérrimo", "auténtico", "efusivo", "inquebrantable", "perplejo", "pernicioso", "arcano", "meticuloso", "desasosiego", "desconcertante", "lozanía", "ecuánime", "antítesis", "apoteosis", "paria", "perspicaz", "ambiguo", "convoluto", "vicisitudes", "época", "ímpetu", "osadía", "perdurable", "lúgubre", "indómito", "eflorescencia", "reverencia", "irreverente", "erudito", "efígero", "persuasivo", "voluble", "displicente", "penumbra", "ignominia", "insoslayable", "incipiente", "efervescente", "vivaz", "irrevocable", "dispuesto", "análogo", "sagaz", "osado", "magnánimo", "lúcido", "plenitud", "sutil", "eficacia", "intrínseco", "impávido", "incisivo", "cándido", "reticente", "prolijo", "discreto", "coerción", "diligente", "resiliente", "efectivo", "trascendental", "premura", "fértil", "auspicioso", "diáfano", "acucioso", "efluente", "predilecto", "magnífico", "arquetipo", "veraz", "vilipendiar", "arduo", "suntuoso", "jovial", "resonar", "obnubilar", "iridiscencia", "íntegro", "arduo", "vicisitud", "capcioso", "resiliencia", "deslindar", "vil", "sinuoso", "espléndido", "peregrino", "íntimo", "arcano", "inefable", "difuso", "intrincado", "eximio", "arrogancia", "soslayar", "precario", "sibarita", "conciso", "abnegación", "disperso", "pernicioso", "precepto", "discrepancia", "púrpura", "escueto", "plenipotenciario", "provisorio", "eflorescente", "solaz", "ósculo", "plenitud", "inmaculado", "pútrido", "ostensible", "efímero", "obnubilado", "perentorio", "conciliábulo", "exquisito", "ósculo", "ostentoso", "ánimo", "nihilismo", "efímero", "añoranza", "colosal", "perspicaz", "disímil", "ínfimo", "efluvio", "insondable", "divagación", "quimérico", "polifacético", "percatarse", "efusión", "escuálido", "elucidar", "efervescente", "cándido", "férvido", "innato", "reminiscencia", "iracundo", "vicisitud", "quijotesco", "descollante", "reverberar", "profuso", "ánima", "épico", "ínclito", "irreverente", "éxtasis", "proscrito", "fervor", "írrito", "sinsabor", "desvanecer", "lívido", "desasosiego", "ínfimo", "ánima", "epifanía", "propicio", "inquebrantable", "esotérico", "tácito", "ignominia", "reverencia", "incipiente", "effluvium", "desdén", "efímero", "proclive", "erudición", "vorágine", "ánimo", "irreverente", "difuso", "quijotesco", "efluvio", "sagacidad", "impertérrito", "innato", "sinécdoque", "exégesis", "prosaico", "parábola", "indefectible", "ferviente", "vástago", "epítome", "desasosiego", "inefable", "inmaculado", "abrumador", "iridiscencia", "lúgubre", "sibarita", "oscilar", "reverberar", "magnánimo", "épico", "voraz", "inmutable", "perspicacia", "desasosiego", "proscrito", "vilipendiar", "efímero", "escueto", "quijotesco", "ínclito", "efusión", "ínfimo", "solaz", "irreverente", "perentorio", "quimera", "límpido", "percatarse", "sagacidad", "vicisitud", "sibarita", "paradigma", "efervescente", "displicente", "efluvio", "intransigente", "auténtico", "ubérrimo", "arcano", "meticuloso", "displicente", "penumbra", "ignominia", "insoslayable", "incipiente", "efervescente", "vivaz", "irrevocable", "dispuesto", "análogo", "sagaz", "osado", "magnánimo", "lúcido", "plenitud", "sutil", "eficacia", "intrínseco", "impávido", "incisivo", "cándido", "reticente", "prolijo", "discreto", "coerción", "diligente", "resiliente", "efectivo", "trascendental", "premura", "fértil", "auspicioso", "diáfano", "acucioso", "efluente", "predilecto", "magnífico", "arquetipo", "veraz", "vilipendiar", "arduo", "suntuoso", "jovial", "resonar", "obnubilar", "iridiscencia", "íntegro", "arduo", "vicisitud", "capcioso", "resiliencia", "deslindar", "vil", "sinuoso", "espléndido", "peregrino", "íntimo", "arcano", "inefable", "difuso", "intrincado", "eximio", "arrogancia", "soslayar", "precario", "sibarita", "conciso", "abnegación", "disperso", "pernicioso", "precepto", "discrepancia", "púrpura", "escueto", "plenipotenciario", "provisorio", "eflorescente", "solaz", "ósculo", "plenitud", "inmaculado", "pútrido", "ostensible", "efímero", "obnubilado", "perentorio", "conciliábulo", "exquisito", "ósculo", "ostentoso", "ánimo", "nihilismo", "efímero", "añoranza", "colosal", "perspicaz", "disímil", "ínfimo", "efluvio", "insondable", "divagación", "quimérico", "polifacético", "percatarse", "efusión", "escuálido", "elucidar", "efervescente", "cándido", "férvido", "innato", "reminiscencia", "iracundo", "vicisitud", "quijotesco", "descollante", "reverberar", "profuso", "ánima", "épico", "ínclito", "irreverente", "éxtasis", "proscrito", "fervor", "írrito", "sinsabor", "desvanecer", "lívido", "desasosiego", "ínfimo", "ánima", "epifanía", "propicio", "inquebrantable", "esotérico", "tácito", "ignominia", "reverencia", "incipiente", "effluvium", "desdén", "efímero", "proclive", "erudición", "vorágine", "ánimo", "irreverente", "difuso", "quijotesco", "efluvio", "sagacidad", "impertérrito", "innato", "sinécdoque", "exégesis", "prosaico", "parábola", "indefectible", "ferviente", "vástago", "epítome", "desasosiego", "inefable", "inmaculado", "abrumador", "iridiscencia", "lúgubre", "sibarita", "oscilar", "reverberar", "magnánimo", "épico", "voraz", "inmutable", "perspicacia", "desasosiego", "proscrito", "vilipendiar", "efímero", "escueto", "quijotesco", "ínclito", "efusión", "ínfimo", "solaz", "irreverente", "perentorio", "quimera", "límpido", "percatarse", "sagacidad", "vicisitud", "sibarita", "paradigma", "efervescente", "displicente", "efluvio", "intransigente", "auténtico", "ubérrimo", "arcano", "meticuloso", "displicente", "penumbra", "ignominia", "insoslayable", "incipiente", "efervescente", "vivaz", "irrevocable", "dispuesto", "análogo", "sagaz", "osado", "magnánimo", "lúcido", "plenitud", "sutil", "eficacia", "intrínseco", "impávido", "incisivo", "cándido", "reticente", "prolijo", "discreto", "coerción", "diligente", "resiliente", "efectivo", "trascendental", "premura", "fértil", "auspicioso", "diáfano", "acucioso", "efluente", "predilecto", "magnífico", "arquetipo", "veraz", "vilipendiar", "arduo", "suntuoso", "jovial", "resonar", "obnubilar", "iridiscencia", "íntegro", "arduo", "vicisitud", "capcioso", "resiliencia", "deslindar", "vil", "sinuoso", "espléndido", "peregrino", "íntimo", "arcano", "inefable", "difuso", "intrincado", "eximio", "arrogancia", "soslayar", "precario", "sibarita", "conciso", "abnegación", "disperso", "pernicioso", "precepto", "discrepancia", "púrpura", "escueto", "plenipotenciario", "provisorio", "eflorescente", "solaz", "ósculo", "plenitud", "inmaculado", "pútrido", "ostensible", "efímero", "obnubilado", "perentorio", "conciliábulo", "exquisito", "ósculo", "ostentoso", "ánimo", "nihilismo", "efímero", "añoranza", "colosal", "perspicaz", "disímil", "ínfimo", "efluvio", "insondable", "divagación", "quimérico", "polifacético", "percatarse", "efusión", "escuálido", "elucidar", "efervescente", "cándido", "férvido", "innato", "reminiscencia", "iracundo", "vicisitud", "quijotesco", "descollante", "reverberar"} },
                { 2,new string[] { "aberrante", "abnegación", "absolutismo", "abstruso", "acéfalo", "acendrado", "acepción", "acerbidad", "acervo","acidulado", "acrimonia", "adefesio", "adusto", "afable", "afánico", "aféresis", "aforismo", "agrura", "ahíto",    "alabanza", "alambicado", "aleve", "alienígena", "alocución", "alucinante", "amalgama", "amnésico", "anábasis",    "anacronismo", "anatemizar", "añoranza", "apatía", "apócrifo", "áptero", "arbitrario", "aridez", "aristocracia",    "áspid", "aspaviento", "atávico", "atónito", "audacia", "aurívoro", "auscultar", "autoestima", "autótrofo",    "avaricia", "azahar", "báratro", "barroco", "beneplácito", "bermejo", "bífido", "bizarro", "boquirrubio",    "cacofonía", "cadencioso", "caliginoso", "calofrío", "cándido", "cáustico", "cedazo", "celeridad", "céfiro",    "cenit", "césped", "cetrino", "cicuta", "ciervo", "cismontano", "claudicar", "cleptómano", "coerción", "cognición",    "colecturía", "cohabitación", "colusión", "cómputo", "conculcar", "confabulación", "congruencia", "consuetudinario",    "conticinio", "copioso", "cordura", "corroborar", "cortapisa", "crasitud", "crédulo", "críptico", "cuántico",    "cuita", "cúpula", "debacle", "decantación", "deleznar", "deliberativo", "délfico", "dendrología", "denuesto",    "derrotero", "desasosiego", "desenfado", "desértico", "desgarrar", "desidia", "deslindar", "despótico", "déspota",    "destacamento", "dévico", "dicotomía", "difamación", "dilema", "disensión", "disidente", "disoluto", "disonancia",    "disparidad", "disuasorio", "eclecticismo", "ecuánime", "efluvio", "elucubrar", "embalsamar", "emoliente",    "empíreo", "enervar", "engolosinar", "enjundia", "ensalzar", "entelequia", "epístola", "epítome", "equánime",    "ergástulo", "erudición", "escatimar", "escrúpulo", "escuálido", "esdrújulo", "ese", "esfumado", "esotérico",    "espurio", "estertor", "estígma", "estridente", "etéreo", "eufonía", "exangüe", "exégesis", "exótico", "expedito",    "exquisito", "éxtasis", "extenuante", "extrínseco", "fallido", "fatídico", "febril", "fértil", "fervoroso",    "ficticio", "filántropo", "flagrante", "flebil", "fóbico", "fórum", "fosco", "frugal", "fúlgido", "fúnebre",    "fulgor", "fundamento", "fútil", "gárrulo", "gemir", "genuino", "gélido", "genuflexo", "gesticulación", "giba",    "glacial", "glaucio", "gólem", "gorgorito", "grácil", "gratitud", "grácil", "gregario", "grotesco", "grácil",    "hegemonía", "heterodoxo", "hibérnico", "hílare", "hipnagogia", "hipotético", "holganza", "homúnculo", "hórrido",   "hortensia", "hostigar", "ígneo", "ignominia", "ilación", "íleo", "íncubo", "índice", "indómito", "indulgencia",    "inédito", "inexorable", "infausto", "inhibición", "inmaculado", "innato", "ínclito", "incomensurable", "incólume",    "incurrir", "indócil", "inestable", "infamia", "infuso", "ingente", "iniciar", "inmaculado", "innato", "ínclito",    "inmolación", "inocuo", "inopinado", "inoscencia", "inquisitivo", "insensato", "insondable", "insulso", "intangible",    "íntegro", "intemperante", "ínterin", "intuitivo", "inusitado", "invasivo", "invidente", "invulnerable", "júbilo",    "jácena", "jarife", "jerga", "jeroglífico", "jirafa", "jovial", "júbilo", "judaico", "juliano", "juntar", "júpiter",    "jurar", "juvenil", "laberinto", "lacerante", "lábil", "lánguido", "lapidar", "laúd", "lealtad", "leitmotiv",    "lenitivo", "leucocito", "levirato", "libélula", "ligero", "límpido", "linfa", "liturgia", "llama", "lozanía",    "lucidez", "lúgubre", "luminiscencia", "lúpulo", "macabro", "macerar", "magnánimo", "mácula", "madriguera", "majestuoso",    "malévolo", "maligno", "mármol", "masticar", "mazmorra", "médula", "melancolía", "mellifluo", "memorándum",    "menester", "mentón", "meritorio", "meticuloso", "mezquino", "miasma", "miedo", "milenario", "minucioso", "miope",    "miríada", "místico", "mofeta", "monótono", "moribundo", "moroso", "motete", "mover", "múdulo", "multifacético",    "mundano", "musitar", "mútilo", "nabateo", "nacarado", "naíf", "narcótico", "nefando", "nemesis", "neófito", "neptuniano",    "nervadura", "neurona", "nihilismo", "nimbo", "niñez", "nocivo", "noético", "nómada", "nonato", "notorio", "nubilidad",    "nudoso", "nulidad", "números", "nutrición", "obispo", "oblicuo", "obnubilar", "obsequio", "ocaso", "ocioso", "octógono",    "óctuple", "ocurrencia", "óleo", "olfato", "ominoso", "ómnibus", "ónix", "onomástico", "oprobio", "óptico", "orbe",    "órdago", "órgano", "originario", "ornitorrinco", "ortodoxo", "ósculo", "oscuridad", "ostentar", "otorgar", "óvulo",    "oxímoron", "óyeme", "óxido", "pacífico", "pálido", "panteón", "papiro", "pausado", "pavoroso", "péndulo", "penumbra",    "pérfido", "perla", "pértiga", "pétrea", "pezón", "piadoso", "piélago", "pieza", "piroclasto", "pírrico", "plácido",    "plañir", "plástico", "plebeyo", "pócima", "podenco", "poético", "pólder", "polifacético", "pómez", "póntico",    "porífero", "portento", "posesión", "postulado", "póster", "potente", "pradera", "precario", "predicar", "preludio",    "prender", "presagio", "préstamo", "primicia", "prioridad", "pródigo", "proeza", "profano", "progenie", "pródigo",    "prontuario", "prosaico", "protoplasma", "prurito", "púdico", "púgil", "pulcritud", "púlpito", "púlsar", "púrpura",    "pusilánime", "putrefacto", "puzle", "quásar", "quimera", "quirlar", "quiste", "quórum", "radiancia", "rancio",    "rapaz", "rápido", "rásgalo", "récord", "redimir", "reducir", "refulgente", "reiterar", "rejuvenecer", "reliquia",    "remanente", "remontar", "renacimiento", "reñir", "repleto", "reptar", "repugnante", "resarcir", "resiliencia",    "resoluto", "reticencia", "revelar", "revolcar", "revulsivo", "rizoma", "robusto", "rubicundo", "rudimento", "ruisenor",    "ruptura", "rutilante", "sabiduría", "sádico", "salubridad", "sánscrito", "sarcástico", "sátrapa", "saturado", "secuaz",    "sedentario", "seducir", "seísmo", "selvático", "semántica", "sensualidad", "separar", "sepulcro", "séquito",    "serenidad", "servicial", "sesgado", "sesquipedal", "seta", "sevicia", "sexenio", "sibilante", "sicario", "significar",    "silente", "símil", "simplificar", "simultáneo", "sinfonía", "singular", "sintonía", "sirviente", "sismógrafo",    "soberbio", "socavar", "sofocante", "solar", "sólido", "someter", "sonámbulo", "sosegado", "sostén", "suavizar",    "sublime", "súbito", "subyacente", "sudario", "suelto", "sufragar", "sujeto", "sultán", "sumergir", "superficie",    "súplica", "suprimir", "surdido", "susurro", "sutileza", "tácito", "tafonomía", "tahúr", "talante", "tamaño", "tándem",    "tangente", "tarántula", "teólogo", "tez", "tibio", "tidal", "tiempo", "timorato", "tintineo", "tirante", "titánico",    "tocayo", "tómbola", "tópico", "torpeza", "tragedia", "transcurrir", "trascender", "trecho", "tríada", "tribulación",    "trifulca", "trillar", "tripulación", "trópico", "truculento", "tufo", "tumba", "turbio", "turulato", "ubérrimo","ubicuo", "ulterior", "último", "ululante", "umbrío", "úmbrico", "umbral", "único", "untar", "usurpar", "útero",    "vacuidad", "vaho", "valentía", "várice", "varonil", "paragutirimicuaro","esternoclesdomastoideo","desoxirribonucleico"} }

            };

            if (dificultades.TryGetValue(dificultad, out string[] palabras))
            {
                if (random > 0)
                {
                    Random randomwords = new Random();
                    for (t.i = palabras.Length - 1; t.i > 0; t.i--)
                    {
                        t.j = randomwords.Next(0, t.i + 1);
                        string temp = palabras[t.i];
                        palabras[t.i] = palabras[t.j];
                        palabras[t.j] = temp;
                    }
                }

                txtpalabrasmostradas.Text = string.Join(" ", palabras);
            }
        }

        private void txtpalabrasescritas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = h.Onlystrings(e) ? false : true;
        }

        private void cargarfrm()
        {
            txtpalabrasescritas.Enabled = false;
            this.Text = "Dificultad " + a.usuario_sesion;
            btnreiniciar.Enabled = false;
            CMBFalsaDificultad.Visible = false;
        }

        private void FrmTematicas_Load(object sender, EventArgs e)
        {
            cargarfrm();
        }

        private void CMBdificultades_SelectedIndexChanged(object sender, EventArgs e)
        {
            listar_palabras(CMBdificultades.SelectedIndex,0);
        }

        private void RELOJ_Tick(object sender, EventArgs e)
        {
            int conteo = Convert.ToInt32(lblSEGUNDOS.Text);
            conteo--;
            lblSEGUNDOS.Text = conteo.ToString();

            if (t.correctas == 20 && t.incorrectas == 0 && CMBdificultades.Text == "facil"){
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(1, 0);
                RELOJ.Start();
                listar_palabras(1, 1);
            }
            else if (t.correctas == 20 && t.incorrectas > 5 && t.incorrectas <= 10 && CMBdificultades.Text == "intermedio"
                || t.correctas == 20 && t.incorrectas > 5 && t.incorrectas <= 10 && CMBdificultades.Text == "dificil")
            {
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(0, 0);
                RELOJ.Start();
                listar_palabras(0, 1);
            }
            else if (t.correctas == 40 && t.incorrectas == 0 && CMBdificultades.Text == "facil"
                || t.correctas == 40 && t.incorrectas == 0 && CMBdificultades.Text == "intermedio")
            {
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(2, 0);
                RELOJ.Start();
                listar_palabras(2, 1);
            }
            else if (t.correctas == 40 && t.incorrectas > 1 && t.incorrectas <= 3 && CMBdificultades.Text == "dificil")
            {
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(0, 0);
                RELOJ.Start();
                listar_palabras(0, 1);
            }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
            if (conteo == 45 && pcompletadas == 0){
                RELOJ.Stop();
                h.Info("Te encuentras lejos del teclado?");
=======
            if (conteo == 0){
                CMBFalsaDificultad.Visible = false;
                RELOJ.Stop();
                MessageBox.Show("!Se ha agotado el tiempo!");

                ListViewItem item = item = lvPalabras.Items.Add(pcompletadas.ToString());
                item.SubItems.Add(correctas.ToString());
                item.SubItems.Add(incorrectas.ToString());
                item.SubItems.Add(Math.Round(((float)correctas / pcompletadas) * 100, 3).ToString() + "%");
                item.SubItems.Add(L_omitidas.ToString());
                item.SubItems.Add(L_PosM.ToString());
                item.SubItems.Add(L_added.ToString());

>>>>>>> Agregar archivos de proyecto.
=======
            if (conteo == 45 && pcompletadas == 0){
=======
            if (conteo == 45 && t.pcompletadas == 0){
>>>>>>> optimizacion de codigo en ESCRITURA se agregaron carpetas  una interface y se optimizo la arquitectura arquitectura
                RELOJ.Stop();
                h.Info("Te encuentras lejos del teclado?");
>>>>>>> actualizacion
                txtpalabrasescritas.Clear();
                lblSEGUNDOS.Text = "60";
                btnIniciar.Enabled = false;
                btnreiniciar.Enabled = true;
                txtpalabrasescritas.Enabled = false;
                CMBdificultades.Enabled = true;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> actualizacion
            }else if (incorrectas >= 10){
=======
            }else if (t.incorrectas >= 10){
>>>>>>> optimizacion de codigo en ESCRITURA se agregaron carpetas  una interface y se optimizo la arquitectura arquitectura
                RELOJ.Stop();
                h.Warning("!Demasiadas palabras t.incorrectas!");
                txtpalabrasescritas.Clear();
                lblSEGUNDOS.Text = "60";
                btnreiniciar.Enabled = true;
                txtpalabrasescritas.Enabled = false;
                CMBdificultades.Enabled = true;
            }else{
                if (conteo == 0){
                    CMBFalsaDificultad.Visible = false;
                    RELOJ.Stop();
                    MessageBox.Show("!Se ha agotado el tiempo!");

                    ListViewItem item = item = lvPalabras.Items.Add(t.pcompletadas.ToString());
                    item.SubItems.Add(t.correctas.ToString());
                    item.SubItems.Add(t.incorrectas.ToString());
                    item.SubItems.Add(Math.Round(((float)t.correctas / t.pcompletadas) * 100, 3).ToString() + "%");
                    item.SubItems.Add(t.L_omitidas.ToString());
                    item.SubItems.Add(t.L_PosM.ToString());
                    item.SubItems.Add(t.L_added.ToString());

                    txtpalabrasescritas.Clear();
                    lblSEGUNDOS.Text = "60";
                    btnIniciar.Enabled = false;
                    btnreiniciar.Enabled = true;
                    txtpalabrasescritas.Enabled = false;
                    CMBdificultades.Enabled = true;

                    foreach (ListViewItem datosLV in lvPalabras.Items){
                        t.ppm = datosLV.SubItems[0].Text;
                        t.pc = datosLV.SubItems[1].Text;
                        t.pi = datosLV.SubItems[2].Text;
                        t.Lomitida = datosLV.SubItems[4].Text;
                        t.LPosM = datosLV.SubItems[5].Text;
                        t.LAddedM = datosLV.SubItems[6].Text;
                    }
<<<<<<< HEAD

                    if (a.usuario_sesion != string.Empty){
                        if (CMBdificultades.Text == "facil") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{a.usuario_sesion}','FACIL','{t.ppm}','{t.pc}','{t.pi}','{Convert.ToDouble(Math.Round(((float)t.correctas / t.pcompletadas) * 100, 3)) + "%"}','{t.Lomitida}','{t.LPosM}','{t.LAddedM}'");
                        else if (CMBdificultades.Text == "intermedio") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{a.usuario_sesion}','INTERMEDIO','{t.ppm}','{t.pc}','{t.pi}','{Convert.ToDouble(Math.Round(((float)t.correctas / t.pcompletadas) * 100, 3)) + "%"}','{t.Lomitida}','{t.LPosM}','{t.LAddedM}'");
                        else if (CMBdificultades.Text == "dificil") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{a.usuario_sesion}','DIFICIL','{t.ppm}','{t.pc}','{t.pi}','{Convert.ToDouble(Math.Round(((float)t.correctas / t.pcompletadas) * 100, 3)) + "%"}','{t.Lomitida}','{t.LPosM}','{t.LAddedM}'");
                    }
=======
=======
>>>>>>> actualizacion

                    esc = ((mecanografia.ESCRITURA)Owner);
                    if (esc.usuario_sesion != ""){
                        if (CMBdificultades.Text == "facil") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{esc.usuario_sesion}','FACIL','{ppm}','{pc}','{pi}','{Convert.ToDouble(Math.Round(((float)correctas / pcompletadas) * 100, 3)) + "%"}','{Lomitida}','{LPosM}','{LAddedM}'");
                        else if (CMBdificultades.Text == "intermedio") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{esc.usuario_sesion}','INTERMEDIO','{ppm}','{pc}','{pi}','{Convert.ToDouble(Math.Round(((float)correctas / pcompletadas) * 100, 3)) + "%"}','{Lomitida}','{LPosM}','{LAddedM}'");
                        else if (CMBdificultades.Text == "dificil") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{esc.usuario_sesion}','DIFICIL','{ppm}','{pc}','{pi}','{Convert.ToDouble(Math.Round(((float)correctas / pcompletadas) * 100, 3)) + "%"}','{Lomitida}','{LPosM}','{LAddedM}'");
                    }
<<<<<<< HEAD
                    else if (CMBdificultades.Text == "dificil")
                    {
                        DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{esc.usuario_sesion}','DIFICIL','{ppm}','{pc}','{pi}','{Convert.ToDouble(Math.Round(((float)correctas / pcompletadas) * 100, 3)) + "%"}','{Lomitida}','{LPosM}','{LAddedM}'");
                    } 
>>>>>>> Agregar archivos de proyecto.
=======
>>>>>>> actualizacion
                }
            }
        }

        private void BTNsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtpalabrasescritas_KeyDown(object sender, KeyEventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            if (e.KeyCode == Keys.Space ){
=======
            if (e.KeyCode == Keys.Space )
            {
>>>>>>> Agregar archivos de proyecto.
=======
            if (e.KeyCode == Keys.Space ){
<<<<<<< HEAD
>>>>>>> actualizacion
                WrongLetterPosition();
                SkippedLetters();
                LetterAddedWrongly();
                verificar_palabras();
=======
                t.WrongLetterPosition(1);
                t.SkippedLetters(1);
                t.LetterAddedWrongly(1);
                t.Verificar_palabras(1);
>>>>>>> optimizacion de codigo en ESCRITURA se agregaron carpetas  una interface y se optimizo la arquitectura arquitectura
                txtpalabrasescritas.Clear();
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (CMBdificultades.Text.Length != 0) {
                btnIniciar.Enabled = false;
                btnreiniciar.Enabled = false;
                txtpalabrasescritas.Enabled = true;
                txtpalabrasescritas.Focus();
                RELOJ.Start();
                txtpalabrasescritas.Clear();
                t.correctas = 0;t.incorrectas = 0;t.pcompletadas = 0;t.L_omitidas = 0; t.L_PosM = 0; t.L_added = 0;
                lvPalabras.Items.Clear();
                CMBdificultades.Enabled = false;
<<<<<<< HEAD
<<<<<<< HEAD
            }else h.Warning("Seleccione una dificultad");
=======
            }
            else
            {
                h.Warning("Seleccione una dificultad");
            }
>>>>>>> Agregar archivos de proyecto.
=======
            }else h.Warning("Seleccione una dificultad");
>>>>>>> actualizacion
        }

        private void btnreiniciar_Click(object sender, EventArgs e)
        {
            lblSEGUNDOS.Text = "60";
            btnreiniciar.Enabled = false;
            txtpalabrasescritas.Enabled = true;
            txtpalabrasescritas.Focus();
            RELOJ.Start();
            txtpalabrasescritas.Clear();
            t.correctas = 0;t.incorrectas = 0; t.pcompletadas = 0; t.L_omitidas = 0; t.L_PosM = 0; t.L_added = 0;
            listar_palabras(CMBdificultades.SelectedIndex, 0);
            CMBdificultades.Enabled = false;
        }
    }
}
