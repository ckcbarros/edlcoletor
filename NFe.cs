using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EDL.EDLWS;

namespace EDL
{
    public partial class NFe : Form
    {
        private Symbol.Barcode.Reader MyReader = null;
        private Symbol.Barcode.ReaderData MyReaderData = null;
		
		public const string PASTA_LOG2 = "LOG";	
		public const string PASTA_LOG3 = "LOG";	
		
        private System.EventHandler MyEventHandler = null;

        public NFe()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        #region Eventos

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            string chaveAcesso = txtNFe1.Text.Trim()
                + txtNFe2.Text.Trim()
                + txtNFe3.Text.Trim()
                + txtNFe4.Text.Trim()
                + txtNFe5.Text.Trim()
                + txtNFe6.Text.Trim()
                + txtNFe7.Text.Trim()
                + txtNFe8.Text.Trim()
                + txtNFe9.Text.Trim()
                + txtNFe10.Text.Trim()
                + txtNFe11.Text.Trim();

            if (chaveAcesso.Trim().Length < 44)
            {
                MessageBox.Show(EDL.Properties.Resources.SYS005, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            BuscaNFe(chaveAcesso);
        }

        private void NFe_Load(object sender, EventArgs e)
        {
            this.barraSuperior1.lblTitulo.Text = "NF-e";
            this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

            btnConfirma.Enabled = false;
            btnConfirma.Visible = false;

            btnSemNfe.Enabled = !(Program.UsaSAP == "S");
            btnSemNfe.Visible = !(Program.UsaSAP == "S");

            if (this.InitReader())
                this.StartRead();

            if (this.MyReader == null)
                if (this.InitReader())
                    this.StartRead();

            timer1.Enabled = true;

            Util.MostraCursor.CursorAguarde(false);

            btnCancela.Focus();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            timer1.Enabled = false;
            this.StopRead();

            Program.FormularioAtivo = "Menu";
            this.Close();
        }

        private void btnSemNfe_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            timer1.Enabled = false;
            this.StopRead();

            Program.FormularioAtivo = "Fornecedor";
            this.Close();
        }

