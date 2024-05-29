namespace MECANOGRAFIA.mecanografia.PALABRAS_MAL_ESCRITAS
{
    partial class FrmP_M_E
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVdatos = new System.Windows.Forms.DataGridView();
            this.CLPI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLFECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTPfecha = new System.Windows.Forms.DateTimePicker();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVdatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVdatos
            // 
            this.DGVdatos.AllowUserToAddRows = false;
            this.DGVdatos.AllowUserToDeleteRows = false;
            this.DGVdatos.AllowUserToResizeColumns = false;
            this.DGVdatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVdatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVdatos.BackgroundColor = System.Drawing.Color.NavajoWhite;
            this.DGVdatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGVdatos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DGVdatos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.GhostWhite;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVdatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVdatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVdatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLPI,
            this.CLFECHA});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVdatos.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGVdatos.EnableHeadersVisualStyles = false;
            this.DGVdatos.GridColor = System.Drawing.Color.NavajoWhite;
            this.DGVdatos.Location = new System.Drawing.Point(2, 2);
            this.DGVdatos.Name = "DGVdatos";
            this.DGVdatos.ReadOnly = true;
            this.DGVdatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DGVdatos.RowHeadersVisible = false;
            this.DGVdatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DGVdatos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DGVdatos.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Brown;
            this.DGVdatos.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DGVdatos.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Lavender;
            this.DGVdatos.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.DGVdatos.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DGVdatos.RowTemplate.ReadOnly = true;
            this.DGVdatos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVdatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGVdatos.Size = new System.Drawing.Size(863, 382);
            this.DGVdatos.TabIndex = 16;
            // 
            // CLPI
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLPI.DefaultCellStyle = dataGridViewCellStyle3;
            this.CLPI.HeaderText = "PALABRAS INCORRECTAS";
            this.CLPI.Name = "CLPI";
            this.CLPI.ReadOnly = true;
            this.CLPI.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CLPI.Width = 700;
            // 
            // CLFECHA
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLFECHA.DefaultCellStyle = dataGridViewCellStyle4;
            this.CLFECHA.HeaderText = "FECHA DE JUEGO";
            this.CLFECHA.Name = "CLFECHA";
            this.CLFECHA.ReadOnly = true;
            this.CLFECHA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CLFECHA.Width = 159;
            // 
            // DTPfecha
            // 
            this.DTPfecha.CustomFormat = "YYYY-MM-DD";
            this.DTPfecha.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DTPfecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPfecha.Location = new System.Drawing.Point(6, 27);
            this.DTPfecha.MaxDate = new System.DateTime(2050, 1, 1, 0, 0, 0, 0);
            this.DTPfecha.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.DTPfecha.Name = "DTPfecha";
            this.DTPfecha.Size = new System.Drawing.Size(114, 27);
            this.DTPfecha.TabIndex = 17;
            this.DTPfecha.Value = new System.DateTime(2024, 2, 7, 0, 0, 0, 0);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.Location = new System.Drawing.Point(126, 25);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(94, 29);
            this.btnbuscar.TabIndex = 19;
            this.btnbuscar.Text = "BUSCAR";
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DTPfecha);
            this.groupBox1.Controls.Add(this.btnbuscar);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(290, 386);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 66);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECCIONAR FECHA:";
            // 
            // FrmP_M_E
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(870, 457);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DGVdatos);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmP_M_E";
            this.ShowIcon = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmP_M_E_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVdatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVdatos;
        private System.Windows.Forms.DateTimePicker DTPfecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLPI;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLFECHA;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}