using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.IO;
using EDL.Util;

namespace EDL
{
    static class Program
    {
        #region Pastas/Arquivos padrão

        public const string PASTA_LOG = "LOG";
        public const string ARQUIVO_CONFIGURACAO = "Configuracao.xml";
		public const string PASTA_LOG2 = "LOG";	
		public const string PASTA_LOG3 = "LOG";	
		public const string PASTA_LOG4 = "LOG";	
		
        #endregion

        #region Mudança de cores dos controles

        public static System.Drawing.Color corAntigaControle;

        //Adiciona os eventos de mudança de cor dos textBox de todas as telas. Este deve ser adicionado no Initialize Components da tela
        internal static void PercorreTodosCampos(Form frm)
        {
            foreach (Control ctrl in frm.Controls)
            {
                if (ctrl is Panel)
                {
                    foreach (Control ctrlPanel in ctrl.Controls)
                    {
                        if (ctrlPanel is Panel)
                        {
                            foreach (Control ctrlPanel2 in ctrlPanel.Controls)
                            {
                                if (ctrlPanel2 is TextBox) MudaTextBox(ctrlPanel2);
                                if (ctrlPanel2 is Button) MudaButton(ctrlPanel2);
                            }
                        }
                        if (ctrlPanel is TextBox) MudaTextBox(ctrlPanel);
                        if (ctrlPanel is Button) MudaButton(ctrlPanel);
                    }
                }
                if (ctrl is TextBox) MudaTextBox(ctrl);
                if (ctrl is Button) MudaButton(ctrl);
            }

            frm.KeyDown += new KeyEventHandler(controles_acaoTecla);
        }

        private static void MudaTextBox(Control ctrl)
        {
            TextBox txtbox = (TextBox)(ctrl);
            txtbox.GotFocus += new EventHandler(txtBox_focusOn);
            txtbox.LostFocus += new EventHandler(txtBox_focusOff);
        }

        private static void MudaButton(Control ctrl)
        {
            Button btn = (Button)(ctrl);
            btn.GotFocus += new EventHandler(btn_focusOn);
            btn.LostFocus += new EventHandler(btn_focusOff);
        }

        private static void txtBox_focusOn(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            corAntigaControle = txtbox.BackColor;
            txtbox.BackColor = System.Drawing.Color.LightBlue;
        }

        private static void txtBox_focusOff(object sender, EventArgs e)
        {
            TextBox txtbox = (TextBox)sender;
            txtbox.BackColor = corAntigaControle;
        }

        private static void btn_focusOn(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            corAntigaControle = btn.BackColor;
            btn.BackColor = System.Drawing.Color.LightBlue;
        }

        private static void btn_focusOff(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = corAntigaControle;
        }

        private static void controles_acaoTecla(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                // System.Windows.Forms.
            }
        }

        #endregion

        #region Formulario de Controle

        //Declara janela de fundo para mudança de telas
        internal static Form fundo = new Fundo();

        #endregion

        #region Propriedades, Variáveis e Objetos globais genéricos

        /// <summary>
        /// Guarda o retorno do leitor
        /// </summary>
        internal static string RetornoLeitor { get; set; }

        /// <summary>
        /// Definição de propriedades comuns a todas as janelas do sistema
        /// Define qual janela que será aberta no início da aplicação, ou 
        /// Define qual janela será aberta após a janela ativa ser fechada
        /// </summary>
        internal static string FormularioAtivo { get; set; }

        /// <summary>
        /// Define quando o sistema irá funcionar on-line ou off-line
        /// </summary>
        internal static Dominio.Enumeradores.Enum.TipoSinal OnLine { get; set; }

        /// <summary>
        /// Guarda quando o sistema foi ativado
        /// </summary>
        internal static DateTime DataHora { get; set; }

        /// <summary>
        /// Definição das propriedades necessárias para o controle do operador
        /// </summary>
        internal static EDLWS.Usuario Usuario { get; set; }

        /// <summary>
        /// Dados da nota fiscal eletrônica
        /// </summary>
        internal static EDLWS.Nfe nfe { get; set; }

        /// <summary>
        /// Dados do fornecedor 
        /// </summary>
        internal static EDLWS.FornecedorNotaManual FornecedorNotaManual { get; set; }

        /// <summary>
        /// Dados dos itens do pedido
        /// </summary>
        internal static EDLWS.Pedido Pedido { get; set; }

        /// <summary>
        /// Chave primária do pedido
        /// </summary>
        internal static int DataJuliana { get; set; }

        /// <summary>
        /// Chave primária do pedido
        /// </summary>
        internal static int SequenciaJuliana { get; set; }

        /// <summary>
        /// Título que será exibido nas mensagens do sistema
        /// </summary>
        internal static string TituloMensagem { get; set; }

        /// <summary>
        /// Dados de devolução
        /// </summary>
        internal static EDLWS.Devolucao Devolucao { get; set; }

        /// <summary>
        /// Define se o usuário logou para acessar as configurações
        /// </summary>
        internal static bool UsuarioAutenticado { get; set; }

        /// <summary>
        /// Indica se é romaneio
        /// </summary>
        internal static bool Romaneio { get; set; }

        /// <summary>
        /// Indica qual a filial
        /// </summary>
        internal static int Filial { get; set; }

        /// <summary>
        /// Indica qual a filial
        /// </summary>
        internal static string UsaSAP { get; set; }

        #endregion

        #region Configuracao

        //Cria arquivo de configuração padrão
        private static void CriaConfiguracao()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode raiz = doc.CreateElement("Configuracao");
            doc.AppendChild(raiz);

