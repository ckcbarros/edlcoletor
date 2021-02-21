namespace EDL
{
    partial class Menu
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
            this.btnSair = new System.Windows.Forms.Button();
            this.imlMenu = new System.Windows.Forms.ImageList();
            this.lsvOpcoes = new System.Windows.Forms.ListView();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSair.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.Location = new System.Drawing.Point(222, 254);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(90, 35);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "VOLTAR";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // imlMenu
            // 
            this.imlMenu.ImageSize = new System.Drawing.Size(54, 54);
            // 
            // lsvOpcoes
            // 
            this.lsvOpcoes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvOpcoes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvOpcoes.LargeImageList = this.imlMenu;
            this.lsvOpcoes.Location = new System.Drawing.Point(8, 60);
            this.lsvOpcoes.Name = "lsvOpcoes";
            this.lsvOpcoes.Size = new System.Drawing.Size(304, 188);
            this.lsvOpcoes.SmallImageList = this.imlMenu;
            this.lsvOpcoes.TabIndex = 0;
            this.lsvOpcoes.View = System.Windows.Forms.View.Details;
            this.lsvOpcoes.SelectedIndexChanged += new System.EventHandler(this.lsvOpcoes_SelectedIndexChanged);
            // 
            // barraInferior1
            // 
            this.barraInferior1.Location = new System.Drawing.Point(0, 295);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(325, 30);
            this.barraInferior1.TabIndex = 26;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 25;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.lsvOpcoes);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.Text = "Menu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EDL.Controles.BarraSuperior barraSuperior1;
        private EDL.Controles.BarraInferior barraInferior1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ImageList imlMenu;
        private System.Windows.Forms.ListView lsvOpcoes;
    }
}