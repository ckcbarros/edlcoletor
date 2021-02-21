namespace EDL
{
    partial class Fornecedor
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
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.btnCancela = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFornecedorBipado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // barraInferior1
            // 
            this.barraInferior1.Location = new System.Drawing.Point(0, 295);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(325, 30);
            this.barraInferior1.TabIndex = 27;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 26;
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancela.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancela.Location = new System.Drawing.Point(220, 254);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(90, 35);
            this.btnCancela.TabIndex = 2;
            this.btnCancela.Text = "VOLTAR";
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 33);
            this.label1.Text = "EFETUE A LEITURA DO CÓDIGO DE BARRAS DO FORNECEDOR";
            // 
            // txtFornecedorBipado
            // 
            this.txtFornecedorBipado.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFornecedorBipado.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtFornecedorBipado.ForeColor = System.Drawing.Color.Black;
            this.txtFornecedorBipado.Location = new System.Drawing.Point(8, 93);
            this.txtFornecedorBipado.MaxLength = 44;
            this.txtFornecedorBipado.Multiline = true;
            this.txtFornecedorBipado.Name = "txtFornecedorBipado";
            this.txtFornecedorBipado.ReadOnly = true;
            this.txtFornecedorBipado.Size = new System.Drawing.Size(95, 25);
            this.txtFornecedorBipado.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 17);
            this.label2.Text = "OU DIGITE O CÓDIGO DO FORNECEDOR";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtFornecedor.Location = new System.Drawing.Point(8, 155);
            this.txtFornecedor.MaxLength = 6;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.Size = new System.Drawing.Size(95, 26);
            this.txtFornecedor.TabIndex = 0;
            this.txtFornecedor.TextChanged += new System.EventHandler(this.txtFornecedor_TextChanged);
            this.txtFornecedor.GotFocus += new System.EventHandler(this.txtFornecedor_GotFocus);
            this.txtFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFornecedor_KeyPress);
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConfirma.Enabled = false;
            this.btnConfirma.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirma.ForeColor = System.Drawing.Color.Black;
            this.btnConfirma.Location = new System.Drawing.Point(114, 254);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(100, 35);
            this.btnConfirma.TabIndex = 1;
            this.btnConfirma.Text = "CONFIRMAR";
            this.btnConfirma.Visible = false;
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Fornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFornecedorBipado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancela);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fornecedor";
            this.Text = "Fornecedor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Fornecedor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EDL.Controles.BarraInferior barraInferior1;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFornecedorBipado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Timer timer1;
    }
}