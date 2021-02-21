using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using EDL.EDLWS;

namespace EDL
{
    public partial class NFManualItens : Form
    {
        private Symbol.Barcode.Reader MyReader = null;
        private Symbol.Barcode.ReaderData MyReaderData = null;

        private System.EventHandler MyEventHandler = null;
        
        private decimal valorTotal = 0;

        private List<NegociacaoProduto> NegociacaoProduto = new List<NegociacaoProduto>();
        private NegociacaoProduto negociacao;

        public NFManualItens()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (lsvDocumentos.Items.Count == 0 || MessageBox.Show(EDL.Properties.Resources.SYS010, Program.TituloMensagem, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Util.MostraCursor.CursorAguarde(true);

                timer1.Enabled = false;

                this.StopRead();

                Program.FormularioAtivo = "fornecedor";
                this.Close();
            }
        }

        private void NFManualItens_Load(object sender, EventArgs e)
        {
            try
            {
                this.barraSuperior1.lblTitulo.Text = "ENTRADA DE ÍTENS";
                this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

                if (this.InitReader())
                    this.StartRead();

                if (this.MyReader == null)
                    if (this.InitReader())
                        this.StartRead();

                AtivaPainelQtd(false);

                timer1.Enabled = true;
                
                txtQtd.Text = "0";
                txtValorTotalNota.Text = Util.Numerico.FormataNumero("0", 2);

                btnRemover.Enabled = false;
                btnRemover.Visible = false;

                Util.MostraCursor.CursorAguarde(false);
            }
            catch (Exception err)
            {
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = false;
                Program.FormularioAtivo = "NFManual";
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.MyReaderData != null)
                if (!this.MyReaderData.IsPending)
                    this.StartRead();
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtQtd, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.btnOkQtd.Focus();
        }

