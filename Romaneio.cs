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
    public partial class Romaneio : Form
    {
        private Symbol.Barcode.Reader MyReader = null;
        private Symbol.Barcode.ReaderData MyReaderData = null;

        private System.EventHandler MyEventHandler = null;

        public Romaneio()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        private void dtpEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.btnConfirma.Focus();
        }

        private void Romaneio_Load(object sender, EventArgs e)
        {
            try
            {
                this.barraSuperior1.lblTitulo.Text = "DADOS DO ROMANEIO";
                this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

                if (this.InitReader())
                    this.StartRead();

                if (this.MyReader == null)
                    if (this.InitReader())
                        this.StartRead();

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    var ret = ws.RetornaFornecedorJuridicoControladora(Program.FornecedorNotaManual.Fornecedor);

                    ListViewItem lvi;
                    ListViewItem.ListViewSubItem lvsi;

                    foreach (var item in ret)
                    {
                        lvi = new ListViewItem();
                        lvi.Text = item.id.ToString();

                        lvsi = new ListViewItem.ListViewSubItem();
                        lvsi.Text = item.cnpj;
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem();
                        lvsi.Text = item.razao;
                        lvi.SubItems.Add(lvsi);

                        lvsi = new ListViewItem.ListViewSubItem();
                        lvsi.Text = item.fantasia;
                        lvi.SubItems.Add(lvsi);

                        lsvDocumentos.Items.Add(lvi);
                    }

                    if (lsvDocumentos.Items.Count > 0)
                    {
                        lsvDocumentos.Items[0].Selected = true;
                        lsvDocumentos.Items[0].Focused = true;
                    }
                }

                txtFilial.Text = Program.FornecedorNotaManual.CNPJFilial;

                timer1.Enabled = true;

                Util.MostraCursor.CursorAguarde(false);
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = false;
                Program.FormularioAtivo = "fornecedor";
                this.Close();
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            SelecionaFornecedor();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            timer1.Enabled = false;

            this.StopRead();

            Program.FormularioAtivo = "fornecedor";
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.MyReaderData != null)
                if (!this.MyReaderData.IsPending)
                    this.StartRead();
        }

        #region Código de barras

        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            bool ok = false;

            string codigo = Convert.ToInt32(TheReaderData.Text).ToString(@"000\.000\.000\/0000\-00");

            foreach (ListViewItem item in lsvDocumentos.Items)
            {
                if (item.SubItems[1].Text == codigo)
                {
                    lsvDocumentos.Items[item.Index].Selected = true;
                    lsvDocumentos.Items[item.Index].Focused = true;

                    ok=true;

                    SelecionaFornecedor();
                    break;
                }
            }
            if (!ok)
                MessageBox.Show(EDL.Properties.Resources.MSGE006, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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

        #region Métodos

        private void SelecionaFornecedor()
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    Program.FornecedorNotaManual.FornecedorJuridico = ws.RetornaFornecedorJuridico(lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].SubItems[1].Text);
                }

                if (Program.FornecedorNotaManual.FornecedorJuridico != 0)
                {
                    Program.FornecedorNotaManual.CNPJFornecedorJuridico = lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].SubItems[1].Text;
                    Program.FornecedorNotaManual.CNPJFilial = this.txtFilial.Text;
                    Program.FornecedorNotaManual.DataEmissao = dtpEmissao.Value;

                    timer1.Enabled = false;
                    this.StopRead();

                    if (Program.FornecedorNotaManual.ValidaPedido == 1)
                        Program.FormularioAtivo = "PedidosItens";
                    else
                        Program.FormularioAtivo = "NFManualItens";
                    this.Close();
                }
                else
                {
                    Util.MostraCursor.CursorAguarde(false);
                    MessageBox.Show(EDL.Properties.Resources.MSGE006, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion
    }
}