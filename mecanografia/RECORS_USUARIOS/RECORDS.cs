﻿using System;
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
    public partial class RECORDS : Form
    {
        clases.db DB = new clases.db();
<<<<<<< HEAD
<<<<<<< HEAD
        clases.helpers h = new clases.helpers();
=======
>>>>>>> Agregar archivos de proyecto.
=======
        clases.helpers h = new clases.helpers();
>>>>>>> actualizacion
        
        public RECORDS()
        {
            InitializeComponent();
        }

        private void btnicio_Click(object sender, EventArgs e)
        {
            mecanografia.ESCRITURA esc = new ESCRITURA();
            this.AddOwnedForm(esc);
            this.Dispose();
        }

        private void cargardatosLV(string usuario)
        {
            DataTable datos = DB.recuperar("RECORDS_USUARIOS", "*", $"USUARIO = '{usuario}'");
            string ppm, pc, pi,LO, LPOS, LA,prec; 
            DateTime fec;
            DGVdatos.Rows.Clear();
<<<<<<< HEAD
<<<<<<< HEAD
            if (datos.Rows.Count > 0)
            {
=======
            if (datos.Rows.Count > 0) {
>>>>>>> Agregar archivos de proyecto.
=======
            if (datos.Rows.Count > 0)
            {
>>>>>>> actualizacion
                foreach (DataRow r in datos.Rows)
                {
                    ppm = r["PALABRAS_POR_MINUTO"].ToString();
                    pc = r["PALABRAS_CORRECTAS"].ToString();
                    pi = r["PALABRAS_INCORRECTAS"].ToString();
                    fec = Convert.ToDateTime(r["FECHA"].ToString());
                    prec = r["PRECISION"].ToString();
                    LO = r["L_O"].ToString();
                    LPOS = r["L_POS_M"].ToString();
                    LA = r["L_ADDED_M"].ToString();

<<<<<<< HEAD
<<<<<<< HEAD
                    DGVdatos.Rows.Add(ppm, pc, pi, prec, LO, LPOS, LA, fec);
=======
                    DGVdatos.Rows.Add(ppm, pc, pi,prec,LO,LPOS,LA, fec);
>>>>>>> Agregar archivos de proyecto.
=======
                    DGVdatos.Rows.Add(ppm, pc, pi, prec, LO, LPOS, LA, fec);
>>>>>>> actualizacion
                }
                datos.Dispose();
            }
        }

        private void RECORDS_Load(object sender, EventArgs e)
        {
            mecanografia.ESCRITURA esc = new mecanografia.ESCRITURA();
            esc = ((mecanografia.ESCRITURA)Owner);
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> actualizacion
            if (esc.usuario_sesion != string.Empty){
                this.Text = "RECORDS: " + esc.usuario_sesion;
                cargardatosLV(esc.usuario_sesion);
            }else { h.Warning("Incie sesión para ver sus registro"); this.Dispose(); }
<<<<<<< HEAD
=======
            this.Text = "RECORDS: "+ esc.usuario_sesion;
            cargardatosLV(esc.usuario_sesion);
>>>>>>> Agregar archivos de proyecto.
=======
>>>>>>> actualizacion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (P_OFF.BackColor == Color.Red)
            {
                P_ON.BackColor = Color.Green;
                P_OFF.BackColor = Color.Gray;

                btnicio.BackColor = Color.Black;
                btnicio.ForeColor = Color.White;

                button1.BackColor = Color.Black;
                button1.ForeColor = Color.White;

                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
            }
            else if (P_ON.BackColor == Color.Green)
            {
                P_ON.BackColor = Color.Gray;
                P_OFF.BackColor = Color.Red;
                
                btnicio.BackColor = Color.CadetBlue;
                btnicio.ForeColor = Color.Black;

                button1.BackColor = Color.White;
                button1.ForeColor = Color.Black;

                this.BackColor = Color.CadetBlue;
                this.ForeColor = Color.Black;
            }
        }
    }
}
