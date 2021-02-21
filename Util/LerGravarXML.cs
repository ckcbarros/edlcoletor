using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EDL.Util
{
    public static class LerGravarXML
    {
        public static string ObterValor(String Chave)
        {
            XmlDocument doc = new XmlDocument();
            string retorno = "";

            try
            {
                doc.Load(PastaSistema.AppPath() + Program.ARQUIVO_CONFIGURACAO);
                retorno = doc.DocumentElement[Chave].InnerText;
            }
            catch (Exception ex)
            {
                LogErro.GravaLog(String.Format("Erro ao ler elemento {0}.", Chave), ex.Message);
                retorno = "";
            }

            doc = null;

            return retorno;
        }

        public static bool GravarValor(String Chave, String Valor)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(PastaSistema.AppPath() + Program.ARQUIVO_CONFIGURACAO);

            doc.DocumentElement[Chave].InnerText = Valor;
            doc.Save(PastaSistema.AppPath() + Program.ARQUIVO_CONFIGURACAO);

            doc = null;

            return true;
        }
    }
}
