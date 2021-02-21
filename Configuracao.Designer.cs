namespace EDL
{
    partial class Configuracao
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.txtWebService = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAtualizarApp = new System.Windows.Forms.Button();
            this.pnlOK = new System.Windows.Forms.Panel();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.pnlOK.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSair.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.Location = new System.Drawing.Point(232, 254);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(80, 35);
            this.btnSair.TabIndex = 3;
            this.btnSair.Text = "VOLTAR";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.Black;
            this.btnSalvar.Location = new System.Drawing.Point(13, 131);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(80, 35);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "SALVAR";
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // txtWebService
            // 
            this.txtWebService.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtWebService.Location = new System.Drawing.Point(13, 101);
            this.txtWebService.MaxLength = 255;
            this.txtWebService.Name = "txtWebService";
            this.txtWebService.Size = new System.Drawing.Size(299, 24);
            this.txtWebService.TabIndex = 1;
            this.txtWebService.GotFocus += new System.EventHandler(this.txtWebService_GotFocus);
            this.txtWebService.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWebService_KeyPress);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.Text = "WEBSERVICE";
            // 
            // btnAtualizarApp
            // 
            this.btnAtualizarApp.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAtualizarApp.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtualizarApp.ForeColor = System.Drawing.Color.Black;
            this.btnAtualizarApp.Location = new System.Drawing.Point(13, 228);
            this.btnAtualizarApp.Name = "btnAtualizarApp";
            this.btnAtualizarApp.Size = new System.Drawing.Size(152, 35);
            this.btnAtualizarApp.TabIndex = 30;
            this.btnAtualizarApp.Text = "ATUALIZAR APP";
            this.btnAtualizarApp.Click += new System.EventHandler(this.btnAtualizarApp_Click);
            // 
            // pnlOK
            // 
            this.pnlOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pnlOK.Controls.Add(this.lblMensagem);
            this.pnlOK.Enabled = false;
            this.pnlOK.Location = new System.Drawing.Point(295, 60);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Size = new System.Drawing.Size(54, 35);
            this.pnlOK.Visible = false;
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.Black;
            this.lblMensagem.Location = new System.Drawing.Point(0, 41);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(316, 170);
            this.lblMensagem.Text = "OK";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(299, 52);
            this.label2.Text = "CLIQUE NO BOTÃO ABAIXO PARA ATUALIZAR O APLICATIVO DE MUDANÇA DE VERSÃO DO EDL CO" +
                "LETOR:";
            // 
            // barraInferior1
            // 
            this.barraInferior1.Location = new System.Drawing.Point(0, 295);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(325, 30);
            this.barraInferior1.TabIndex = 29;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 28;
            // 
            // Configuracao
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.pnlOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAtualizarApp);
            this.Controls.Add(this.txtWebService);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Configuracao";
            this.Text = "Configuracao";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Configuracao_Load);
            this.pnlOK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private EDL.Controles.BarraInferior barraInferior1;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtWebService;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAtualizarApp;
        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label label2;
    }
}