            //---- WEBSERVICES -----------------------------------------------------------------------------------------------------
            //Sincronizacao
            XmlNode urlSincronizacao = doc.CreateElement("urlSincronizacao");
            //urlSincronizacao.InnerText = "http://172.16.41.110/edl_web/ws/edlws.asmx";
            urlSincronizacao.InnerText = "http://192.168.0.157:8088/ws/edlws.asmx";
            //urlSincronizacao.InnerText = "http://192.168.0.97:8088/ws/edlws.asmx";
            doc.SelectSingleNode("/Configuracao").AppendChild(urlSincronizacao);

            //---- FILIAL ----------------------------------------------------------------------------------------------------------
            //XmlNode codFilial = doc.CreateElement("codFilial");
            //codFilial.InnerText = "86";
            //doc.SelectSingleNode("/Configuracao").AppendChild(codFilial);

            //Salva arquivo
            doc.Save(Util.PastaSistema.AppPath() + "\\" + ARQUIVO_CONFIGURACAO);

            //---- LIMPEZA DOS OBJETOS ---------------------------------------------------------------------------------------------
            urlSincronizacao = null;
            doc = null;
            raiz = null;
        }

        #endregion

        #region Thread de Atualizacao do Sinal e Nivel de Bateria

        static Thread pTask = null;
        public static bool ThreadAtiva = false;

        private static void PingTask()
        {
            while (ThreadAtiva)
            {
                try
                {
                    EDL.EDLWS.EDLWS conexao = new EDL.EDLWS.EDLWS();
                    conexao.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    conexao.Timeout = 999999;

                    if (conexao.VerificaConexao() == "OK")
                    {
                        OnLine = EDL.Dominio.Enumeradores.Enum.TipoSinal.ON;
                    }
                    else
                    {
                        OnLine = EDL.Dominio.Enumeradores.Enum.TipoSinal.OFF;
                    }

                    conexao = null;
                }
                catch (Exception)
                {
                    OnLine = EDL.Dominio.Enumeradores.Enum.TipoSinal.OFF;
                }

                //Aguardar proxima atualizacao 10 em 10 segundos
                Thread.Sleep(10000);
            }
        }

        public static bool CriaThread()
        {
            try
            {
                pTask = new Thread(new ThreadStart(PingTask));
                pTask.IsBackground = true;
                pTask.Priority = ThreadPriority.Lowest;
                ThreadAtiva = true;
                pTask.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Capturar Excecoes nao tratadas

        /// <summary>
        /// This event provides notification of uncaught exceptions. It allows the application to log information 
        /// about the exception before the system default handler reports the exception to the user and terminates the application.
        /// If sufficient information about the state of the application is available, other actions may be undertaken — such as saving
        /// program data for later recovery. Caution is advised, because program data can become corrupted when exceptions are not handled.
        /// http://msdn.microsoft.com/en-us/library/system.appdomain.unhandledexception.aspx
        /// Fabricio - 14/02/2010 - 16:11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (e.ExceptionObject as Exception);
            Util.LogErro.GravaLog("Um erro fatal ocorreu no programa e o mesmo será finalizado.\r\nVeja o log de erros para maiores detalhes.", ex.Message);
            Util.LogErro.GravaStackTrace(ex);
            Application.Exit();
        }

        #endregion

        #region Inicio do Sistema

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                string versaoNova = "";
                string versaoAtual = "";

                //Capturando todas as excecoes nao tratadas
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                // Verifica se o arquivo de configuração existe
                if (!File.Exists(Util.PastaSistema.AppPath() + "\\" + ARQUIVO_CONFIGURACAO))
                    CriaConfiguracao();

                //Diretorio onde é montada a estrutura de arquivos
                string diretorio_raiz = Util.PastaSistema.AppPath();

                //Log do sistema
                if (!Directory.Exists(diretorio_raiz + PASTA_LOG))
                    Directory.CreateDirectory(diretorio_raiz + PASTA_LOG);

                //Thread para Atualizacao do nivel de bateria do coletor e informar se esta online ou offline
                CriaThread();

                Program.OnLine = EDL.Dominio.Enumeradores.Enum.TipoSinal.OFF;

                Program.TituloMensagem = "EDL";

                try
                {
                    //Verifica versão do coletor
                    using (EDLWS.EDLWS ws = new EDLWS.EDLWS())
                    {
                        ws.Url = LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;

                        var obj = ws.VerificaConexao();

                        Program.UsaSAP = ws.RetornaFluxoSAP("COLETOREDL");

                        versaoNova = ws.RetornaVersaoEDLColetor();
                        versaoAtual = Util.Versao.VersaoColetor().Replace("Versão ", "");
                    }

                    if (versaoAtual == versaoNova)
                    {
                        //Abre janela de fundo fixo
                        if (File.Exists(Util.PastaSistema.AppPath() + "\\" + ARQUIVO_CONFIGURACAO))
                        {
                            fundo.ShowDialog();     // Primeira janela do sistema
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível encontrar o arquivo de configuração do sistema!", Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        fundo.Close();
                        fundo.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("A versão do coletor é a " + versaoAtual + ", mas é necessário atualizar para a versão " + versaoNova + ". Iniciando processo de atualização, aguarde...", Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        System.Diagnostics.Process.Start(PastaSistema.AppPath() + "EDLAtualizaVersao.exe", "");
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(EDL.Properties.Resources.SYS998 + " - " + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                pTask.Abort();
                pTask = null;
            }
            catch
            {
            }

        #endregion

        }
    }
}