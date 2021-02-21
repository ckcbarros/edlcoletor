namespace EDL
{
    partial class NFManual
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
            this.btnConfirma = new System.Windows.Forms.Button();
            this.btnCancela = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtValorTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEmissao = new System.Windows.Forms.DateTimePicker();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.SuspendLayout();
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConfirma.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirma.ForeColor = System.Drawing.Color.Black;
            this.btnConfirma.Location = new System.Drawing.Point(114, 254);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(100, 35);
            this.btnConfirma.TabIndex = 5;
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
            this.btnCancela.TabIndex = 6;
            this.btnCancela.Text = "VOLTAR";
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtFornecedor.Location = new System.Drawing.Point(8, 77);
            this.txtFornecedor.MaxLength = 14;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(146, 24);
            this.txtFornecedor.TabIndex = 0;
            this.txtFornecedor.GotFocus += new System.EventHandler(this.txtFornecedor_GotFocus);
            this.txtFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFornecedor_KeyPress);
            this.txtFornecedor.LostFocus += new System.EventHandler(this.txtFornecedor_LostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.Text = "CNPJ FORNECEDOR";
            // 
            // txtFilial
            // 
            this.txtFilial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFilial.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtFilial.ForeColor = System.Drawing.Color.Black;
            this.txtFilial.Location = new System.Drawing.Point(164, 77);
            this.txtFilial.MaxLength = 44;
            this.txtFilial.Multiline = true;
            this.txtFilial.Name = "txtFilial";
            this.txtFilial.ReadOnly = true;
            this.txtFilial.Size = new System.Drawing.Size(146, 24);
            this.txtFilial.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(164, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.Text = "CNPJ FILIAL";
            // 
            // txtNF
            // 
            this.txtNF.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtNF.Location = new System.Drawing.Point(8, 136);
            this.txtNF.MaxLength = 6;
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(78, 24);
            this.txtNF.TabIndex = 1;
            this.txtNF.GotFocus += new System.EventHandler(this.txtNF_GotFocus);
            this.txtNF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNF_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.Text = "Nº DA NOTA FISCAL";
            // 
            // txtSerie
            // 
            this.txtSerie.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtSerie.Location = new System.Drawing.Point(164, 136);
            this.txtSerie.MaxLength = 6;
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(78, 24);
            this.txtSerie.TabIndex = 2;
            this.txtSerie.GotFocus += new System.EventHandler(this.txtSerie_GotFocus);
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(164, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 17);
            this.label4.Text = "SÉRIE";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.Text = "DATA DE EMISSÃO";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtValorTotal.Location = new System.Drawing.Point(164, 197);
            this.txtValorTotal.MaxLength = 9;
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(109, 24);
            this.txtValorTotal.TabIndex = 4;
            this.txtValorTotal.GotFocus += new System.EventHandler(this.txtValorTotal_GotFocus);
            this.txtValorTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorTotal_KeyPress);
            this.txtValorTotal.LostFocus += new System.EventHandler(this.txtValorTotal_LostFocus);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(164, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 17);
            this.label6.Text = "VALOR TOTAL";
            // 
            // dtpEmissao
            // 
            this.dtpEmissao.CalendarFont = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.dtpEmissao.CustomFormat = "dd/MM/yyyy";
            this.dtpEmissao.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.dtpEmissao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEmissao.Location = new System.Drawing.Point(8, 197);
            this.dtpEmissao.MinDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dtpEmissao.Name = "dtpEmissao";
            this.dtpEmissao.ShowUpDown = true;
            this.dtpEmissao.Size = new System.Drawing.Size(146, 25);
            this.dtpEmissao.TabIndex = 3;
            this.dtpEmissao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpEmissao_KeyPress);
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
            // NFManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.dtpEmissao);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNF);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilial);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NFManual";
            this.Text = "NFManual";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NFManual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EDL.Controles.BarraInferior barraInferior1;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValorTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEmissao;
    }
}