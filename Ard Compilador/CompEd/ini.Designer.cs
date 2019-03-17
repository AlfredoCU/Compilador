namespace CompEd
{
    partial class ini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ini));
            this.prbCarga = new System.Windows.Forms.ProgressBar();
            this.tiempoCarga = new System.Windows.Forms.Timer(this.components);
            this.lblCarga = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prbCarga
            // 
            this.prbCarga.Location = new System.Drawing.Point(25, 246);
            this.prbCarga.Name = "prbCarga";
            this.prbCarga.Size = new System.Drawing.Size(448, 21);
            this.prbCarga.TabIndex = 0;
            // 
            // tiempoCarga
            // 
            this.tiempoCarga.Interval = 1000;
            this.tiempoCarga.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblCarga
            // 
            this.lblCarga.AutoSize = true;
            this.lblCarga.BackColor = System.Drawing.Color.Transparent;
            this.lblCarga.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarga.ForeColor = System.Drawing.Color.Lavender;
            this.lblCarga.Location = new System.Drawing.Point(21, 212);
            this.lblCarga.Name = "lblCarga";
            this.lblCarga.Size = new System.Drawing.Size(161, 21);
            this.lblCarga.TabIndex = 1;
            this.lblCarga.Text = "Iniciando sistema ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(480, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "    ";
            this.label2.DoubleClick += new System.EventHandler(this.label2_DoubleClick);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.Lavender;
            this.lblVersion.Location = new System.Drawing.Point(441, 270);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(32, 21);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "2.0";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Lavender;
            this.lblTitulo.Location = new System.Drawing.Point(49, 82);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(399, 58);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "Ard Compilador";
            // 
            // ini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(498, 300);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCarga);
            this.Controls.Add(this.prbCarga);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ini";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.ini_Load);
            this.DoubleClick += new System.EventHandler(this.ini_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbCarga;
        private System.Windows.Forms.Timer tiempoCarga;
        private System.Windows.Forms.Label lblCarga;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblTitulo;
    }
}