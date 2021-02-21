namespace EDL
{
    partial class NFManualItens
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
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.lsvDocumentos = new System.Windows.Forms.ListView();
            this.Sequencia = new System.Windows.Forms.ColumnHeader();
            this.Quantidade = new System.Windows.Forms.ColumnHeader();
            this.Produto = new System.Windows.Forms.ColumnHeader();
            this.Descricao = new System.Windows.Forms.ColumnHeader();
            this.PrecoUnitario = new System.Windows.Forms.ColumnHeader();
            this.PrecoTotal = new System.Windows.Forms.ColumnHeader();
            this.pnlQtd = new System.Windows.Forms.Panel();
            this.txtQtd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancelarQtd = new System.Windows.Forms.Button();
            this.btnOkQtd = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.txtValorTotalNota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemover = new System.Windows.Forms.Button();
            this.pnlOK = new System.Windows.Forms.Panel();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.pnlQtd.SuspendLayout();
            this.pnlOK.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnVoltar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVoltar.Location = new System.Drawing.Point(223, 254);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(90, 35);
            this.btnVoltar.TabIndex = 31;
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
            this.btnConfirma.TabIndex = 29;
            this.btnConfirma.Text = "CONFIRMAR";
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // lsvDocumentos
            // 
            this.lsvDocumentos.BackColor = System.Drawing.Color.White;
            this.lsvDocumentos.Columns.Add(this.Sequencia);
            this.lsvDocumentos.Columns.Add(this.Quantidade);
            this.lsvDocumentos.Columns.Add(this.Produto);
            this.lsvDocumentos.Columns.Add(this.Descricao);
            this.lsvDocumentos.Columns.Add(this.PrecoUnitario);
            this.lsvDocumentos.Columns.Add(this.PrecoTotal);
            this.lsvDocumentos.ForeColor = System.Drawing.Color.Black;
            this.lsvDocumentos.FullRowSelect = true;
            this.lsvDocumentos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvDocumentos.Location = new System.Drawing.Point(8, 60);
            this.lsvDocumentos.Name = "lsvDocumentos";
            this.lsvDocumentos.Size = new System.Drawing.Size(305, 158);
            this.lsvDocumentos.TabIndex = 27;
            this.lsvDocumentos.View = System.Windows.Forms.View.Details;
            // 
            // Sequencia
            // 
            this.Sequencia.Text = "#";
            this.Sequencia.Width = 30;
            // 
            // Quantidade
            // 
            this.Quantidade.Text = "Qtd";
            this.Quantidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Quantidade.Width = 80;
            // 
            // Produto
            // 
            this.Produto.Text = "Produto";
            this.Produto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Produto.Width = 90;
            // 
            // Descricao
            // 
            this.Descricao.Text = "Descrição";
            this.Descricao.Width = 200;
            // 
            // PrecoUnitario
            // 
            this.PrecoUnitario.Text = "Preço Unitário";
            this.PrecoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PrecoUnitario.Width = 90;
            // 
            // PrecoTotal
            // 
            this.PrecoTotal.Text = "Preço Total";
            this.PrecoTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PrecoTotal.Width = 90;
            // 
            // pnlQtd
            // 
            this.pnlQtd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.pnlQtd.Controls.Add(this.txtQtd);
            this.pnlQtd.Controls.Add(this.label3);
            this.pnlQtd.Controls.Add(this.btnCancelarQtd);
            this.pnlQtd.Controls.Add(this.btnOkQtd);
            this.pnlQtd.Enabled = false;
            this.pnlQtd.Location = new System.Drawing.Point(319, 80);
            this.pnlQtd.Name = "pnlQtd";
            this.pnlQtd.Size = new System.Drawing.Size(71, 46);
            this.pnlQtd.Visible = false;
            // 
            // txtQtd
            // 
            this.txtQtd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtQtd.Location = new System.Drawing.Point(0, 34);
            this.txtQtd.MaxLength = 7;
            this.txtQtd.Name = "txtQtd";
            this.txtQtd.Size = new System.Drawing.Size(69, 26);
            this.txtQtd.TabIndex = 3;
            this.txtQtd.TextChanged += new System.EventHandler(this.txtQtd_TextChanged);
            this.txtQtd.GotFocus += new System.EventHandler(this.txtQtd_GotFocus);
            this.txtQtd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQtd_KeyPress);
            this.txtQtd.LostFocus += new System.EventHandler(this.txtQtd_LostFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(0, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 22);
            this.label3.Text = "INFORME A QUANTIDADE DO PRODUTO:";
            // 
            // btnCancelarQtd
            // 
            this.btnCancelarQtd.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelarQtd.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelarQtd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarQtd.Location = new System.Drawing.Point(119, 34);
            this.btnCancelarQtd.Name = "btnCancelarQtd";
            this.btnCancelarQtd.Size = new System.Drawing.Size(90, 26);
            this.btnCancelarQtd.TabIndex = 5;
            this.btnCancelarQtd.Text = "CANCELAR";
            this.btnCancelarQtd.Click += new System.EventHandler(this.btnCancelarQtd_Click);
            // 
            // btnOkQtd
            // 
            this.btnOkQtd.BackColor = System.Drawing.Color.Gainsboro;
            this.btnOkQtd.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnOkQtd.ForeColor = System.Drawing.Color.Black;
            this.btnOkQtd.Location = new System.Drawing.Point(75, 34);
            this.btnOkQtd.Name = "btnOkQtd";
            this.btnOkQtd.Size = new System.Drawing.Size(36, 26);
            this.btnOkQtd.TabIndex = 4;
            this.btnOkQtd.Text = "OK";
            this.btnOkQtd.Click += new System.EventHandler(this.btnOkQtd_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtValorTotalNota
            // 
            this.txtValorTotalNota.BackColor = System.Drawing.Color.Gainsboro;
            this.txtValorTotalNota.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txtValorTotalNota.ForeColor = System.Drawing.Color.Black;
            this.txtValorTotalNota.Location = new System.Drawing.Point(206, 224);
            this.txtValorTotalNota.MaxLength = 18;
            this.txtValorTotalNota.Name = "txtValorTotalNota";
            this.txtValorTotalNota.ReadOnly = true;
            this.txtValorTotalNota.Size = new System.Drawing.Size(107, 24);
            this.txtValorTotalNota.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(94, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.Text = "VALOR TOTAL";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.Gainsboro;
            this.btnRemover.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnRemover.ForeColor = System.Drawing.Color.Black;
            this.btnRemover.Location = new System.Drawing.Point(8, 254);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(90, 35);
            this.btnRemover.TabIndex = 40;
            this.btnRemover.Text = "REMOVER";
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
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
            // barraInferior1
            // 
            this.barraInferior1.Location = new System.Drawing.Point(0, 295);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(325, 30);
            this.barraInferior1.TabIndex = 36;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 35;
            // 
            // NFManualItens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.pnlOK);
            this.Controls.Add(this.pnlQtd);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValorTotalNota);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.lsvDocumentos);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NFManualItens";
            this.Text = "NFManualItens";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.NFManualItens_Load);
            this.pnlQtd.ResumeLayout(false);
            this.pnlOK.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.ListView lsvDocumentos;
        private System.Windows.Forms.ColumnHeader Sequencia;
        private System.Windows.Forms.ColumnHeader Quantidade;
        private System.Windows.Forms.ColumnHeader Produto;
        private System.Windows.Forms.ColumnHeader Descricao;
        private System.Windows.Forms.ColumnHeader PrecoUnitario;
        private System.Windows.Forms.ColumnHeader PrecoTotal;
        private EDL.Controles.BarraInferior barraInferior1;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Panel pnlQtd;
        private System.Windows.Forms.TextBox txtQtd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelarQtd;
        private System.Windows.Forms.Button btnOkQtd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtValorTotalNota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Panel pnlOK;
        private System.Windows.Forms.Label lblMensagem;
    }
}