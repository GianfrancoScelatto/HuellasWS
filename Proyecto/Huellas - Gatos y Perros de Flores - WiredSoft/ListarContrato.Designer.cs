﻿namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    partial class ListarContrato
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarContrato));
            this.panelBotones = new System.Windows.Forms.Panel();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.dgvContrato = new System.Windows.Forms.DataGridView();
            this.dgvListarContrato = new System.Windows.Forms.DataGridView();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContrato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarContrato)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBotones
            // 
            this.panelBotones.Controls.Add(this.btnExportar);
            this.panelBotones.Controls.Add(this.btnEliminar);
            this.panelBotones.Controls.Add(this.btnNuevo);
            this.panelBotones.Controls.Add(this.txtBuscar);
            this.panelBotones.Controls.Add(this.lblBuscar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBotones.Location = new System.Drawing.Point(0, 0);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Size = new System.Drawing.Size(1083, 55);
            this.panelBotones.TabIndex = 28;
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExportar.BackgroundImage")));
            this.btnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Location = new System.Drawing.Point(935, 6);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(39, 40);
            this.btnExportar.TabIndex = 47;
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEliminar.BackgroundImage")));
            this.btnEliminar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Location = new System.Drawing.Point(1026, 6);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 40);
            this.btnEliminar.TabIndex = 46;
            this.btnEliminar.Text = "-";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNuevo.BackgroundImage")));
            this.btnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Location = new System.Drawing.Point(980, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(40, 40);
            this.btnNuevo.TabIndex = 45;
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(76, 11);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(136, 20);
            this.txtBuscar.TabIndex = 39;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.Control;
            this.lblBuscar.Location = new System.Drawing.Point(17, 12);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(53, 17);
            this.lblBuscar.TabIndex = 38;
            this.lblBuscar.Text = "Buscar:";
            // 
            // dgvContrato
            // 
            this.dgvContrato.AllowUserToAddRows = false;
            this.dgvContrato.AllowUserToDeleteRows = false;
            this.dgvContrato.AllowUserToResizeColumns = false;
            this.dgvContrato.AllowUserToResizeRows = false;
            this.dgvContrato.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContrato.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.dgvContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvContrato.Location = new System.Drawing.Point(0, 55);
            this.dgvContrato.Name = "dgvContrato";
            this.dgvContrato.ReadOnly = true;
            this.dgvContrato.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContrato.Size = new System.Drawing.Size(1083, 615);
            this.dgvContrato.TabIndex = 29;
            // 
            // dgvListarContrato
            // 
            this.dgvListarContrato.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarContrato.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListarContrato.Location = new System.Drawing.Point(0, 55);
            this.dgvListarContrato.Name = "dgvListarContrato";
            this.dgvListarContrato.Size = new System.Drawing.Size(1083, 615);
            this.dgvListarContrato.TabIndex = 30;
            // 
            // ListarContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1083, 670);
            this.Controls.Add(this.dgvListarContrato);
            this.Controls.Add(this.dgvContrato);
            this.Controls.Add(this.panelBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListarContrato";
            this.Text = "ListarContrato";
            this.Load += new System.EventHandler(this.ListarContrato_Load);
            this.panelBotones.ResumeLayout(false);
            this.panelBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContrato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarContrato)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.DataGridView dgvContrato;
        private System.Windows.Forms.DataGridView dgvListarContrato;
    }
}