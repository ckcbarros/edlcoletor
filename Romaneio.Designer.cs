namespace EDL
{
    partial class Romaneio
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
            this.dtpEmissao = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.lsvDocumentos = new System.Windows.Forms.ListView();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.CNPJ = new System.Windows.Forms.ColumnHeader();
            this.RazaoSocial = new System.Windows.Forms.ColumnHeader();
            this.Fantasia = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.SuspendLayout();
            // 
            // dtpEmissao
            // 
            this.dtpEmissao.CalendarFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.dtpEmissao.CustomFormat = "dd/MM/yyyy";
            this.dtpEmissao.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.dtpEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmissao.Location = new System.Drawing.Point(183, 80);
            this.dtpEmissao.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpEmissao.Name = "dtpEmissao";
            this.dtpEmissao.ShowUpDown = true;
            this.dtpEmissao.Size = new System.Drawing.Size(127, 25);
            this.dtpEmissao.TabIndex = 40;
            this.dtpEmissao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpEmissao_KeyPress);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(183, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 17);
            this.label5.Text = "DATA DE EMISSÃO";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.Text = "CNPJ FILIAL";
            // 
            // txtFilial
            // 
            this.txtFilial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFilial.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtFilial.ForeColor = System.Drawing.Color.Black;
            this.txtFilial.Location = new System.Drawing.Point(8, 80);
            this.txtFilial.MaxLength = 44;
            this.txtFilial.Multiline = true;
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.ReadOnly = true;
            this.txtFilial.Size = new System.Drawing.Size(146, 24);
            this.txtFilial.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 17);
            this.label2.Text = "USE O LEITOR PARA CONSULTAR O CNPJ";
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConfirma.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirma.ForeColor = System.Drawing.Color.Black;
            this.btnConfirma.Location = new System.Drawing.Point(114, 254);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(100, 35);
            this.btnConfirma.TabIndex = 43;
            this.btnConfirma.Text = "CONFIRMAR";
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancela.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancela.Location = new System.Drawing.Point(220, 254);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(90, 35);
            this.btnCancela.TabIndex = 45;
            this.btnCancela.Text = "VOLTAR";
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // lsvDocumentos
            // 
            this.lsvDocumentos.BackColor = System.Drawing.Color.White;
            this.lsvDocumentos.Columns.Add(this.ID);
            this.lsvDocumentos.Columns.Add(this.CNPJ);
            this.lsvDocumentos.Columns.Add(this.RazaoSocial);
            this.lsvDocumentos.Columns.Add(this.Fantasia);
            this.lsvDocumentos.ForeColor = System.Drawing.Color.Black;
            this.lsvDocumentos.FullRowSelect = true;
            this.lsvDocumentos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvDocumentos.Location = new System.Drawing.Point(8, 131);
            this.lsvDocumentos.Name = "lsvDocumentos";
            this.lsvDocumentos.Size = new System.Drawing.Size(302, 114);
            this.lsvDocumentos.TabIndex = 53;
            this.lsvDocumentos.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "#";
            this.ID.Width = 0;
            // 
            // CNPJ
            // 
            this.CNPJ.Text = "CNPJ";
            this.CNPJ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CNPJ.Width = 150;
            // 
            // RazaoSocial
            // 
            this.RazaoSocial.Text = "Razão Social";
            this.RazaoSocial.Width = 250;
            // 
            // Fantasia
            // 
            this.Fantasia.Text = "Nome Fantasia";
            this.Fantasia.Width = 250;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // barraInferior1
            // 
            this.barraInferior1.Location = new System.Drawing.Point(0, 295);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(325, 30);
            this.barraInferior1.TabIndex = 50;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 49;
            // 
            // Romaneio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.lsvDocumentos);
            this.Controls.Add(this.dtpEmissao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Romaneio";
            this.Text = "Romaneio";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Romaneio_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEmissao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Button btnCancela;
        private EDL.Controles.BarraInferior barraInferior1;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.ListView lsvDocumentos;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader CNPJ;
        private System.Windows.Forms.ColumnHeader RazaoSocial;
        private System.Windows.Forms.ColumnHeader Fantasia;
        private System.Windows.Forms.Timer timer1;
    }
}