        private void btnOkQtd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtQtd.Text) > 0)
                {
                    decimal valor = 0;

                    Util.MostraCursor.CursorAguarde(true);

                    ListViewItem lvi;
                    ListViewItem.ListViewSubItem lvsi;

                    lvi = new ListViewItem();
                    lvi.ImageIndex = 0;
                    lvi.Text = "";

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = txtQtd.Text;
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = negociacao.CodigoBarras;
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = negociacao.Descricao;
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = negociacao.ValorUnitario.ToString();
                    lvi.SubItems.Add(lvsi);

                    valor = negociacao.ValorUnitario * Convert.ToDecimal(txtQtd.Text);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = valor.ToString();
                    lvi.SubItems.Add(lvsi);

                    valorTotal += valor;

                    txtValorTotalNota.Text = Util.Numerico.FormataNumero(valorTotal.ToString(), 2);
                    Program.FornecedorNotaManual.ValorTotal = Convert.ToDecimal(txtValorTotalNota.Text.Replace(",", "."));

                    lsvDocumentos.Items.Add(lvi);

                    if (lsvDocumentos.Items.Count > 0)
                    {
                        lsvDocumentos.Items[lsvDocumentos.Items.Count-1].Selected = true;
                        lsvDocumentos.Items[lsvDocumentos.Items.Count-1].Focused = true;
                        btnRemover.Enabled = true;
                        btnRemover.Visible = true;
                    }

                    negociacao.Quantidade = Convert.ToDecimal(txtQtd.Text.Replace(",", "."));
                    NegociacaoProduto.Add(negociacao);

                    AcertaSequencia();

                    Util.MostraCursor.CursorAguarde(false);

                    btnConfirma.Focus();
                    AtivaPainelQtd(false);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            valorTotal -= Convert.ToDecimal(lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].SubItems[5].Text);

            txtValorTotalNota.Text = Util.Numerico.FormataNumero(valorTotal.ToString(), 2);
            Program.FornecedorNotaManual.ValorTotal = Convert.ToDecimal(txtValorTotalNota.Text.Replace(",", "."));

            NegociacaoProduto.RemoveAt(lsvDocumentos.FocusedItem.Index);
            lsvDocumentos.Items.Remove(lsvDocumentos.FocusedItem);

            AcertaSequencia();

            if (lsvDocumentos.Items.Count == 0)
            {
                btnConfirma.Focus();
                btnRemover.Enabled = false;
                btnRemover.Visible = false;
            }
            else
            {
                lsvDocumentos.Items[0].Selected = true;
                lsvDocumentos.Items[0].Focused = true;
            }
        }

        private void txtQtd_GotFocus(object sender, EventArgs e)
        {
            txtQtd.SelectAll();
        }

        private void btnCancelarQtd_Click(object sender, EventArgs e)
        {
            AtivaPainelQtd(false);
            btnConfirma.Focus();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            //TREINAMENTO - SÓ DESCOMENTAR QUANDO FOR FAZER PUBLICAÇÃO PARA TREINAMENTO
            //MessageBox.Show(EDL.Properties.Resources.MSGI001, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //return;
            //TREINAMENTO - SÓ DESCOMENTAR QUANDO FOR FAZER PUBLICAÇÃO PARA TREINAMENTO

            try
            {
                if (Program.FornecedorNotaManual.Recebimento == 2 && Convert.ToDecimal(txtValorTotalNota.Text.Replace(",", ".")) < Program.FornecedorNotaManual.ValorInformado)
                {
                    Util.LogRecusaNF.CriaRecusaSemNFe(2, Program.FornecedorNotaManual.Filial, Program.FornecedorNotaManual.Fornecedor, Program.FornecedorNotaManual.Numero, Program.FornecedorNotaManual.Serie, EDL.Properties.Resources.SYS011, Program.Usuario.Login);

                    MessageBox.Show(EDL.Properties.Resources.SYS011, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    AtivaPainelOk(true, "REGISTRANDO...");

                    EDLWS.NotaFiscalManual nota = new NotaFiscalManual();
                    string retorno;

                    using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                    {
                        ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;

                        nota.FornecedorNotaManual = Program.FornecedorNotaManual;
                        nota.NegociacaoProduto = NegociacaoProduto.ToArray();
                        
                        if (Program.FornecedorNotaManual.Recebimento == 2)
                            retorno = ws.RegistraNFManual(nota, Program.Usuario.UsuarioId);
                        else
                            retorno = ws.RegistraRomaneio(nota, Program.Usuario.UsuarioId, Program.Usuario.Login);
                    }

                    if (retorno == "")
                    {
                        AtivaPainelOk(false,"");
                        MessageBox.Show(EDL.Properties.Resources.MSGI001, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                        Util.MostraCursor.CursorAguarde(true);

                        timer1.Enabled = false;
                        this.StopRead();

                        Program.FormularioAtivo = "fornecedor";
                        this.Close();
                    }
                    else
                    {
                        AtivaPainelOk(false,"");
                        Util.LogRecusaNF.CriaRecusaSemNFe(2, Program.FornecedorNotaManual.Filial, Program.FornecedorNotaManual.Fornecedor, Program.FornecedorNotaManual.Numero, Program.FornecedorNotaManual.Serie, EDL.Properties.Resources.SYS007, Program.Usuario.Login);

                        MessageBox.Show(EDL.Properties.Resources.SYS007 + " - " + retorno, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception err)
            {
                AtivaPainelOk(false,"");
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        #region Código de barras

        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            try
            {
                EncontraProduto(TheReaderData.Text.PadLeft(14,'0'));
            }
            catch (Exception err)
            {
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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

        #region MÉTODOS

        private void EncontraProduto(string codigoBarras)
        {
            barraInferior1.inputPanel1.Enabled = false;

            try
            {
                AtivaPainelOk(true,"PESQUISANDO...");

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    negociacao = new EDL.EDLWS.NegociacaoProduto();

                    if (Program.FornecedorNotaManual.Recebimento == 3)
                        negociacao = ws.RetornaProdutoRomaneio(codigoBarras, Program.FornecedorNotaManual.Fornecedor, Program.Filial);
                    else
                        negociacao = ws.RetornaProduto(codigoBarras, Program.FornecedorNotaManual.Fornecedor, Program.Filial);
                }

                AtivaPainelOk(false,"");

                if (negociacao.Erro != "")
                {
                    Util.LogRecusaNF.CriaRecusaSemNFe(2, Program.FornecedorNotaManual.Filial, Program.FornecedorNotaManual.Fornecedor, Program.FornecedorNotaManual.Numero, Program.FornecedorNotaManual.Serie, negociacao.Erro, Program.Usuario.Login);

                    MessageBox.Show(negociacao.Erro, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    AtivaPainelQtd(true);
                }
            }
            catch (Exception err)
            {
                AtivaPainelOk(false,"");
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void AtivaPainelOk(bool ativa, string mensagem)
        {
            lblMensagem.Text = mensagem;
            pnlOK.Left = 8;
            pnlOK.Top = 60;
            pnlOK.Width = 305;
            pnlOK.Height = 229;
            pnlOK.Visible = ativa;
            pnlOK.Enabled = ativa;
            this.Refresh();
        }

        private void AtivaPainelQtd(bool Ativa)
        {
            pnlQtd.Top = 60;
            pnlQtd.Left = 8;
            pnlQtd.Width = 305;
            pnlQtd.Height = 229;

            pnlQtd.Enabled = Ativa;
            pnlQtd.Visible = Ativa;
            txtQtd.Enabled = Ativa;
            txtQtd.Visible = Ativa;
            btnOkQtd.Enabled = Ativa;
            btnOkQtd.Visible = Ativa;
            btnCancelarQtd.Enabled = Ativa;
            btnCancelarQtd.Visible = Ativa;

            lsvDocumentos.Enabled = !Ativa;
            btnConfirma.Enabled = !Ativa;
            btnVoltar.Enabled = !Ativa;

            if (Ativa)
            {
                timer1.Enabled = false;
                this.StopRead();

                txtQtd.Text = "0";
                txtQtd.Focus();
            }
            else
            {
                timer1.Enabled = true;

                if (this.InitReader())
                    this.StartRead();

                if (this.MyReader == null)
                    if (this.InitReader())
                        this.StartRead();

                lsvDocumentos.Focus();
            }
            this.Refresh();
        }

        private void AcertaSequencia()
        {
            int x = 1;
            foreach (ListViewItem item in lsvDocumentos.Items)
            {
                item.Text = (x++).ToString();
            }
        }

        #endregion

        private void txtQtd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQtd_LostFocus(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQtd.Text) > 9999)
                txtQtd.Text = "0";
        }

    }
}