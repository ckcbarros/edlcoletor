using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace EDL
{
    public partial class Login : Form
    {
        private Symbol.Barcode.Reader MyReader = null;
        private Symbol.Barcode.ReaderData MyReaderData = null;

        private System.EventHandler MyEventHandler = null;

        private string Cracha;

        public Login()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
            pictureBox1.Image = EDL.Properties.Resources.fundologin;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = EDL.Properties.Resources.fundologin;
            picTeclado.Image = EDL.Properties.Resources.Key;
            picConfiguracao.Image = EDL.Properties.Resources.Control_panel2;

            txtSenha.Enabled = false;
            txtSenha.Visible = false;
            lblSenha.Visible = false;
            btnEntrar.Enabled = false;
            btnEntrar.Visible = false;

            if (this.InitReader())
                this.StartRead();

            if (this.MyReader == null)
                if (this.InitReader())
                    this.StartRead();

            timer1.Enabled = true;
            Util.MostraCursor.CursorAguarde(false);

            CultureInfo ci = CultureInfo.CurrentCulture;
            if (ci.LCID != 1033)
                MessageBox.Show("O formato numério está incorreto nas configurações do sistema. Solicite ao suporte para efetuar a configuração correta!");
            ci = null;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            //Desativa teclado virtual, caso esteja ativo
            this.inputPanel1.Enabled = false;
            this.timer1.Enabled = false;

            Util.MostraCursor.CursorAguarde(true);
            
            this.StopRead();
            
            Program.FormularioAtivo = "";
            this.Close();
        }

        private void picTeclado_Click(object sender, EventArgs e)
        {
            this.inputPanel1.Enabled = (!this.inputPanel1.Enabled);
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(27))
                btnSair_Click(sender, e);
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.btnEntrar.Focus();
        }

        private void txtSenha_GotFocus(object sender, EventArgs e)
        {
            this.txtSenha.SelectAll();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string versaoAtualizador = "";

            try
            {
                if (Cracha == String.Empty)
                {
                    MessageBox.Show(EDL.Properties.Resources.SYS001, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (txtSenha.Text.Trim() == String.Empty)
                {
                    MessageBox.Show(EDL.Properties.Resources.SYS002, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtSenha.Focus();
                    return;
                }

                // QUANDO ATUALIZAR VERSAO DO APP DE ATUALIZACAO, MUDAR O NOME ABAIXO PARA A NOVA VERSAO E ALTERAR TAMBEM A VALIDACAO NO SISTEMA DE ATUALIZACAO
                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;
                    versaoAtualizador = ws.RetornaVersaoEDLAtualizaVersao();
                    versaoAtualizador = "ATUALIZADOR_" + versaoAtualizador.Replace(".", "") + ".TXT";
                }

                if (!File.Exists(Util.PastaSistema.AppPath() + versaoAtualizador))
                {
                    if (MessageBox.Show(EDL.Properties.Resources.SYS024, Program.TituloMensagem, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        picConfiguracao_Click(sender, e);
                        return;
                    }
                }

                //Desativa teclado virtual, caso esteja ativo
                this.inputPanel1.Enabled = false;

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    Util.MostraCursor.CursorAguarde(true);

                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    EDLWS.Usuario usuario = new EDL.EDLWS.Usuario();
                    usuario = ws.AutenticarUsuarioComIp(Convert.ToInt32(Cracha), Util.HashMD5.GeraHashMD5(txtSenha.Text), Util.Coletor.IPColetor());
                    
                    Program.Usuario = usuario;

                    Util.MostraCursor.CursorAguarde(false);

                    if (usuario.Erro != "")
                    {
                        MessageBox.Show(usuario.Erro, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        lblSenha.Visible = false;
                        txtSenha.Visible = false;
                        txtSenha.Enabled = false;
                        btnEntrar.Visible = false;
                        btnEntrar.Enabled = false;
                    }
                    else
                    {
                        Util.MostraCursor.CursorAguarde(true);

                        Util.DataHora.AcertaDataHora(usuario.DataHora);

                        this.timer1.Enabled = false;

                        this.StopRead();

                        Program.Filial = usuario.Filial;

                        Program.FormularioAtivo = "Menu";
                        this.Close();
                    }
                }
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS998 + " - " + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);                
            }
        }

        #region Código de barras

        private void HandleData(Symbol.Barcode.ReaderData TheReaderData)
        {
            Cracha = TheReaderData.Text;
            
            txtSenha.Enabled = true;
            txtSenha.Visible = true;
            lblSenha.Visible = true;
            btnEntrar.Visible = true;
            btnEntrar.Enabled = true;
            txtSenha.Text = "";
            txtSenha.Focus();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.MyReaderData != null)
                if (!this.MyReaderData.IsPending)
                    this.StartRead();
        }

        private void picConfiguracao_Click(object sender, EventArgs e)
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                this.timer1.Enabled = false;
                this.StopRead();

                Program.UsuarioAutenticado = true;
                Program.FormularioAtivo = "configuracao";
                this.Close();
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + " - " + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);                
            }
        }
    }
}