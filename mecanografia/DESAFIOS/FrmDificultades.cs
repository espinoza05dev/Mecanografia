using MECANOGRAFIA.clases.AUTH;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MECANOGRAFIA.mecanografia.DESAFIOS
{
    public partial class FrmDificultades : Form
    {
        clases.helpers h = new clases.helpers();
        clases.db DB = new clases.db();
        clases.TypeResults t = new clases.TypeResults();
        mecanografia.ESCRITURA E;
        int correctas, incorrectas, pcompletadas, L_omitidas, L_PosM, L_added, i, j;
        string palabra_mostrada, palabra_escrita;
        string[] TextTyped, textshowed;
        List<string> palabras, palabras_escritas;
        
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
                    for (i = palabras.Length - 1; i > 0; i--)
                    {
                        j = randomwords.Next(0, i + 1);
                        string temp = palabras[i];
                        palabras[i] = palabras[j];
                        palabras[j] = temp;
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
            E = new mecanografia.ESCRITURA();
            txtpalabrasescritas.Enabled = false;
            this.Text = "Dificultad: " + SesionManager.usuario_sesion;
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

            if (correctas == 20 && incorrectas == 0 && CMBdificultades.Text == "facil"){
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(1, 0);
                RELOJ.Start();
                listar_palabras(1, 1);
            }
            else if (correctas == 20 && incorrectas > 5 && incorrectas <= 10 && CMBdificultades.Text == "intermedio"
                || correctas == 20 && incorrectas > 5 && incorrectas <= 10 && CMBdificultades.Text == "dificil")
            {
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(0, 0);
                RELOJ.Start();
                listar_palabras(0, 1);
            }
            else if (correctas == 40 && incorrectas == 0 && CMBdificultades.Text == "facil"
                || correctas == 40 && incorrectas == 0 && CMBdificultades.Text == "intermedio")
            {
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(2, 0);
                RELOJ.Start();
                listar_palabras(2, 1);
            }
            else if (correctas == 40 && incorrectas > 1 && incorrectas <= 3 && CMBdificultades.Text == "dificil")
            {
                RELOJ.Stop();
                CMBFalsaDificultad.Visible = true;
                CMBFalsaDificultad.Text = CMBdificultades.Text;
                listar_palabras(0, 0);
                RELOJ.Start();
                listar_palabras(0, 1);
            }

            if (conteo == 45 && pcompletadas == 0){
                RELOJ.Stop();
                h.Info("Te encuentras lejos del teclado?");
                txtpalabrasescritas.Clear();
                lblSEGUNDOS.Text = "60";
                btnIniciar.Enabled = false;
                btnreiniciar.Enabled = true;
                txtpalabrasescritas.Enabled = false;
                CMBdificultades.Enabled = true;
            }else if (incorrectas >= 10){
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

                    double porcentaje = Convert.ToDouble(Math.Round(((double)correctas / pcompletadas) * 100, 3));
                    string ShowPorcentaje = porcentaje.ToString() + "%";

                    ListViewItem item = item = lvPalabras.Items.Add(pcompletadas.ToString());
                    item.SubItems.Add(correctas.ToString());
                    item.SubItems.Add(incorrectas.ToString());
                    item.SubItems.Add(ShowPorcentaje);
                    item.SubItems.Add(L_omitidas.ToString());
                    item.SubItems.Add(L_PosM.ToString());
                    item.SubItems.Add(L_added.ToString());

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

                    if (SesionManager.usuario_sesion!= string.Empty){
                        if (CMBdificultades.Text == "facil") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{SesionManager.usuario_sesion}','FACIL','{t.ppm}','{t.pc}','{t.pi}','{ShowPorcentaje}','{t.Lomitida}','{t.LPosM}','{t.LAddedM}'");
                        else if (CMBdificultades.Text == "intermedio") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{SesionManager.usuario_sesion}','INTERMEDIO','{t.ppm}','{t.pc}','{t.pi}','{ShowPorcentaje}','{t.Lomitida}','{t.LPosM}','{t.LAddedM}'");
                        else if (CMBdificultades.Text == "dificil") DB.guardar("RECORDS_DIFICULTADES", "USUARIO,DIFICULTAD,PPM,C,I,PRECISION,L_O,L_POS_M,L_ADDED_M", $"'{SesionManager.usuario_sesion}','DIFICIL','{t.ppm}','{t.pc}','{t.pi}','{ShowPorcentaje}','{t.Lomitida}','{t.LPosM}','{t.LAddedM}'");
                    }
                }
            }
        }

        private void BTNsalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
            if (e.KeyCode == Keys.Space ){
                WrongLetterPosition();
                SkippedLetters();
                LetterAddedWrongly();
                Verificar_palabras();
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
                correctas = 0;incorrectas = 0;pcompletadas = 0;L_omitidas = 0; L_PosM = 0; L_added = 0;
                lvPalabras.Items.Clear();
                CMBdificultades.Enabled = false;
            }else h.Warning("Seleccione una dificultad");
        }

        private void btnreiniciar_Click(object sender, EventArgs e)
        {
            lblSEGUNDOS.Text = "60";
            btnreiniciar.Enabled = false;
            txtpalabrasescritas.Enabled = true;
            txtpalabrasescritas.Focus();
            RELOJ.Start();
            txtpalabrasescritas.Clear();
            correctas = 0;incorrectas = 0; pcompletadas = 0; L_omitidas = 0; L_PosM = 0; L_added = 0;
            listar_palabras(CMBdificultades.SelectedIndex, 0);
            CMBdificultades.Enabled = false;
        }
    }
}