        private void txtNFe1_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe1.Text.Length >= 4)
                txtNFe2.Focus();
        }

        private void txtNFe1_GotFocus(object sender, EventArgs e)
        {
            txtNFe1.SelectAll();
        }

        private void txtNFe2_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe2.Text.Length >= 4)
                txtNFe3.Focus();
        }

        private void txtNFe3_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe3.Text.Length >= 4)
                txtNFe4.Focus();
        }

        private void txtNFe4_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe4.Text.Length >= 4)
                txtNFe5.Focus();
        }

        private void txtNFe5_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe5.Text.Length >= 4)
                txtNFe6.Focus();
        }

        private void txtNFe6_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe6.Text.Length >= 4)
                txtNFe7.Focus();
        }

        private void txtNFe7_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe7.Text.Length >= 4)
                txtNFe8.Focus();
        }

        private void txtNFe8_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe8.Text.Length >= 4)
                txtNFe9.Focus();
        }

        private void txtNFe9_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe9.Text.Length >= 4)
                txtNFe10.Focus();
        }

        private void txtNFe10_TextChanged(object sender, EventArgs e)
        {
            if (txtNFe10.Text.Length >= 4)
                txtNFe11.Focus();
        }

        private void txtNFe10_GotFocus(object sender, EventArgs e)
        {
            txtNFe10.SelectAll();
        }

        private void txtNFe2_GotFocus(object sender, EventArgs e)
        {
            txtNFe2.SelectAll();
        }

        private void txtNFe3_GotFocus(object sender, EventArgs e)
        {
            txtNFe3.SelectAll();
        }

        private void txtNFe4_GotFocus(object sender, EventArgs e)
        {
            txtNFe4.SelectAll();
        }

        private void txtNFe5_GotFocus(object sender, EventArgs e)
        {
            txtNFe5.SelectAll();
        }

        private void txtNFe6_GotFocus(object sender, EventArgs e)
        {
            txtNFe6.SelectAll();
        }

        private void txtNFe7_GotFocus(object sender, EventArgs e)
        {
            txtNFe7.SelectAll();
        }

        private void txtNFe8_GotFocus(object sender, EventArgs e)
        {
            txtNFe8.SelectAll();
        }

        private void txtNFe9_GotFocus(object sender, EventArgs e)
        {
            txtNFe9.SelectAll();
        }

        private void txtNFe11_GotFocus(object sender, EventArgs e)
        {
            txtNFe11.SelectAll();
        }

        private void txtNFe1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe2.Focus();
        }

        private void txtNFe2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe3.Focus();
        }

        private void txtNFe3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe4.Focus();
        }

        private void txtNFe4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe5.Focus();
        }

        private void txtNFe5_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe6.Focus();
        }

        private void txtNFe6_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe7.Focus();
        }

        private void txtNFe7_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe8.Focus();
        }

        private void txtNFe8_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe9.Focus();
        }

        private void txtNFe9_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe10.Focus();
        }

        private void txtNFe10_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13)) this.txtNFe11.Focus();
        }

        private void txtNFe11_KeyPress(object sender, KeyPressEventArgs e)
        {
            Util.Numerico.FiltraNumero(ref txtNFe1, e, false);
            if (e.KeyChar == Convert.ToChar(13))
            {
                btnConfirma.Enabled = true;
                btnConfirma.Visible = true;
                btnConfirma.Focus();
            }
        }

        private void NFe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(27))
                btnCancela_Click(sender, e);
        }

        private void txtNFe11_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe1_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe2_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe3_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe4_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe5_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe6_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe7_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe8_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe9_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void txtNFe10_LostFocus(object sender, EventArgs e)
        {
            btnConfirma.Enabled = true;
            btnConfirma.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.MyReaderData != null)
                if (!this.MyReaderData.IsPending)
                    this.StartRead();
        }

        #endregion

        #region Métodos

        private void BuscaNFe(string chaveAcesso)
        {
            try
            {
                if (chaveAcesso.Length == 44)
                {
                    Util.MostraCursor.CursorAguarde(true);

                    barraInferior1.inputPanel1.Enabled = false;

                    using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                    {
                        ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;
                        Program.nfe = new EDL.EDLWS.Nfe();
                        Program.nfe = ws.RetornaNFe(chaveAcesso);
                        
                        #region DownloadNFe
                        //Roberto Almeida em 20/07/2017 - Colocado a opção de realizar o Download da NFe se o XML bipado não foi encontrado
                        if (Program.nfe.TemXML == false && Program.nfe.Erro.Contains("O XML da Nota fiscal não foi encontrado no Sistema"))
                        {
                            AtivaPainelOk(true,"Fazendo o download do XML da Nota Fiscal, aguarde...");
                            try
                            {
                                DownloadXMlNFe download = ws.RealizarDownloadNFePorLoja(chaveAcesso, Program.Filial);
                                if (download.DownloadOK)
                                {
                                    Util.MostraCursor.CursorAguarde(false);
                                    MessageBox.Show(EDL.Properties.Resources.MSGI003, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                    AtivaPainelOk(false, "");
                                    return;
                                }
                            }
                            catch
                            {
                            }
                            AtivaPainelOk(false, "");
                        }
                        #endregion
                    }

                    Util.MostraCursor.CursorAguarde(false);
                    if (Program.nfe.Situacao == "B" || Program.nfe.Situacao == "D")
                    {
                        barraInferior1.inputPanel1.Enabled = false;

                        Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, (Program.nfe.Situacao == "D" ? EDL.Properties.Resources.SYS019 : EDL.Properties.Resources.SYS020), Program.Usuario.Login);

                        Util.MostraCursor.CursorAguarde(true);

                        Divergencias form = new Divergencias();

                        form.Ocorrencias = Program.nfe.Divergencias;
                        form.ShowDialog();
                        form.Dispose();
                        form = null;

                        return;
                    };
                    if (Program.nfe.Situacao == "R")
                    {
                        MessageBox.Show(EDL.Properties.Resources.SYS003, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                    if (Program.nfe.Erro != "")
                    {
                        this.picOk.Image = EDL.Properties.Resources.button_cancel;

                        Util.LogRecusaNF.CriaRecusaNFe(1, Program.Filial, "", chaveAcesso + ": " + EDL.Properties.Resources.MSGE004, Program.Usuario.Login);

                        MessageBox.Show(Program.nfe.Erro, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                        btnCancela.Focus();
                    }
                    else
                    {
                        if (Program.nfe.Mensagem != "")
                            MessageBox.Show(Program.nfe.Mensagem, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                        if (Program.nfe.Filial != Program.Filial)
                        {
                            Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, EDL.Properties.Resources.MSGE002 + " " + Program.nfe.Filial + " " + Program.nfe.FilialNome, Program.Usuario.Login);
                            
                            MessageBox.Show(EDL.Properties.Resources.MSGE002 + " " + Program.nfe.Filial + " " + Program.nfe.FilialNome, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        if (Program.nfe.Situacao != "L")
                        {
                            Util.LogRecusaNF.CriaRecusaNFe(1, Program.nfe.Filial, Program.nfe.ChaveAcessoNfe, EDL.Properties.Resources.SYS023 + " " + Program.nfe.Filial + " " + Program.nfe.FilialNome, Program.Usuario.Login);

                            MessageBox.Show(EDL.Properties.Resources.SYS023, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }

                        Util.MostraCursor.CursorAguarde(true);

                        if (txtNFe1.Text.Trim() != "")
                        {
                            this.picOk.Image = EDL.Properties.Resources.button_ok;
                        }
                        this.Refresh();

                        timer1.Enabled = false;
                        this.StopRead();

                        Program.RetornoLeitor = chaveAcesso;
                        Program.FormularioAtivo = "NFeItens";
                        this.Close();
                    }
                }
                else
                {
                    this.txtNFe1.Text = "";
                    this.txtNFe2.Text = "";
                    this.txtNFe3.Text = "";
                    this.txtNFe4.Text = "";
                    this.txtNFe5.Text = "";
                    this.txtNFe6.Text = "";
                    this.txtNFe7.Text = "";
                    this.txtNFe8.Text = "";
                    this.txtNFe9.Text = "";
                    this.txtNFe10.Text = "";
                    this.txtNFe11.Text = "";

                    this.txtNFe.Text = "";

                    btnCancela.Focus();

                    this.picOk.Image = EDL.Properties.Resources.button_cancel;
                }
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }

        }

        private void AtivaPainelOk(bool ativa, string mensagem)
        {
            lblMensagem.Text = mensagem;
            pnlOK.Left = 8;
            pnlOK.Top = 57;
            pnlOK.Width = 314;
            pnlOK.Height = 232;
            pnlOK.Visible = ativa;
            pnlOK.Enabled = ativa;
            this.Refresh();
        }

        #endregion

        #region Código de barras

        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            txtNFe.Text = TheReaderData.Text;

            this.Refresh();

            BuscaNFe(TheReaderData.Text);
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