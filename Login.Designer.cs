namespace EDL
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.label1 = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.picTeclado = new System.Windows.Forms.PictureBox();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.picConfiguracao = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 24);
            this.label1.Text = "EFETUE A LEITURA DO CRACHÁ ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblSenha
            // 
            this.lblSenha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblSenha.Location = new System.Drawing.Point(11, 247);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(91, 26);
            this.lblSenha.Text = "SENHA:";
            this.lblSenha.Visible = false;
            // 
            // txtSenha
            // 
            this.txtSenha.Enabled = false;
            this.txtSenha.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtSenha.Location = new System.Drawing.Point(109, 247);
            this.txtSenha.MaxLength = 20;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(179, 26);
            this.txtSenha.TabIndex = 4;
            this.txtSenha.Visible = false;
            this.txtSenha.GotFocus += new System.EventHandler(this.txtSenha_GotFocus);
            this.txtSenha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSenha_KeyPress);
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(67)))), ((int)(((byte)(127)))));
            this.btnEntrar.Enabled = false;
            this.btnEntrar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnEntrar.ForeColor = System.Drawing.Color.White;
            this.btnEntrar.Location = new System.Drawing.Point(75, 281);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(115, 35);
            this.btnEntrar.TabIndex = 6;
            this.btnEntrar.Text = "ENTRAR";
            this.btnEntrar.Visible = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.DarkRed;
            this.btnSair.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Location = new System.Drawing.Point(196, 281);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(115, 35);
            this.btnSair.TabIndex = 8;
            this.btnSair.Text = "SAIR";
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // picTeclado
            // 
            this.picTeclado.Image = ((System.Drawing.Image)(resources.GetObject("picTeclado.Image")));
            this.picTeclado.Location = new System.Drawing.Point(3, 287);
            this.picTeclado.Name = "picTeclado";
            this.picTeclado.Size = new System.Drawing.Size(30, 30);
            this.picTeclado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTeclado.Click += new System.EventHandler(this.picTeclado_Click);
            // 
            // picConfiguracao
            // 
            this.picConfiguracao.Image = ((System.Drawing.Image)(resources.GetObject("picConfiguracao.Image")));
            this.picConfiguracao.Location = new System.Drawing.Point(39, 287);
            this.picConfiguracao.Name = "picConfiguracao";
            this.picConfiguracao.Size = new System.Drawing.Size(30, 30);
            this.picConfiguracao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picConfiguracao.Click += new System.EventHandler(this.picConfiguracao_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 320);
            this.ControlBox = false;
            this.Controls.Add(this.picConfiguracao);
            this.Controls.Add(this.picTeclado);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Login_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Login_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnEntrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox picTeclado;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.PictureBox picConfiguracao;
        private System.Windows.Forms.Timer timer1;
    }
}