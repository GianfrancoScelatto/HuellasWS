namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    partial class ListarAnimales
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarAnimales));
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.chxFallecidos = new System.Windows.Forms.CheckBox();
            this.chxTransito = new System.Windows.Forms.CheckBox();
            this.chxNoAdoptados = new System.Windows.Forms.CheckBox();
            this.chxAdoptados = new System.Windows.Forms.CheckBox();
            this.dataMascotas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataMascotas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(71, 18);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(136, 20);
            this.txtBuscar.TabIndex = 20;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBuscar.Location = new System.Drawing.Point(12, 19);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(53, 17);
            this.lblBuscar.TabIndex = 19;
            this.lblBuscar.Text = "Buscar:";
            // 
            // chxFallecidos
            // 
            this.chxFallecidos.AutoSize = true;
            this.chxFallecidos.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxFallecidos.ForeColor = System.Drawing.SystemColors.Control;
            this.chxFallecidos.Location = new System.Drawing.Point(366, 36);
            this.chxFallecidos.Name = "chxFallecidos";
            this.chxFallecidos.Size = new System.Drawing.Size(90, 21);
            this.chxFallecidos.TabIndex = 25;
            this.chxFallecidos.Text = "Fallecidos";
            this.chxFallecidos.UseVisualStyleBackColor = true;
            // 
            // chxTransito
            // 
            this.chxTransito.AutoSize = true;
            this.chxTransito.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxTransito.ForeColor = System.Drawing.SystemColors.Control;
            this.chxTransito.Location = new System.Drawing.Point(366, 12);
            this.chxTransito.Name = "chxTransito";
            this.chxTransito.Size = new System.Drawing.Size(94, 21);
            this.chxTransito.TabIndex = 24;
            this.chxTransito.Text = "En transito";
            this.chxTransito.UseVisualStyleBackColor = true;
            // 
            // chxNoAdoptados
            // 
            this.chxNoAdoptados.AutoSize = true;
            this.chxNoAdoptados.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxNoAdoptados.ForeColor = System.Drawing.SystemColors.Control;
            this.chxNoAdoptados.Location = new System.Drawing.Point(230, 36);
            this.chxNoAdoptados.Name = "chxNoAdoptados";
            this.chxNoAdoptados.Size = new System.Drawing.Size(123, 21);
            this.chxNoAdoptados.TabIndex = 23;
            this.chxNoAdoptados.Text = "No adoptados";
            this.chxNoAdoptados.UseVisualStyleBackColor = true;
            // 
            // chxAdoptados
            // 
            this.chxAdoptados.AutoSize = true;
            this.chxAdoptados.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxAdoptados.ForeColor = System.Drawing.SystemColors.Control;
            this.chxAdoptados.Location = new System.Drawing.Point(230, 12);
            this.chxAdoptados.Name = "chxAdoptados";
            this.chxAdoptados.Size = new System.Drawing.Size(100, 21);
            this.chxAdoptados.TabIndex = 22;
            this.chxAdoptados.Text = "Adoptados";
            this.chxAdoptados.UseVisualStyleBackColor = true;
            // 
            // dataMascotas
            // 
            this.dataMascotas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataMascotas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(111)))), ((int)(((byte)(140)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataMascotas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataMascotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMascotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column1,
            this.Column2,
            this.Column10,
            this.Column11,
            this.Column3,
            this.Column12,
            this.Column4,
            this.Column7,
            this.Column6,
            this.Column13,
            this.Column5,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataMascotas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataMascotas.EnableHeadersVisualStyles = false;
            this.dataMascotas.GridColor = System.Drawing.Color.Snow;
            this.dataMascotas.Location = new System.Drawing.Point(2, 61);
            this.dataMascotas.Name = "dataMascotas";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dataMascotas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataMascotas.Size = new System.Drawing.Size(1080, 597);
            this.dataMascotas.TabIndex = 26;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nombre";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Especie";
            this.Column2.Name = "Column2";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Fecha de rescate";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Lugar de rescate";
            this.Column11.Name = "Column11";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Edad";
            this.Column3.Name = "Column3";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Peso";
            this.Column12.Name = "Column12";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Color";
            this.Column4.Name = "Column4";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Castración";
            this.Column7.Name = "Column7";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Sexo";
            this.Column6.Name = "Column6";
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Desparacitación";
            this.Column13.Name = "Column13";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Raza";
            this.Column5.Name = "Column5";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Fecha de castración";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Estado";
            this.Column9.Name = "Column9";
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModificar.BackgroundImage")));
            this.btnModificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Location = new System.Drawing.Point(975, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(40, 40);
            this.btnModificar.TabIndex = 27;
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Location = new System.Drawing.Point(929, 12);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(40, 40);
            this.btnNuevo.TabIndex = 28;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(1021, 12);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 40);
            this.btnEliminar.TabIndex = 29;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Location = new System.Drawing.Point(875, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(39, 40);
            this.btnExportar.TabIndex = 37;
            this.btnExportar.UseVisualStyleBackColor = true;
            // 
            // ListarAnimales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1083, 670);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.dataMascotas);
            this.Controls.Add(this.chxFallecidos);
            this.Controls.Add(this.chxTransito);
            this.Controls.Add(this.chxNoAdoptados);
            this.Controls.Add(this.chxAdoptados);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListarAnimales";
            this.Text = "ListarMascotas";
            this.Load += new System.EventHandler(this.ListarMascotas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataMascotas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.CheckBox chxFallecidos;
        private System.Windows.Forms.CheckBox chxTransito;
        private System.Windows.Forms.CheckBox chxNoAdoptados;
        private System.Windows.Forms.CheckBox chxAdoptados;
        private System.Windows.Forms.DataGridView dataMascotas;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnExportar;
    }
}