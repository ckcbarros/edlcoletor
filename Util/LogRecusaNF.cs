using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EDL.Util
{
    public static class LogRecusaNF
    {
        public static void CriaRecusaNFe(int tipoRecebimento, int filial, string chaveAcesso, string motivo, string login)
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                string ret = "";

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    ret = ws.LogRecusaNFe(tipoRecebimento, filial, chaveAcesso, (motivo.Length > 100 ? motivo.Substring(0, 97) + "..." : motivo), login);
                }

                Util.MostraCursor.CursorAguarde(false);

                if (ret != "")
                    MessageBox.Show(ret, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + " - " + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        public static void CriaRecusaSemNFe(int tipoRecebimento, int filial, int fornecedor, int notaFiscal, string serie, string motivo, string login)
        {
            try
            {
                Util.MostraCursor.CursorAguarde(true);

                string ret = "";

                using (EDLWS.EDLWS ws = new EDL.EDLWS.EDLWS())
                {
                    ws.Url = Util.LerGravarXML.ObterValor("urlSincronizacao");
                    ws.Timeout = 999999;

                    ret = ws.LogRecusaSemNFe(tipoRecebimento, filial, fornecedor, notaFiscal, serie, (motivo.Length > 100 ? motivo.Substring(0, 97) + "..." : motivo), login);
                }

                Util.MostraCursor.CursorAguarde(false);

                if (ret != "")
                    MessageBox.Show(ret, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            catch (Exception err)
            {
                Util.MostraCursor.CursorAguarde(false);
                MessageBox.Show(EDL.Properties.Resources.SYS999 + " - " + err.Message, Program.TituloMensagem, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

    }
}
