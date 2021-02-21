using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace EDL.Util
{
    public static class LogErro
    {
        public static void GravaLog(string mensagem, string erro)
        {
            //O sistema cria um arquivo de log por dia e apaga o do dia posterior. Ou seja, ele terá
            //sempre os logs dos 30/31 últimos dias

            StreamWriter arquivo = new StreamWriter(Util.PastaSistema.AppPath() + Program.PASTA_LOG + "\\LOG" + System.DateTime.Now.Day + ".TXT", true, System.Text.Encoding.Default);
            arquivo.WriteLine("--> [" + System.DateTime.Now + "] - [" + Program.Usuario.Nome + "] - [" + mensagem + "] - [" + erro + "]");
            arquivo.Close();
            arquivo = null;
        }

        public static void GravaStackTrace(Exception ex)
        {
            StreamWriter arquivo = new StreamWriter(Util.PastaSistema.AppPath() + Program.PASTA_LOG + "\\LOG" + System.DateTime.Now.Day + ".TXT", true, System.Text.Encoding.Default);
            arquivo.WriteLine("--> [" + System.DateTime.Now + "] - [" + Program.Usuario.Nome + "] - [" + ex.StackTrace + "]");
            arquivo.Close();
            arquivo = null;
        }
    }
}
