using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace EDL
{
    public partial class Fundo : Form
    {
        StreamWriter aberto;

        public Fundo()
        {
            InitializeComponent();
        }

        private void Fundo_Load(object sender, EventArgs e)
        {
            //Abre arquivo texto como exclusivo para impedir que o programa seja executado mais de uma vez ao mesmo tempo
            try
            {
                aberto = new StreamWriter(Util.PastaSistema.AppPath() + "EDL.TXT", true, System.Text.Encoding.Default);

            }
            catch (Exception ex)
            {
                Util.LogErro.GravaLog("Não foi possível abrir o sistema ou ele já está sendo executado!", ex.Message);
                this.Close();
            }

            //O sistema cria um arquivo de log por dia e apaga o do dia posterior. Ou seja, ele terá
            //sempre os logs dos 30/31 últimos dias
            String arquivo = Util.PastaSistema.AppPath() + Program.PASTA_LOG + "\\LOG" + (System.DateTime.Now.Day + 1) + ".txt";
            if (File.Exists(arquivo)) File.Delete(arquivo);

            //Ativar timer para abrir a primeira janela do sistema
            timer1.Enabled = true;

            //Versão do sistema
            lblVersao.Text = Util.Versao.VersaoColetor();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Desativa o timer de ativação das janelas
            this.timer1.Enabled = false;

            //Indica qual a janela a ser aberta
            Program.FormularioAtivo = "Login";

            Util.MostraCursor.CursorAguarde(false);

            //Seleção das janelas possíveis de uso
            while (true)
            {
                //Mostra nome do operador/técnico
                if (Program.FormularioAtivo.ToUpper() == "LOGIN" || Program.FormularioAtivo.ToUpper() == "CONFIGURACAO")
                    lblMensagem.Text = "AGUARDE...";
                else
                    lblMensagem.Text = Program.Usuario.Nome.Substring(0, Program.Usuario.Nome.IndexOf(' ')) + ", AGUARDE...";

                switch (Program.FormularioAtivo.ToUpper())
                {
                    case "LOGIN":
                        Login login = new Login();
                        login.ShowDialog();
                        login.Dispose();
                        this.Refresh();
                        break;
                    case "CONFIGURACAO":
                        Configuracao configuracao = new Configuracao();
                        configuracao.ShowDialog();
                        configuracao.Dispose();
                        this.Refresh();
                        break;
                    case "MENU":
                        Menu mnu = new Menu();
                        mnu.ShowDialog();
                        mnu.Dispose();
                        this.Refresh();
                        break;
                    case "NFE":
                        NFe nfe = new NFe();
                        nfe.ShowDialog();
                        nfe.Dispose();
                        this.Refresh();
                        break;
                    case "NFEITENS":
                        NFeItens nfeItens = new NFeItens();
                        nfeItens.ShowDialog();
                        nfeItens.Dispose();
                        this.Refresh();
                        break;
                    case "FORNECEDOR":
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor.ShowDialog();
                        fornecedor.Dispose();
                        this.Refresh();
                        break;
                    case "NFMANUAL":
                        NFManual nfmanual = new NFManual();
                        nfmanual.ShowDialog();
                        nfmanual.Dispose();
                        this.Refresh();
                        break;
                    case "NFMANUALITENS":
                        NFManualItens nfManualItens = new NFManualItens();
                        nfManualItens.ShowDialog();
                        nfManualItens.Dispose();
                        this.Refresh();
                        break;
                    case "PEDIDOS":
                        Pedidos pedidos = new Pedidos();
                        pedidos.ShowDialog();
                        pedidos.Dispose();
                        this.Refresh();
                        break;
                    case "PEDIDOSITENS":
                        PedidosItens pedidosItens = new PedidosItens();
                        pedidosItens.ShowDialog();
                        pedidosItens.Dispose();
                        this.Refresh();
                        break;
                    case "DEVOLUCAO":
                        Devolucao devolucao = new Devolucao();
                        devolucao.ShowDialog();
                        devolucao.Dispose();
                        this.Refresh();
                        break;
                    case "DEVOLUCAOITEM":
                        DevolucaoItem devolucaoItem = new DevolucaoItem();
                        devolucaoItem.ShowDialog();
                        devolucaoItem.Dispose();
                        this.Refresh();
                        break;
                    case "ROMANEIO":
                        Romaneio romaneio = new Romaneio();
                        romaneio.ShowDialog();
                        romaneio.Dispose();
                        this.Refresh();
                        break;
                    default:
                        break;
                }

                //A propriedade deve retornar vazia para encerramento do sistema
                if (Program.FormularioAtivo == "")
                {
                    Util.MostraCursor.CursorAguarde(false);
                    aberto.Close();
                    aberto.Dispose();
                    timer1.Enabled = false;
                    this.Close();
                    break;
                }
            }
        }
    }
}