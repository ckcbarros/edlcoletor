namespace EDL.Controles
{
    partial class BarraInferior
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarraInferior));
            this.lblSinal = new System.Windows.Forms.Label();
            this.picSinal = new System.Windows.Forms.PictureBox();
            this.picTeclado = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.picBateria = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.lblFilial = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSinal
            // 
            this.lblSinal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblSinal.ForeColor = System.Drawing.Color.White;
            this.lblSinal.Location = new System.Drawing.Point(228, 14);
            this.lblSinal.Name = "lblSinal";
            this.lblSinal.Size = new System.Drawing.Size(43, 14);
            this.lblSinal.Text = "online";
            this.lblSinal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // picSinal
            // 
            this.picSinal.Image = ((System.Drawing.Image)(resources.GetObject("picSinal.Image")));
            this.picSinal.Location = new System.Drawing.Point(273, 15);
            this.picSinal.Name = "picSinal";
            this.picSinal.Size = new System.Drawing.Size(13, 13);
            this.picSinal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // picTeclado
            // 
            this.picTeclado.Image = ((System.Drawing.Image)(resources.GetObject("picTeclado.Image")));
            this.picTeclado.Location = new System.Drawing.Point(151, 17);
            this.picTeclado.Name = "picTeclado";
            this.picTeclado.Size = new System.Drawing.Size(17, 9);
            this.picTeclado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTeclado.Click += new System.EventHandler(this.picTeclado_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picBateria
            // 
            this.picBateria.Image = ((System.Drawing.Image)(resources.GetObject("picBateria.Image")));
            this.picBateria.Location = new System.Drawing.Point(292, 17);
            this.picBateria.Name = "picBateria";
            this.picBateria.Size = new System.Drawing.Size(23, 9);
            this.picBateria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(325, 12);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // lblDataHora
            // 
            this.lblDataHora.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblDataHora.ForeColor = System.Drawing.Color.White;
            this.lblDataHora.Location = new System.Drawing.Point(5, 15);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(118, 11);
            // 
            // lblFilial
            // 
            this.lblFilial.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lblFilial.ForeColor = System.Drawing.Color.White;
            this.lblFilial.Location = new System.Drawing.Point(174, 14);
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(57, 14);
            this.lblFilial.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BarraInferior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(86)))), ((int)(((byte)(144)))));
            this.Controls.Add(this.lblFilial);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.picBateria);
            this.Controls.Add(this.picSinal);
            this.Controls.Add(this.lblSinal);
            this.Controls.Add(this.picTeclado);
            this.Controls.Add(this.pictureBox2);
            this.Name = "BarraInferior";
            this.Size = new System.Drawing.Size(325, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picTeclado;
        public System.Windows.Forms.PictureBox picSinal;
        private System.Windows.Forms.Label lblSinal;
        private System.Windows.Forms.PictureBox picBateria;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblDataHora;
        public Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFilial;
    }
}
