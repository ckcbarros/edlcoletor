using System;
using System.Collections.Generic;
using System.Text;

namespace EDL.Util
{
    class Credencial
    {
        public System.Net.IWebProxy RetornaProxy()
        {
            System.Net.NetworkCredential credencial = new System.Net.NetworkCredential(LerGravarXML.ObterValor("proxyUsuario"), LerGravarXML.ObterValor("proxySenha"));
            System.Net.IWebProxy proxy;

            //proxy = new System.Net.WebProxy(LerGravarXML.ObterValor("proxyServidor"), Convert.ToInt32(LerGravarXML.ObterValor("proxyPorta")));
            proxy = new System.Net.WebProxy(LerGravarXML.ObterValor("proxyServidor") + ":" + Convert.ToInt32(LerGravarXML.ObterValor("proxyPorta")));
            proxy.Credentials = credencial;

            return proxy;
        }
    }
}
