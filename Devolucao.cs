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
    public partial class Devolucao : Form
    {
        private EDLWS.Devolucao[] devolucoes;

        public Devolucao()  
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        private void Devolucao_Load(object sender, EventArgs e)
        {
            try
            {
                this.barraSuperior1.lblTitulo.Text = "DEVOLUÇÕES";
                this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    devolucoes = ws.RetornarDevolucao(Program.Filial);
                }

                ListViewItem lvi;
                ListViewItem.ListViewSubItem lvsi;

                foreach (var item in devolucoes.OrderBy(x => x.DataCadastro))
                {
                    lvi = new ListViewItem();
                    lvi.ImageIndex = 0;
                    lvi.Text = item.AnoDiadoAno.ToString() + item.SequencialAnoDiadoAno.ToString() + item.TipoPedido;

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = item.NomeFornecedorJuridico;
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = item.DataCadastro.ToString("dd/MM/yyyy");
                    lvi.SubItems.Add(lvsi);

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = item.Id.ToString();
                    lvi.SubItems.Add(lvsi);

                    lsvDocumentos.Items.Add(lvi);
                }

                if (lsvDocumentos.Items.Count > 0)
                {
                    lsvDocumentos.Items[0].Selected = true;
                    lsvDocumentos.Items[0].Focused = true;
                }

                Util.MostraCursor.CursorAguarde(false);
            }
            catch (Exception err)
            {
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                Program.FormularioAtivo = "Menu";
                this.Close();
            }
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            Program.FormularioAtivo = "menu";
            this.Close();
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                var sel = (from devolucao in devolucoes
                           where devolucao.Id == Convert.ToInt32(lsvDocumentos.Items[lsvDocumentos.FocusedItem.Index].SubItems[3].Text)
                           select devolucao).FirstOrDefault();

                Program.Devolucao = new EDL.EDLWS.Devolucao();
                Program.Devolucao.AnoDiadoAno = sel.AnoDiadoAno;
                Program.Devolucao.CnpjFornecedorJuridico = sel.CnpjFornecedorJuridico;
                Program.Devolucao.DataCadastro = sel.DataCadastro;
                Program.Devolucao.Id = sel.Id;
                Program.Devolucao.IdFornecedorJuridico = sel.IdFornecedorJuridico;
                Program.Devolucao.NomeFornecedorJuridico = sel.NomeFornecedorJuridico;
                Program.Devolucao.SequencialAnoDiadoAno = sel.SequencialAnoDiadoAno;
                Program.Devolucao.TipoPedido = sel.TipoPedido;

                Program.FormularioAtivo = "devolucaoitem";
                this.Close();
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }
    }
}