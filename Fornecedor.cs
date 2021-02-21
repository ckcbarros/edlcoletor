using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EDL
{
    public partial class Fornecedor : Form
    {
        private Symbol.Barcode.Reader MyReader = null;
        private Symbol.Barcode.ReaderData MyReaderData = null;

        private System.EventHandler MyEventHandler = null;

        public Fornecedor()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        #region Eventos

        private void txtFornecedor_TextChanged(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtFornecedor_GotFocus(object sender, EventArgs e)
        {
            txtFornecedor.SelectAll();
        }

        private void txtFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtFornecedor, e, false);
            if (e.KeyChar == Convert.ToChar(13))
            {
                btnConfirma.Enabled = true;
                btnConfirma.Visible = true;
                btnConfirma.Focus();
            }
        }

        private void Fornecedor_Load(object sender, EventArgs e)
        {
            this.barraSuperior1.lblTitulo.Text = "FORNECEDOR";
            this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

            btnConfirma.Enabled = false;
            btnConfirma.Visible = false;

            if (this.InitReader())
                this.StartRead();

            if (this.MyReader == null)
                if (this.InitReader())
                    this.StartRead();

            Util.MostraCursor.CursorAguarde(false);

            this.txtFornecedor.Focus(); 
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            timer1.Enabled = false;
            this.StopRead();

            Program.FormularioAtivo = "NFe";
            this.Close();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            if (txtFornecedor.Text.Trim()!="")
                BuscaFornecedor(txtFornecedor.Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.MyReaderData != null)
                if (!this.MyReaderData.IsPending)
                    this.StartRead();
        }

        #endregion

        #region Métodos

        private void BuscaFornecedor(string fornecedor)
        {
            try
            {
                if (fornecedor!="")
                {
                    Util.MostraCursor.CursorAguarde(true);

                    barraInferior1.inputPanel1.Enabled = false;

                    using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                    {
                        ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;

                        Program.FornecedorNotaManual = new EDL.EDLWS.FornecedorNotaManual();
                        Program.FornecedorNotaManual = ws.RetornaFornecedor(Convert.ToInt32(fornecedor), Program.Filial);
                    }

                    Program.FornecedorNotaManual.Fornecedor = Convert.ToInt32(fornecedor);
                    Program.FornecedorNotaManual.Filial = Program.Filial;
                    
                    Util.MostraCursor.CursorAguarde(false);

                    if (Program.FornecedorNotaManual.Erro != "")
                    {
                        Util.LogRecusaNF.CriaRecusaSemNFe(2, Program.FornecedorNotaManual.Filial, Program.FornecedorNotaManual.Fornecedor, 0, "", Program.FornecedorNotaManual.Erro + " (" + Program.FornecedorNotaManual.Fornecedor.ToString() + ")", Program.Usuario.Login);

                        MessageBox.Show(Program.FornecedorNotaManual.Erro, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        btnCancela.Focus();
                    }
                    else
                    {
                        // Se for nota fiscal manual
                        if (Program.FornecedorNotaManual.Recebimento == 1)
                        {
                            Util.LogRecusaNF.CriaRecusaSemNFe(2, Program.FornecedorNotaManual.Filial, Program.FornecedorNotaManual.Fornecedor, 0, "", EDL.Properties.Resources.MSGE005 + " (" + Program.FornecedorNotaManual.Fornecedor.ToString() + ")", Program.Usuario.Login);
                            
                            MessageBox.Show(EDL.Properties.Resources.MSGE005, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        else if (Program.FornecedorNotaManual.ValidaPedido == 1 && Program.FornecedorNotaManual.PedidoFornecedor.Count() == 0)
                        {
                            Util.LogRecusaNF.CriaRecusaSemNFe(2, Program.FornecedorNotaManual.Filial, Program.FornecedorNotaManual.Fornecedor, 0, "", EDL.Properties.Resources.MSGE007 + " (" + Program.FornecedorNotaManual.Fornecedor.ToString() + ")", Program.Usuario.Login);

                            MessageBox.Show(EDL.Properties.Resources.MSGE007, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        else if (Program.FornecedorNotaManual.ValidaPedido == 1 && Program.FornecedorNotaManual.PedidoFornecedor.Count() > 0)
                        {
                            Util.MostraCursor.CursorAguarde(true);
                            this.StopRead();
                            Program.FormularioAtivo = "PEDIDOS";
                            this.Close();
                        }
                        else
                        {
                            Util.MostraCursor.CursorAguarde(true);
                            this.StopRead();
                            if (Program.FornecedorNotaManual.Recebimento == 2)
                                Program.FormularioAtivo = "NFMANUAL";
                            else
                                Program.FormularioAtivo = "ROMANEIO";
                            this.Close();
                        }
                    }
                }
                else
                {
                    this.txtFornecedor.Text = "";
                    this.txtFornecedorBipado.Text = "";

                    btnCancela.Focus();
                }
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion
        
        #region Código de barras

        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            if (TheReaderData.Text.Length <= 6)
            {
                txtFornecedorBipado.Text = TheReaderData.Text;
                this.Refresh();

                BuscaFornecedor(TheReaderData.Text);
            }
            else
            {
                MessageBox.Show(EDL.Properties.Resources.SYS022, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }

        }

        private bool InitReader()
        {
            // If reader is already present then fail initialize
            if (this.MyReader != null)
            {
                return false;
            }

            // Create new reader, first available reader will be used.
            this.MyReader = new Symbol.Barcode.Reader();

            // Create reader data
            this.MyReaderData = new Symbol.Barcode.ReaderData(
                Symbol.Barcode.ReaderDataTypes.Text,
                Symbol.Barcode.ReaderDataLengths.MaximumLabel);

            // Create event handler delegate
            this.MyEventHandler = new EventHandler(MyReader_ReadNotify);

            // Enable reader, with wait cursor
            this.MyReader.Actions.Enable();

            //this.MyReader.Parameters.Feedback.Success.BeepTime = 2;

            // Attach to activate and deactivate events
            this.Activated += new EventHandler(ReaderForm_Activated);
            this.Deactivate += new EventHandler(ReaderForm_Deactivate);

            return true;
        }

        /// <summary>
        /// Start a read on the reader
        /// </summary>
        private void StartRead()
        {
            // If we have both a reader and a reader data
            if ((this.MyReader != null) &&
                (this.MyReaderData != null))
            {
                // Submit a read
                this.MyReader.ReadNotify += this.MyEventHandler;
                this.MyReader.Actions.Read(this.MyReaderData);
            }
        }

        /// <summary>
        /// Stop all reads on the reader
        /// </summary>
        private void StopRead()
        {
            // If we have a reader
            if (this.MyReader != null)
            {
                // Flush (Cancel all pending reads)
                this.MyReader.ReadNotify -= this.MyEventHandler;
                this.MyReader.Actions.Flush();
                this.MyReader.Dispose();
                this.MyReaderData.Dispose();
                this.MyReader = null;
                this.MyReaderData = null;
            }
        }

        /// <summary>
        /// Read complete or failure notification
        /// </summary>
        private void MyReader_ReadNotify(object sender, EventArgs e)
        {
            Symbol.Barcode.ReaderData TheReaderData = this.MyReader.GetNextReaderData();

            // If it is a successful read (as opposed to a failed one)
            if (TheReaderData.Result == Symbol.Results.SUCCESS)
            {
                // Handle the data from this read
                this.HandleData(TheReaderData);

                // Start the next read
                if (this.MyReaderData != null)
                    if (!this.MyReaderData.IsPending)
                        this.StartRead();
                //this.StartRead();
            }
        }

        /// <summary>
        ///  Handler for when the form is actived.  This would occur when this application becomes the current
        ///  application
        /// </summary>
        private void ReaderForm_Activated(object sender, EventArgs e)
        {
            // If there are no reads pending on MyReader start a new read
            if (this.MyReaderData != null)
                if (!this.MyReaderData.IsPending)
                    this.StartRead();
        }

        /// <summary>
        ///  Handler for when the form is deactivated.  This would be called if another application became the current
        ///  application. This stops the reading of data from the reader.
        /// </summary>
        private void ReaderForm_Deactivate(object sender, EventArgs e)
        {
            //this.StopRead();
        }

        #endregion

    }
}