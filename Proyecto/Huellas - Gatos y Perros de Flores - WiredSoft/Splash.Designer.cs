namespace Huellas___Gatos_y_Perros_de_Flores___WiredSoft
{
    partial class Splash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.picSplash = new System.Windows.Forms.PictureBox();
            this.panelBar = new System.Windows.Forms.Panel();
            this.panelProgreso = new System.Windows.Forms.Panel();
            this.timerProgreso = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).BeginInit();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // picSplash
            // 
            this.picSplash.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.picSplash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSplash.Image = ((System.Drawing.Image)(resources.GetObject("picSplash.Image")));
            this.picSplash.Location = new System.Drawing.Point(0, 0);
            this.picSplash.Name = "picSplash";
            this.picSplash.Size = new System.Drawing.Size(684, 361);
            this.picSplash.TabIndex = 0;
            this.picSplash.TabStop = false;
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(39)))), ((int)(((byte)(105)))));
            this.panelBar.Controls.Add(this.panelProgreso);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.panelBar.Location = new System.Drawing.Point(0, 338);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(684, 23);
            this.panelBar.TabIndex = 1;
            // 
            // panelProgreso
            // 
            this.panelProgreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(81)))), ((int)(((byte)(135)))));
            this.panelProgreso.Location = new System.Drawing.Point(4, 3);
            this.panelProgreso.Name = "panelProgreso";
            this.panelProgreso.Size = new System.Drawing.Size(87, 19);
            this.panelProgreso.TabIndex = 0;
            // 
            // timerProgreso
            // 
            this.timerProgreso.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.picSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splash";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            ((System.ComponentModel.ISupportInitialize)(this.picSplash)).EndInit();
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSplash;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Panel panelProgreso;
        private System.Windows.Forms.Timer timerProgreso;
    }
}