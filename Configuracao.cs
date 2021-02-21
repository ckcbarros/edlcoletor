using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EDL.Util;
using System.IO;
using System.Threading;

namespace EDL
{
    public partial class Configuracao : Form
    {
        public Configuracao()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        private void Configuracao_Load(object sender, EventArgs e)
        {
            barraSuperior1.lblTitulo.Text = "CONFIGURAÇÃO";

            txtWebService.Text = Util.LerGravarXML.ObterValor("urlSincronizacao");
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            Program.FormularioAtivo = "login";
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Util.LerGravarXML.GravarValor("urlSincronizacao", txtWebService.Text);
            MessageBox.Show("Salvo com sucesso!");
        }

        private void txtWebService_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.btnSalvar.Focus();
        }

        private void txtWebService_GotFocus(object sender, EventArgs e)
        {
            txtWebService.SelectAll();
        }

        private void btnAtualizarApp_Click(object sender, EventArgs e)
        {
            string Name = PastaSistema.AppPath() + "EDLAtualizaVersao.exe";
            string NameOld = PastaSistema.AppPath() + "EDLAtualizaVersao.old";
            string CaminhoRestore = @"\Application\RemCapture\EDL\";
            string NameRestore = CaminhoRestore + "EDLAtualizaVersao.exe";
            string erro = "Não foi possível baixar nova versão do servidor.";
            string versaoAtualizador = "";

            bool ok = true;

            try
            {
                AtivaPainelOk(true, "Buscando nova versão do aplicativo de atualização de versões, aguarde...");
                Util.MostraCursor.CursorAguarde(true);

                byte[] arquivo;

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;
                    var versao = new EDLWS.VersaoEDL();

                    while (true)
                    {
                        versao = ws.EnviaAtualizadorNovo();
                        if (versao.Aplicativo.Length != versao.Tamanho)
                        {
                            Util.MostraCursor.CursorAguarde(false);
                            if (MessageBox.Show("A conexão foi interrompida antes que a nova versão fosse totalmente copiada. Deseja realizar uma nova tentativa?"
                                , "Erro!"
                                , MessageBoxButtons.YesNo
                                , MessageBoxIcon.Question
                                , MessageBoxDefaultButton.Button1) == DialogResult.No)
                            {
                                AtivaPainelOk(false, "");
                                return;
                            }
                            this.Refresh();
                            Util.MostraCursor.CursorAguarde(true);
                        }
                        else
                        {
                            arquivo = versao.Aplicativo;
                            break;
                        }
                    }
                }
                this.Refresh();

                erro = "Não foi possível renomear versão antiga para copiar a nova.";

                if (File.Exists(Name))
                {
                    if (File.Exists(NameOld))
                        File.Delete(NameOld);

                    File.Move(Name, NameOld);

                    File.Delete(Name);
                }

                erro = "Não foi possível substituir a versão antiga pela nova versão.";

                using (BinaryWriter Writer = new BinaryWriter(File.OpenWrite(Name)))
                {
                    Writer.Write(arquivo);
                    Writer.Flush();
                }
                Thread.Sleep(3000);

                try
                {
                    erro = "Nova versão copiada com sucesso, entretanto não foi possível copiar a nova versão para a área de recuperação do coletor.";

                    using (BinaryWriter Writer = new BinaryWriter(File.OpenWrite(NameRestore)))
                    {
                        Writer.Write(arquivo);
                        Writer.Flush();
                    }
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    ok = false;
                    MessageBox.Show(erro + " " + ex.Message);
                }

                if (ok)
                {
                    // QUANDO ATUALIZAR VERSAO DO APP DE ATUALIZACAO, MUDAR O NOME ABAIXO PARA A NOVA VERSAO E ALTERAR TAMBEM A VALIDACAO NA ENTRADA DO SISTEMA
                    using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                    {
                        ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;
                        versaoAtualizador = ws.RetornaVersaoEDLAtualizaVersao();
                        versaoAtualizador = "ATUALIZADOR_" + versaoAtualizador.Replace(".", "") + ".TXT";
                    }
                    StreamWriter atualizou = new StreamWriter(Util.PastaSistema.AppPath() + versaoAtualizador, true, System.Text.Encoding.Default);
                    atualizou.Close();
                    StreamWriter restore = new StreamWriter(CaminhoRestore + versaoAtualizador, true, System.Text.Encoding.Default);
                    restore.Close();
                }

                AtivaPainelOk(false, "");
                Util.MostraCursor.CursorAguarde(false);

                MessageBox.Show("Finalizado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
            }
            catch (Exception ex)
            {
                Util.MostraCursor.CursorAguarde(false);
                AtivaPainelOk(false, "");
                MessageBox.Show(erro + " " + ex.Message);
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

    }
}