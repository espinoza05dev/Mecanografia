using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MECANOGRAFIA.mecanografia.RECORS_USUARIOS
{
    public partial class FrmRecordsPersonalizado : Form
    {
        clases.helpers h = new clases.helpers();
        clases.db DB = new clases.db();
<<<<<<< HEAD
<<<<<<< HEAD
        string query, condicion;
=======
>>>>>>> Agregar archivos de proyecto.
=======
        string query, condicion;
>>>>>>> actualizacion
        public FrmRecordsPersonalizado()
        {
            InitializeComponent();
        }

        private void btnicio_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> actualizacion
            mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
            this.AddOwnedForm(esc);
            this.Close();
            esc.Show();
        }

        private void listar_datos()
        {
            mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
            esc = ((mecanografia.ESCRITURA)Owner);
            query = "SELECT * FROM RECORDS_PERSONALIZADO RP INNER JOIN R_RECORDS_PERSONALIZADO R ON (RP.ID = R.ID) ";
            condicion = $"WHERE RP.NFILE = '{CMBpersonalizado.Text}' AND RP.USUARIO = '{esc.usuario_sesion}'";
<<<<<<< HEAD
=======
            this.Close();
        }

        private void listar_datos()
        {
            mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
            esc = ((mecanografia.ESCRITURA)Owner);
>>>>>>> Agregar archivos de proyecto.
=======
>>>>>>> actualizacion
            string prec;
            int ppm, c, i,Lo,LposM,Ladded;
            DateTime fecha;

<<<<<<< HEAD
<<<<<<< HEAD
            if (esc.usuario_sesion != string.Empty) {
                DataTable datos = DB.consulta(query + condicion);
                DataTable d = DB.recuperar("RECORDS_PERSONALIZADO", "*", $"NFILE = '{CMBpersonalizado.Text}' AND USUARIO = '{esc.usuario_sesion}'");
                DGVdatos.Rows.Clear();
                if (datos.Rows.Count > 0){
                    foreach (DataRow r in datos.Rows){
=======
            if (esc.usuario_sesion != "") {
                DataTable datos = DB.recuperar("RECORDS_PERSONALIZADO", "*", $"NFILE = '{nfile}' AND USUARIO = '{esc.usuario_sesion}'");
                if (datos.Rows.Count > 0)
                {
                    foreach (DataRow r in datos.Rows)
                    {
>>>>>>> Agregar archivos de proyecto.
=======
            if (esc.usuario_sesion != string.Empty) {
                DataTable datos = DB.consulta(query + condicion);
                DataTable d = DB.recuperar("RECORDS_PERSONALIZADO", "*", $"NFILE = '{CMBpersonalizado.Text}' AND USUARIO = '{esc.usuario_sesion}'");
                DGVdatos.Rows.Clear();
                if (datos.Rows.Count > 0){
                    foreach (DataRow r in datos.Rows){
>>>>>>> prueba
                        ppm = Convert.ToInt32(r["PPM"]);
                        c = Convert.ToInt32(r["C"]);
                        i = Convert.ToInt32(r["I"]);
                        prec = r["PREC"].ToString();
                        Lo = Convert.ToInt32(r["L_O"]);
                        LposM = Convert.ToInt32(r["L_POS_M"]);
                        Ladded = Convert.ToInt32(r["L_ADDED"]);
                        fecha = Convert.ToDateTime(r["FECHA"]);
                        DGVdatos.Rows.Add(ppm, c, i, prec, Lo, LposM, Ladded, fecha);
                    }
                    datos.Dispose();
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> actualizacion
                }DGVdatos.Rows.Clear();
                if (d.Rows.Count > 0){
                    foreach (DataRow r in d.Rows){
                        ppm = Convert.ToInt32(r["PPM"]);
                        c = Convert.ToInt32(r["C"]);
                        i = Convert.ToInt32(r["I"]);
                        prec = r["PREC"].ToString();
                        Lo = Convert.ToInt32(r["L_O"]);
                        LposM = Convert.ToInt32(r["L_POS_M"]);
                        Ladded = Convert.ToInt32(r["L_ADDED"]);
                        fecha = Convert.ToDateTime(r["FECHA"]);
                        DGVdatos.Rows.Add(ppm, c, i, prec, Lo, LposM, Ladded, fecha);
                    }
                    d.Dispose();
                }
<<<<<<< HEAD
            }
        }
        private void cargarcmb()
        {
            mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
            esc = ((mecanografia.ESCRITURA)Owner);
            DataTable d1 = DB.recuperar("R_RECORDS_PERSONALIZADO", "*", $"USUARIO = '{esc.usuario_sesion}'");
            if (d1.Rows.Count > 0) {
                CMBpersonalizado.DataSource = d1;
                CMBpersonalizado.DisplayMember = "R_NFILE";
            }else if (d1.Rows.Count == 0){
                CMBpersonalizado.DataSource = DB.recuperar("RECORDS_PERSONALIZADO", "NFILE",$"USUARIO = '{esc.usuario_sesion}'");
                CMBpersonalizado.DisplayMember = "NFILE";
=======
                } else h.Warning($"El usuuario {esc.usuario_sesion} no cuenta con registros"); 
>>>>>>> Agregar archivos de proyecto.
=======
                } else h.Warning($"El usuario {esc.usuario_sesion} no cuenta con registros"); 
>>>>>>> prueba
=======
>>>>>>> actualizacion
            }
        }
        private void cargarcmb()
        {
            mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
            esc = ((mecanografia.ESCRITURA)Owner);
            DataTable d1 = DB.recuperar("R_RECORDS_PERSONALIZADO", "*", $"USUARIO = '{esc.usuario_sesion}'");
            if (d1.Rows.Count > 0) {
                CMBpersonalizado.DataSource = d1;
                CMBpersonalizado.DisplayMember = "R_NFILE";
            }else if (d1.Rows.Count == 0){
                CMBpersonalizado.DataSource = DB.recuperar("RECORDS_PERSONALIZADO", "NFILE",$"USUARIO = '{esc.usuario_sesion}'");
                CMBpersonalizado.DisplayMember = "NFILE";
            }
        }

        private void FrmRecordsPersonalizado_Load(object sender, EventArgs e)
        {
            mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
            esc = ((mecanografia.ESCRITURA)Owner);
<<<<<<< HEAD
<<<<<<< HEAD
            DataTable d = DB.recuperar("RECORDS_PERSONALIZADO", "*");
            if (d.Rows.Count == 0){ h.Warning($"El usuario {esc.usuario_sesion} no cuenta con registros"); this.Close(); }
            this.Text = " Records Personalizado: " + esc.usuario_sesion;
            cargarcmb();
        }

        private void CMBpersonalizado_SelectedIndexChanged(object sender, EventArgs e)
        {
            listar_datos();
=======
=======
            DataTable d = DB.recuperar("RECORDS_PERSONALIZADO", "*");
            if (d.Rows.Count == 0){ h.Warning($"El usuario {esc.usuario_sesion} no cuenta con registros"); this.Close(); }
>>>>>>> actualizacion
            this.Text = " Records Personalizado: " + esc.usuario_sesion;
            cargarcmb();
        }

        private void CMBpersonalizado_SelectedIndexChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
            listar_datos(CMBpersonalizado.Text);
>>>>>>> Agregar archivos de proyecto.
=======
            listar_datos();
>>>>>>> prueba
        }
    }
}
