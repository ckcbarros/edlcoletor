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
    public partial class DevolucaoItem : Form
    {
        private Symbol.Barcode.Reader MyReader = null;
        private Symbol.Barcode.ReaderData MyReaderData = null;

        private System.EventHandler MyEventHandler = null;

        private List<EDLWS.DevolucaoItem> devolucoes = new List<EDLWS.DevolucaoItem>();
        private EDLWS.DevolucaoItem devolucaoItens;

        public DevolucaoItem()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            //TREINAMENTO - SÓ DESCOMENTAR QUANDO FOR FAZER PUBLICAÇÃO PARA TREINAMENTO
            //MessageBox.Show(EDL.Properties.Resources.MSGI002, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            //return;
            //TREINAMENTO - SÓ DESCOMENTAR QUANDO FOR FAZER PUBLICAÇÃO PARA TREINAMENTO

            try
            {
                if (lsvDocumentos.Items.Count == 0)
                    MessageBox.Show(EDL.Properties.Resources.SYS016, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                else
                {
                    AtivaPainelOk(true, "REGISTRANDO...");

                    string retorno = "";

                    using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                    {
                        ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;

                        retorno = ws.RegistrarDevolucao(Program.Devolucao, devolucoes.ToArray(), Program.Usuario.Login);
                    }

                    if (retorno == "")
                    {
                        AtivaPainelOk(false, "");
                        MessageBox.Show(EDL.Properties.Resources.MSGI002, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                        Util.MostraCursor.CursorAguarde(true);

                        timer1.Enabled = false;
                        this.StopRead();

                        Program.FormularioAtivo = "devolucao";
                        this.Close();
                    }
                    else
                    {
                        AtivaPainelOk(false, "");
                        MessageBox.Show(EDL.Properties.Resources.SYS015 + " - " + retorno, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception err)
            {
                AtivaPainelOk(false, "");
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            if (lsvDocumentos.Items.Count == 0 || MessageBox.Show(EDL.Properties.Resources.SYS010, Program.TituloMensagem, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Util.MostraCursor.CursorAguarde(true);

                timer1.Enabled = false;

                this.StopRead();

                Program.FormularioAtivo = "Devolucao";
                this.Close();
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            decimal qtd = Convert.ToDecimal(lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].SubItems[1].Text.Replace(",", "."));

            qtd--;

            if (qtd == 0)
            {
                devolucoes.RemoveAt(lsvDocumentos.FocusedItem.Index);
                lsvDocumentos.Items.Remove(lsvDocumentos.FocusedItem);

            }
            else
            {
                lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].SubItems[1].Text = Util.Numerico.FormataNumero(qtd.ToString(), 4);
            }

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

        private void DevolucaoItem_Load(object sender, EventArgs e)
        {
            try
            {
                this.barraSuperior1.lblTitulo.Text = "DEVOLUÇÃO DE ÍTENS";
                this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

                txtDevolucao.Text = Program.Devolucao.AnoDiadoAno.ToString() + Program.Devolucao.SequencialAnoDiadoAno.ToString() + Program.Devolucao.TipoPedido;
                txtFornecedor.Text = Program.Devolucao.NomeFornecedorJuridico;

                if (this.InitReader())
                    this.StartRead();

                if (this.MyReader == null)
                    if (this.InitReader())
                        this.StartRead();

                timer1.Enabled = true;

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

        #region Código de barras

        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            try
            {
                EncontraProduto(TheReaderData.Text.PadLeft(14, '0'));
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

        #region Métodos

        private void EncontraProduto(string codigoBarras)
        {
            bool achou = false;
            int pos = 0;

            barraInferior1.inputPanel1.Enabled = false;
            
            try
            {
                AtivaPainelOk(true, "PESQUISANDO...");

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    devolucaoItens = new EDL.EDLWS.DevolucaoItem();
                    devolucaoItens = ws.RetornaProdutoDevolucao(codigoBarras, Program.Filial, Program.Devolucao.Id);
                }

                AtivaPainelOk(false, "");

                if (devolucaoItens.Erro != "")
                {
                    MessageBox.Show(devolucaoItens.Erro, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (devolucaoItens.QtdEstoque <= 0)
                    {
                        MessageBox.Show(EDL.Properties.Resources.SYS014.Replace("#", codigoBarras), Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        achou = false;
                        pos = 0;
                        foreach (var item in devolucoes)
                        {
                            if (item.CodigoBarras == codigoBarras)
                            {
                                achou = true;
                                if (item.Quantidade + 1 > item.QtdEstoque)
                                    MessageBox.Show(EDL.Properties.Resources.MSGA008.Replace("#", codigoBarras), Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                else
                                {
                                    item.Quantidade++;
                                    lsvDocumentos.Items[pos].SubItems[1].Text =
                                        Util.Numerico.FormataNumero((Convert.ToDecimal(lsvDocumentos.Items[pos].SubItems[1].Text.Replace(",", ".")) + 1).ToString(), 4);
                                    
                                    lsvDocumentos.Items[pos].Selected = true;
                                    lsvDocumentos.Items[pos].Focused = true;
                                }
                                break;
                            }
                            pos++;
                        }
                        if (!achou)
                        {
                            devolucaoItens.IdDevolucao = Program.Devolucao.Id;
                            devolucaoItens.Quantidade = 1;
                            devolucoes.Add(devolucaoItens);

                            ListViewItem lvi;
                            ListViewItem.ListViewSubItem lvsi;

                            lvi = new ListViewItem();
                            lvi.ImageIndex = 0;
                            lvi.Text = devolucaoItens.CodigoBarras;

                            lvsi = new ListViewItem.ListViewSubItem();
                            lvsi.Text = Util.Numerico.FormataNumero("1", 4);
                            lvi.SubItems.Add(lvsi);

                            lvsi = new ListViewItem.ListViewSubItem();
                            lvsi.Text = devolucaoItens.Descricao;
                            lvi.SubItems.Add(lvsi);

                            lsvDocumentos.Items.Add(lvi);

                            if (lsvDocumentos.Items.Count > 0)
                            {
                                lsvDocumentos.Items[lsvDocumentos.Items.Count-1].Selected = true;
                                lsvDocumentos.Items[lsvDocumentos.Items.Count-1].Focused = true;
                                btnRemover.Enabled = true;
                                btnRemover.Visible = true;
                            }
                        }
                    }
                    btnConfirma.Focus();
                }
            }
            catch (Exception err)
            {
                AtivaPainelOk(false, "");
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void AtivaPainelOk(bool ativa, string mensagem)
        {
            lblMensagem.Text = mensagem;
            pnlOK.Left = 8;
            pnlOK.Top = 55;
            pnlOK.Width = 305;
            pnlOK.Height = 234;
            pnlOK.Visible = ativa;
            pnlOK.Enabled = ativa;
            this.Refresh();
        }

        #endregion

    }
}