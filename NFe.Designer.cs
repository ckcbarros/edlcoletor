namespace EDL
{
    partial class NFe
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
            this.btnCancela = new System.Windows.Forms.Button();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.btnSemNfe = new System.Windows.Forms.Button();
            this.txtNFe1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNFe2 = new System.Windows.Forms.TextBox();
            this.txtNFe3 = new System.Windows.Forms.TextBox();
            this.txtNFe4 = new System.Windows.Forms.TextBox();
            this.txtNFe5 = new System.Windows.Forms.TextBox();
            this.txtNFe10 = new System.Windows.Forms.TextBox();
            this.txtNFe9 = new System.Windows.Forms.TextBox();
            this.txtNFe8 = new System.Windows.Forms.TextBox();
            this.txtNFe7 = new System.Windows.Forms.TextBox();
            this.txtNFe6 = new System.Windows.Forms.TextBox();
            this.txtNFe11 = new System.Windows.Forms.TextBox();
            this.picOk = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNFe = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.pnlOK = new System.Windows.Forms.Panel();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.pnlOK.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancela.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancela.Location = new System.Drawing.Point(220, 254);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(90, 35);
            this.btnCancela.TabIndex = 13;
            this.btnCancela.Text = "VOLTAR";
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConfirma.Enabled = false;
            this.btnConfirma.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirma.ForeColor = System.Drawing.Color.Black;
            this.btnConfirma.Location = new System.Drawing.Point(18, 254);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(100, 35);
            this.btnConfirma.TabIndex = 11;
            this.btnConfirma.Text = "CONFIRMAR";
            this.btnConfirma.Visible = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // btnSemNfe
            // 
            this.btnSemNfe.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSemNfe.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSemNfe.ForeColor = System.Drawing.Color.Black;
            this.btnSemNfe.Location = new System.Drawing.Point(124, 254);
            this.btnSemNfe.Name = "btnSemNfe";
            this.btnSemNfe.Size = new System.Drawing.Size(90, 35);
            this.btnSemNfe.TabIndex = 12;
            this.btnSemNfe.Text = "SEM NF-e";
            this.btnSemNfe.Click += new System.EventHandler(this.btnSemNfe_Click);
            // 
            // txtNFe1
            // 
            this.txtNFe1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe1.Location = new System.Drawing.Point(8, 179);
            this.txtNFe1.MaxLength = 4;
            this.txtNFe1.Name = "txtNFe1";
            this.txtNFe1.Size = new System.Drawing.Size(47, 26);
            this.txtNFe1.TabIndex = 0;
            this.txtNFe1.TextChanged += new System.EventHandler(this.txtNFe1_TextChanged);
            this.txtNFe1.GotFocus += new System.EventHandler(this.txtNFe1_GotFocus);
            this.txtNFe1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe1_KeyPress);
            this.txtNFe1.LostFocus += new System.EventHandler(this.txtNFe1_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 32);
            this.label2.Text = "OU DIGITE OS NÚMEROS DO CÓDIGO ELETRÔNICO DA NOTA FISCAL";
            // 
            // txtNFe2
            // 
            this.txtNFe2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe2.Location = new System.Drawing.Point(59, 179);
            this.txtNFe2.MaxLength = 4;
            this.txtNFe2.Name = "txtNFe2";
            this.txtNFe2.Size = new System.Drawing.Size(47, 26);
            this.txtNFe2.TabIndex = 1;
            this.txtNFe2.TextChanged += new System.EventHandler(this.txtNFe2_TextChanged);
            this.txtNFe2.GotFocus += new System.EventHandler(this.txtNFe2_GotFocus);
            this.txtNFe2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe2_KeyPress);
            this.txtNFe2.LostFocus += new System.EventHandler(this.txtNFe2_LostFocus);
            // 
            // txtNFe3
            // 
            this.txtNFe3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe3.Location = new System.Drawing.Point(110, 179);
            this.txtNFe3.MaxLength = 4;
            this.txtNFe3.Name = "txtNFe3";
            this.txtNFe3.Size = new System.Drawing.Size(47, 26);
            this.txtNFe3.TabIndex = 2;
            this.txtNFe3.TextChanged += new System.EventHandler(this.txtNFe3_TextChanged);
            this.txtNFe3.GotFocus += new System.EventHandler(this.txtNFe3_GotFocus);
            this.txtNFe3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe3_KeyPress);
            this.txtNFe3.LostFocus += new System.EventHandler(this.txtNFe3_LostFocus);
            // 
            // txtNFe4
            // 
            this.txtNFe4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe4.Location = new System.Drawing.Point(161, 179);
            this.txtNFe4.MaxLength = 4;
            this.txtNFe4.Name = "txtNFe4";
            this.txtNFe4.Size = new System.Drawing.Size(47, 26);
            this.txtNFe4.TabIndex = 3;
            this.txtNFe4.TextChanged += new System.EventHandler(this.txtNFe4_TextChanged);
            this.txtNFe4.GotFocus += new System.EventHandler(this.txtNFe4_GotFocus);
            this.txtNFe4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe4_KeyPress);
            this.txtNFe4.LostFocus += new System.EventHandler(this.txtNFe4_LostFocus);
            // 
            // txtNFe5
            // 
            this.txtNFe5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe5.Location = new System.Drawing.Point(212, 179);
            this.txtNFe5.MaxLength = 4;
            this.txtNFe5.Name = "txtNFe5";
            this.txtNFe5.Size = new System.Drawing.Size(47, 26);
            this.txtNFe5.TabIndex = 4;
            this.txtNFe5.TextChanged += new System.EventHandler(this.txtNFe5_TextChanged);
            this.txtNFe5.GotFocus += new System.EventHandler(this.txtNFe5_GotFocus);
            this.txtNFe5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe5_KeyPress);
            this.txtNFe5.LostFocus += new System.EventHandler(this.txtNFe5_LostFocus);
            // 
            // txtNFe10
            // 
            this.txtNFe10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe10.Location = new System.Drawing.Point(161, 211);
            this.txtNFe10.MaxLength = 4;
            this.txtNFe10.Name = "txtNFe10";
            this.txtNFe10.Size = new System.Drawing.Size(47, 26);
            this.txtNFe10.TabIndex = 9;
            this.txtNFe10.TextChanged += new System.EventHandler(this.txtNFe10_TextChanged);
            this.txtNFe10.GotFocus += new System.EventHandler(this.txtNFe10_GotFocus);
            this.txtNFe10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe10_KeyPress);
            this.txtNFe10.LostFocus += new System.EventHandler(this.txtNFe10_LostFocus);
            // 
            // txtNFe9
            // 
            this.txtNFe9.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe9.Location = new System.Drawing.Point(110, 211);
            this.txtNFe9.MaxLength = 4;
            this.txtNFe9.Name = "txtNFe9";
            this.txtNFe9.Size = new System.Drawing.Size(47, 26);
            this.txtNFe9.TabIndex = 8;
            this.txtNFe9.TextChanged += new System.EventHandler(this.txtNFe9_TextChanged);
            this.txtNFe9.GotFocus += new System.EventHandler(this.txtNFe9_GotFocus);
            this.txtNFe9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe9_KeyPress);
            this.txtNFe9.LostFocus += new System.EventHandler(this.txtNFe9_LostFocus);
            // 
            // txtNFe8
            // 
            this.txtNFe8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe8.Location = new System.Drawing.Point(59, 211);
            this.txtNFe8.MaxLength = 4;
            this.txtNFe8.Name = "txtNFe8";
            this.txtNFe8.Size = new System.Drawing.Size(47, 26);
            this.txtNFe8.TabIndex = 7;
            this.txtNFe8.TextChanged += new System.EventHandler(this.txtNFe8_TextChanged);
            this.txtNFe8.GotFocus += new System.EventHandler(this.txtNFe8_GotFocus);
            this.txtNFe8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe8_KeyPress);
            this.txtNFe8.LostFocus += new System.EventHandler(this.txtNFe8_LostFocus);
            // 
            // txtNFe7
            // 
            this.txtNFe7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe7.Location = new System.Drawing.Point(8, 211);
            this.txtNFe7.MaxLength = 4;
            this.txtNFe7.Name = "txtNFe7";
            this.txtNFe7.Size = new System.Drawing.Size(47, 26);
            this.txtNFe7.TabIndex = 6;
            this.txtNFe7.TextChanged += new System.EventHandler(this.txtNFe7_TextChanged);
            this.txtNFe7.GotFocus += new System.EventHandler(this.txtNFe7_GotFocus);
            this.txtNFe7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe7_KeyPress);
            this.txtNFe7.LostFocus += new System.EventHandler(this.txtNFe7_LostFocus);
            // 
            // txtNFe6
            // 
            this.txtNFe6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe6.Location = new System.Drawing.Point(263, 179);
            this.txtNFe6.MaxLength = 4;
            this.txtNFe6.Name = "txtNFe6";
            this.txtNFe6.Size = new System.Drawing.Size(47, 26);
            this.txtNFe6.TabIndex = 5;
            this.txtNFe6.TextChanged += new System.EventHandler(this.txtNFe6_TextChanged);
            this.txtNFe6.GotFocus += new System.EventHandler(this.txtNFe6_GotFocus);
            this.txtNFe6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe6_KeyPress);
            this.txtNFe6.LostFocus += new System.EventHandler(this.txtNFe6_LostFocus);
            // 
            // txtNFe11
            // 
            this.txtNFe11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe11.Location = new System.Drawing.Point(212, 211);
            this.txtNFe11.MaxLength = 4;
            this.txtNFe11.Name = "txtNFe11";
            this.txtNFe11.Size = new System.Drawing.Size(47, 26);
            this.txtNFe11.TabIndex = 10;
            this.txtNFe11.GotFocus += new System.EventHandler(this.txtNFe11_GotFocus);
            this.txtNFe11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNFe11_KeyPress);
            this.txtNFe11.LostFocus += new System.EventHandler(this.txtNFe11_LostFocus);
            // 
            // picOk
            // 
            this.picOk.Location = new System.Drawing.Point(263, 211);
            this.picOk.Name = "picOk";
            this.picOk.Size = new System.Drawing.Size(24, 24);
            this.picOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 33);
            this.label1.Text = "EFETUE E LEITURA DO CÓDIGO DE BARRAS DA NOTA FISCAL";
            // 
            // txtNFe
            // 
            this.txtNFe.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNFe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtNFe.ForeColor = System.Drawing.Color.Black;
            this.txtNFe.Location = new System.Drawing.Point(8, 92);
            this.txtNFe.MaxLength = 44;
            this.txtNFe.Multiline = true;
            this.txtNFe.Name = "txtNFe";
            this.txtNFe.ReadOnly = true;
            this.txtNFe.Size = new System.Drawing.Size(302, 45);
            this.txtNFe.TabIndex = 27;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlOK
            // 
            this.pnlOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pnlOK.Controls.Add(this.lblMensagem);
            this.pnlOK.Enabled = false;
            this.pnlOK.Location = new System.Drawing.Point(290, 144);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Size = new System.Drawing.Size(52, 29);
            this.pnlOK.Visible = false;
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.Black;
            this.lblMensagem.Location = new System.Drawing.Point(0, 68);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(316, 110);
            this.lblMensagem.Text = "OK";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // barraInferior1
            // 
            this.barraInferior1.Location = new System.Drawing.Point(0, 295);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(325, 30);
            this.barraInferior1.TabIndex = 25;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 24;
            // 
            // NFe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.pnlOK);
            this.Controls.Add(this.txtNFe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picOk);
            this.Controls.Add(this.txtNFe11);
            this.Controls.Add(this.txtNFe10);
            this.Controls.Add(this.txtNFe9);
            this.Controls.Add(this.txtNFe8);
            this.Controls.Add(this.txtNFe7);
            this.Controls.Add(this.txtNFe6);
            this.Controls.Add(this.txtNFe5);
            this.Controls.Add(this.txtNFe4);
            this.Controls.Add(this.txtNFe3);
            this.Controls.Add(this.txtNFe2);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNFe1);
            this.Controls.Add(this.btnSemNfe);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.btnCancela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NFe";
            this.Text = "NFe";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NFe_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NFe_KeyPress);
            this.pnlOK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Button btnSemNfe;
        private System.Windows.Forms.TextBox txtNFe1;
        private System.Windows.Forms.Label label2;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private EDL.Controles.BarraInferior barraInferior1;
        private System.Windows.Forms.TextBox txtNFe2;
        private System.Windows.Forms.TextBox txtNFe3;
        private System.Windows.Forms.TextBox txtNFe4;
        private System.Windows.Forms.TextBox txtNFe5;
        private System.Windows.Forms.TextBox txtNFe10;
        private System.Windows.Forms.TextBox txtNFe9;
        private System.Windows.Forms.TextBox txtNFe8;
        private System.Windows.Forms.TextBox txtNFe7;
        private System.Windows.Forms.TextBox txtNFe6;
        private System.Windows.Forms.TextBox txtNFe11;
        private System.Windows.Forms.PictureBox picOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNFe;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Label lblMensagem;

    }
}

