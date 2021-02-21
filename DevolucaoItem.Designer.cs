namespace EDL
{
    partial class DevolucaoItem
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
            this.pnlOK = new System.Windows.Forms.Panel();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.lsvDocumentos = new System.Windows.Forms.ListView();
            this.CodigoBarras = new System.Windows.Forms.ColumnHeader();
            this.Quantidade = new System.Windows.Forms.ColumnHeader();
            this.Descricao = new System.Windows.Forms.ColumnHeader();
            this.timer1 = new System.Windows.Forms.Timer();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDevolucao = new System.Windows.Forms.TextBox();
            this.pnlOK.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOK
            // 
            this.pnlOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pnlOK.Controls.Add(this.lblMensagem);
            this.pnlOK.Enabled = false;
            this.pnlOK.Location = new System.Drawing.Point(319, 146);
            this.pnlOK.Name = "pnlOK";
            this.pnlOK.Size = new System.Drawing.Size(55, 35);
            this.pnlOK.Visible = false;
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.lblMensagem.ForeColor = System.Drawing.Color.Black;
            this.lblMensagem.Location = new System.Drawing.Point(0, 85);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(305, 55);
            this.lblMensagem.Text = "CONSULTANDO...";
            this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRemover.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemover.ForeColor = System.Drawing.Color.Black;
            this.btnRemover.Location = new System.Drawing.Point(8, 254);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(90, 35);
            this.btnRemover.TabIndex = 55;
            this.btnRemover.Text = "REMOVER";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnVoltar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVoltar.Location = new System.Drawing.Point(223, 254);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(90, 35);
            this.btnVoltar.TabIndex = 51;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConfirma.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirma.ForeColor = System.Drawing.Color.Black;
            this.btnConfirma.Location = new System.Drawing.Point(117, 254);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(100, 35);
            this.btnConfirma.TabIndex = 50;
            this.btnConfirma.Text = "CONFIRMAR";
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // lsvDocumentos
            // 
            this.lsvDocumentos.BackColor = System.Drawing.Color.White;
            this.lsvDocumentos.Columns.Add(this.CodigoBarras);
            this.lsvDocumentos.Columns.Add(this.Quantidade);
            this.lsvDocumentos.Columns.Add(this.Descricao);
            this.lsvDocumentos.ForeColor = System.Drawing.Color.Black;
            this.lsvDocumentos.FullRowSelect = true;
            this.lsvDocumentos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvDocumentos.Location = new System.Drawing.Point(8, 104);
            this.lsvDocumentos.Name = "lsvDocumentos";
            this.lsvDocumentos.Size = new System.Drawing.Size(305, 144);
            this.lsvDocumentos.TabIndex = 49;
            this.lsvDocumentos.View = System.Windows.Forms.View.Details;
            // 
            // CodigoBarras
            // 
            this.CodigoBarras.Text = "Código Barras";
            this.CodigoBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CodigoBarras.Width = 140;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Qtd";
            this.Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Quantidade.Width = 65;
            // 
            // Descricao
            // 
            this.Descricao.Text = "Descrição";
            this.Descricao.Width = 220;
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
            this.barraInferior1.TabIndex = 53;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 52;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(132, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 16);
            this.label1.Text = "FORNECEDOR";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFornecedor.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtFornecedor.ForeColor = System.Drawing.Color.Black;
            this.txtFornecedor.Location = new System.Drawing.Point(132, 76);
            this.txtFornecedor.MaxLength = 18;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(181, 24);
            this.txtFornecedor.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.Text = "DEVOLUÇÃO";
            // 
            // txtDevolucao
            // 
            this.txtDevolucao.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDevolucao.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtDevolucao.ForeColor = System.Drawing.Color.Black;
            this.txtDevolucao.Location = new System.Drawing.Point(8, 76);
            this.txtDevolucao.MaxLength = 18;
            this.txtDevolucao.Name = "txtDevolucao";
            this.txtDevolucao.ReadOnly = true;
            this.txtDevolucao.Size = new System.Drawing.Size(118, 24);
            this.txtDevolucao.TabIndex = 58;
            // 
            // DevolucaoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.pnlOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDevolucao);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.lsvDocumentos);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DevolucaoItem";
            this.Text = "DevolucaoItem";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DevolucaoItem_Load);
            this.pnlOK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.ListView lsvDocumentos;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader CodigoBarras;
        private System.Windows.Forms.ColumnHeader Descricao;
        private EDL.Controles.BarraInferior barraInferior1;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDevolucao;
    }
}