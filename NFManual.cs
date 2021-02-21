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
    public partial class NFManual : Form
    {
        public NFManual()
        {
            InitializeComponent();
            Program.PercorreTodosCampos(this);
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            Util.MostraCursor.CursorAguarde(true);

            Program.FormularioAtivo = "fornecedor";
            this.Close();
        }

        private void txtValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.btnConfirma.Focus();
            Util.Numerico.FiltraNumero(ref txtValorTotal, e, true);
        }

        private void txtValorTotal_GotFocus(object sender, EventArgs e)
        {
            txtValorTotal.SelectAll();
        }

        private void NFManual_Load(object sender, EventArgs e)
        {
            this.barraSuperior1.lblTitulo.Text = "DADOS DA NOTA";
            this.barraInferior1.Top = this.barraInferior1.Top - (325 - Screen.PrimaryScreen.Bounds.Height);

            txtFilial.Text = Program.FornecedorNotaManual.CNPJFilial;
            txtValorTotal.Text = Util.Numerico.FormataNumero("0", 2);

            Util.MostraCursor.CursorAguarde(false);
        }

        private void txtValorTotal_LostFocus(object sender, EventArgs e)
        {
            txtValorTotal.Text = Util.Numerico.FormataNumero(txtValorTotal.Text, 2);
        }

        private void txtFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.txtNF.Focus();
            Util.Numerico.FiltraNumero(ref txtFornecedor, e, true);
        }

        private void txtNF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.txtSerie.Focus();
            Util.Numerico.FiltraNumero(ref txtNF, e, true);
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.dtpEmissao.Focus();
        }

        private void dtpEmissao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13)) this.txtValorTotal.Focus();
        }

        private void txtFornecedor_LostFocus(object sender, EventArgs e)
        {
            if (txtFornecedor.Text.Length < 14 && txtFornecedor.Text.Trim() != "")
                txtFornecedor.Text = txtFornecedor.Text.PadLeft(14, '0');
            if (txtFornecedor.Text.Trim().Length == 14)
                txtFornecedor.Text = String.Format(@"{0:00\.000\.000\/0000\-00}", Convert.ToDouble(txtFornecedor.Text));
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFornecedor.Text.Trim() == "" ||
                    txtNF.Text.Trim() == "" ||
                    txtSerie.Text.Trim() == "" ||
                    Convert.ToDecimal(txtValorTotal.Text) == 0)
                {
                    MessageBox.Show(EDL.Properties.Resources.SYS009, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Util.MostraCursor.CursorAguarde(true);

                    using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                    {
                        ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                        ws.Timeout = 999999;

                        Program.FornecedorNotaManual.FornecedorJuridico = ws.RetornaFornecedorJuridico(txtFornecedor.Text);
                    }

                    if (Program.FornecedorNotaManual.FornecedorJuridico != 0)
                    {
                        Program.FornecedorNotaManual.CNPJFornecedorJuridico = txtFornecedor.Text;
                        Program.FornecedorNotaManual.CNPJFilial = this.txtFilial.Text;
                        Program.FornecedorNotaManual.DataEmissao = dtpEmissao.Value;
                        Program.FornecedorNotaManual.Numero = Convert.ToInt32(txtNF.Text);
                        Program.FornecedorNotaManual.Serie = txtSerie.Text;
                        Program.FornecedorNotaManual.ValorInformado = Convert.ToDecimal(txtValorTotal.Text.Replace(",", "."));

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
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        private void txtFornecedor_GotFocus(object sender, EventArgs e)
        {
            txtFornecedor.SelectAll();
        }

        private void txtNF_GotFocus(object sender, EventArgs e)
        {
            txtNF.SelectAll();
        }

        private void txtSerie_GotFocus(object sender, EventArgs e)
        {
            txtSerie.SelectAll();
        }

    }
}