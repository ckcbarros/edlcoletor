using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EDL
{
    public partial class NFeItens : Form
    {
        private Symbol.Barcode.Reader MyReader = null;
        private Symbol.Barcode.ReaderData MyReaderData = null;

        private System.EventHandler MyEventHandler = null;

        private int? produto;

        public NFeItens()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        #region Eventos

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (lsvDocumentos.Items.Count == 0 || MessageBox.Show(EDL.Properties.Resources.SYS010, Program.TituloMensagem, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (lsvDocumentos.Items.Count > 0)
                    Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, EDL.Properties.Resources.SYS021, Program.Usuario.Login);

                Util.MostraCursor.CursorAguarde(true);

                timer1.Enabled = false;

                this.StopRead();

                Program.FormularioAtivo = "NFe";
                this.Close();
            }
        }

        private void NFeItens_Load(object sender, EventArgs e)
        {
            try
            {
                this.barraSuperior1.lblTitulo.Text = "ENTRADA DE ÍTENS";
                this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

                imageList1.Images.Add(EDL.Properties.Resources.PorAbrir);
                imageList1.Images.Add(EDL.Properties.Resources.Aberto);

                this.txtCNPJFilial.Text = Program.nfe.CnpjDestinatario.ToString(@"00\.000\.000\/0000\-00");
                this.txtCNPJFornecedor.Text = Program.nfe.CnpjEmissor.ToString(@"00\.000\.000\/0000\-00");

                if (this.InitReader())
                    this.StartRead();

                if (this.MyReader == null)
                    if (this.InitReader())
                        this.StartRead();

                ListViewItem lvi;
                ListViewItem.ListViewSubItem lvsi;

                int x = 1;

                foreach (var item in Program.nfe.NotaFiscalEntrada.NotaFiscalEntradaItem)
                {
                    lvi = new ListViewItem();
                    lvi.ImageIndex = 0;
                    lvi.Text = x.ToString();

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = "0";
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = "";
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = item.Descricao.ToString();
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = item.CodigoProduto.ToString();
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = Util.Numerico.FormataNumero(item.ValorUnitario.ToString(), 4);
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = Util.Numerico.FormataNumero((item.ValorUnitario * item.Quantidade).ToString(), 2);
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = item.Quantidade.ToString();
                    lvi.SubItems.Add(lvsi);

                    lsvDocumentos.Items.Add(lvi);

                    x++;
                }

                if (lsvDocumentos.Items.Count > 0)
                {
                    lsvDocumentos.Items[0].Selected = true;
                    lsvDocumentos.Items[0].Focused = true;
                }

                AtivaPainelQtd(false);

                txtQtd.Text = "0";

                timer1.Enabled = true;

                Util.MostraCursor.CursorAguarde(false);
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = false;
                Program.FormularioAtivo = "NFe";
                this.Close();
            }

        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            //TREINAMENTO - SÓ DESCOMENTAR QUANDO FOR FAZER PUBLICAÇÃO PARA TREINAMENTO
            //MessageBox.Show(EDL.Properties.Resources.MSGI001, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //return;
            //TREINAMENTO - SÓ DESCOMENTAR QUANDO FOR FAZER PUBLICAÇÃO PARA TREINAMENTO

            try
            {
                string produtos = "";

                foreach (ListViewItem item in lsvDocumentos.Items)
                {
                    if (item.ImageIndex != 1)
                    {
                        produtos += item.SubItems[4].Text + " ";
                    }
                }

                if (produtos.Trim() == "")
                {
                    AtivaPainelOk(true, "REGISTRANDO...");

                    string retorno = "";

                    using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                    {
                        ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;
                        retorno = ws.RegistraNFe(Program.nfe, Program.Usuario.UsuarioId);
                    }

                    AtivaPainelOk(false, "");

                    if (retorno == "")
                    {
                        MessageBox.Show(EDL.Properties.Resources.MSGI001, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                        Util.MostraCursor.CursorAguarde(true);
                        timer1.Enabled = false;
                        this.StopRead();
                        Program.FormularioAtivo = "NFe";
                        this.Close();
                    }
                    else
                    {
                        Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, EDL.Properties.Resources.SYS007 + " - " + retorno, Program.Usuario.Login);

                        MessageBox.Show(EDL.Properties.Resources.SYS007 + " - " + retorno, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, EDL.Properties.Resources.MSGC001 + " - " + produtos, Program.Usuario.Login);

                    MessageBox.Show(EDL.Properties.Resources.MSGC001, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception err)
            {
                AtivaPainelOk(false, "");
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnOkQtd_Click(object sender, EventArgs e)
        {
            if (MarcaProduto(produto, Convert.ToDecimal(txtQtd.Text.Replace(",", ".")),true))
                AtivaPainelQtd(false);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.MyReaderData != null)
                if (!this.MyReaderData.IsPending)
                    this.StartRead();
        }

        private void txtQtd_GotFocus(object sender, EventArgs e)
        {
            txtQtd.SelectAll();
        }

        private void txtQtd_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtQtd, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.btnOkQtd.Focus();
        }

        private void btnCancelarQtd_Click(object sender, EventArgs e)
        {
            AtivaPainelQtd(false);

            lsvDocumentos.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].ImageIndex = 0;
            lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].SubItems[1].Text = "0";
        }

        private void lsvDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDocumentos.FocusedItem != null)
            {
                btnCancelar.Enabled = true;
            }
        }

        #endregion

        #region Código de barras

        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            int qtd = 0;
            int qtdBipado = 0;

            try
            {
                string codigo = TheReaderData.Text.PadLeft(14, '0');

                // encontra o produto através do código de barras
                produto = (from barras in Program.nfe.NotaFiscalEntrada.CodigosBarra
                           where barras.CodigoBarras == codigo
                           select barras.CodigoProduto).FirstOrDefault();

                // Verifica se o produto já foi bipado
                foreach (ListViewItem item in lsvDocumentos.Items)
                {
                    if (item.SubItems[4].Text == produto.ToString())
                    {
                        qtd++;
                        if (item.ImageIndex == 1)
                            qtdBipado++;

                        item.SubItems[2].Text = codigo;
                    }
                }
                if (qtd > 0 && qtd == qtdBipado)
                {
                    MessageBox.Show(EDL.Properties.Resources.SYS006, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                // Encontra os dados do produto no item da nota de entrada
                if (produto != null)
                {
                    var item = (from produtos in Program.nfe.NotaFiscalEntrada.NotaFiscalEntradaItem
                                where produtos.CodigoProduto == produto
                                select produtos).FirstOrDefault();

                    if (item != null)
                    {
                        if (item.PermiteMultiplicador.ToString() == "S")
                        {
                            this.txtQtd.Text = "0";
                            AtivaPainelQtd(true);
                        }
                        else
                        {
                            MarcaProduto(produto, 1, false);
                        }
                    }
                    else
                    {
                        Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, EDL.Properties.Resources.MSGA002 + "(" + codigo + ")", Program.Usuario.Login);

                        MessageBox.Show(EDL.Properties.Resources.MSGA002, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, EDL.Properties.Resources.MSGA002 + "(" + codigo + ")", Program.Usuario.Login);

                    MessageBox.Show(EDL.Properties.Resources.MSGA002, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
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

        private void AtivaPainelOk(bool ativa, string mensagem)
        {
            lblMensagem.Text = mensagem;
            pnlOK.Left = 8;
            pnlOK.Top = 106;
            pnlOK.Width = 305;
            pnlOK.Height = 183;
            pnlOK.Visible = ativa;
            pnlOK.Enabled = ativa;
            this.Refresh();
        }

        private void AtivaPainelQtd(bool Ativa)
        {
            pnlQtd.Top = 106;
            pnlQtd.Left = 8;
            pnlQtd.Width = 305;
            pnlQtd.Height = 183;

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
                txtQtd.Focus();
            else
                lsvDocumentos.Focus();

            this.Refresh();
        }

        private bool MarcaProduto(int? produto, decimal qtd, bool qtdInformada)
        {
            bool achou = false;
            bool ok = false;
            decimal somar;

            try
            {
                foreach (ListViewItem item in lsvDocumentos.Items)
                {
                    if (item.SubItems[4].Text == produto.ToString() && item.ImageIndex == 0)
                    {
                        achou = true;
                        // Atualiza Quantidade
                        if (qtdInformada)
                        {
                            if (Convert.ToDecimal(item.SubItems[7].Text.Replace(",", ".")) != qtd)
                            {
                                MessageBox.Show(EDL.Properties.Resources.MSGA003, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                ok = false;
                                break;
                            }
                            somar = qtd;
                        }
                        else
                        {
                            somar = Convert.ToDecimal(item.SubItems[1].Text.Replace(",", ".")) + qtd;
                        }

                        item.SubItems[1].Text = Util.Numerico.FormataNumero((somar).ToString(), 4);

                        // Atualiza imagem
                        if (Convert.ToDecimal(item.SubItems[7].Text.Replace(",", ".")) == somar)
                            item.ImageIndex = 1;

                        item.Selected = true;
                        item.Focused = true;
                        ok = true;
                        AtivaPainelOk(true, "OK");
                        Thread.Sleep(400);
                        AtivaPainelOk(false, "");
                        break;
                    }
                }

                if (!achou)
                {
                    MessageBox.Show(EDL.Properties.Resources.MSGA002, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            return ok;
        }

        #endregion

        private void txtQtd_LostFocus(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtQtd.Text) > 9999)
                txtQtd.Text = "0";
        }
    }
}