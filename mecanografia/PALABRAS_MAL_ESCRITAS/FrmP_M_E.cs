using MECANOGRAFIA.clases;
using System;
using System.Data;
using System.Windows.Forms;

namespace MECANOGRAFIA.mecanografia.PALABRAS_MAL_ESCRITAS
{
    public partial class FrmP_M_E : Form
    {
        clases.db DB = new clases.db();
        clases.helpers h = new clases.helpers();
        clases.auth a = new clases.auth();
        public FrmP_M_E()
        {
            InitializeComponent();
        }

        private void cargardatos()
        {
            DataTable d = DB.recuperar("LISTA_P_M_E", "P_MAL_E,FECHA", $"USUARIO = '{auth.usuario_sesion}' AND FECHA = '{DTPfecha.Value.ToShortDateString()}'");
            string p,fec;
            if (d.Rows.Count > 0) {
                DGVdatos.Rows.Clear();
                foreach (DataRow r in d.Rows) {
                    p = r["P_MAL_E"].ToString();
                    fec = Convert.ToDateTime(r["FECHA"]).ToShortDateString();
                    DGVdatos.Rows.Add(p, fec);
                }
            } else h.Succes(auth.usuario_sesion + " No cuenta con registros la fecha de: " + DTPfecha.Text);
        }

        private void FrmP_M_E_Load(object sender, EventArgs e)
        {
            if (auth.usuario_sesion != string.Empty) {

                DataTable d = DB.recuperar("LISTA_P_M_E", "P_MAL_E,FECHA", $"USUARIO = '{auth.usuario_sesion}' AND FECHA = '{DTPfecha.Value.ToShortDateString()}'");
                if (d.Rows.Count == 0) { h.Succes("No cuneta con registros"); this.Close(); }
                else { this.Text = "LISTADO DE PALABRAS MAL ESCRITAS - USUARIO: " + auth.usuario_sesion; cargardatos();}
            }else { h.Info("Debe Inicar sesion o registrarse");  this.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargardatos();
        }
    }
}
