namespace EDL
{
    partial class Pedidos
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
            this.lsvDocumentos = new System.Windows.Forms.ListView();
            this.DataJuliana = new System.Windows.Forms.ColumnHeader();
            this.Seq = new System.Windows.Forms.ColumnHeader();
            this.Data = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.btnConfirma = new System.Windows.Forms.Button();
            this.barraInferior1 = new EDL.Controles.BarraInferior();
            this.barraSuperior1 = new EDL.Controles.BarraSuperior();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // btnCancela
            // 
            this.btnCancela.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancela.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancela.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancela.Location = new System.Drawing.Point(223, 254);
            this.btnCancela.Name = "btnCancela";
            this.btnCancela.Size = new System.Drawing.Size(90, 35);
            this.btnCancela.TabIndex = 2;
            this.btnCancela.Text = "VOLTAR";
            this.btnCancela.Click += new System.EventHandler(this.btnCancela_Click);
            // 
            // lsvDocumentos
            // 
            this.lsvDocumentos.BackColor = System.Drawing.Color.White;
            this.lsvDocumentos.Columns.Add(this.DataJuliana);
            this.lsvDocumentos.Columns.Add(this.Seq);
            this.lsvDocumentos.Columns.Add(this.Data);
            this.lsvDocumentos.ForeColor = System.Drawing.Color.Black;
            this.lsvDocumentos.FullRowSelect = true;
            this.lsvDocumentos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvDocumentos.Location = new System.Drawing.Point(8, 106);
            this.lsvDocumentos.Name = "lsvDocumentos";
            this.lsvDocumentos.Size = new System.Drawing.Size(305, 142);
            this.lsvDocumentos.TabIndex = 0;
            this.lsvDocumentos.View = System.Windows.Forms.View.Details;
            // 
            // DataJuliana
            // 
            this.DataJuliana.Text = "Pedido";
            this.DataJuliana.Width = 100;
            // 
            // Seq
            // 
            this.Seq.Text = "Seq";
            this.Seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Seq.Width = 60;
            // 
            // Data
            // 
            this.Data.Text = "Data";
            this.Data.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Data.Width = 120;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 16);
            this.label2.Text = "FORNECEDOR";
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.BackColor = System.Drawing.Color.Gainsboro;
            this.txtFornecedor.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.txtFornecedor.ForeColor = System.Drawing.Color.Black;
            this.txtFornecedor.Location = new System.Drawing.Point(8, 76);
            this.txtFornecedor.MaxLength = 18;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(305, 24);
            this.txtFornecedor.TabIndex = 31;
            // 
            // btnConfirma
            // 
            this.btnConfirma.BackColor = System.Drawing.Color.Gainsboro;
            this.btnConfirma.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirma.ForeColor = System.Drawing.Color.Black;
            this.btnConfirma.Location = new System.Drawing.Point(117, 254);
            this.btnConfirma.Name = "btnConfirma";
            this.btnConfirma.Size = new System.Drawing.Size(100, 35);
            this.btnConfirma.TabIndex = 1;
            this.btnConfirma.Text = "CONFIRMAR";
            this.btnConfirma.Click += new System.EventHandler(this.btnConfirma_Click);
            // 
            // barraInferior1
            // 
            this.barraInferior1.Location = new System.Drawing.Point(0, 295);
            this.barraInferior1.Name = "barraInferior1";
            this.barraInferior1.Size = new System.Drawing.Size(325, 30);
            this.barraInferior1.TabIndex = 28;
            // 
            // barraSuperior1
            // 
            this.barraSuperior1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barraSuperior1.Location = new System.Drawing.Point(0, 0);
            this.barraSuperior1.Name = "barraSuperior1";
            this.barraSuperior1.Size = new System.Drawing.Size(325, 54);
            this.barraSuperior1.TabIndex = 27;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(325, 325);
            this.ControlBox = false;
            this.Controls.Add(this.btnConfirma);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFornecedor);
            this.Controls.Add(this.lsvDocumentos);
            this.Controls.Add(this.barraInferior1);
            this.Controls.Add(this.barraSuperior1);
            this.Controls.Add(this.btnCancela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pedidos";
            this.Text = "Pedidos";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Pedidos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EDL.Controles.BarraInferior barraInferior1;
        private EDL.Controles.BarraSuperior barraSuperior1;
        private System.Windows.Forms.Button btnCancela;
        private System.Windows.Forms.ListView lsvDocumentos;
        private System.Windows.Forms.ColumnHeader DataJuliana;
        private System.Windows.Forms.ColumnHeader Seq;
        private System.Windows.Forms.ColumnHeader Data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Button btnConfirma;
        private System.Windows.Forms.Timer timer1;
    }
}