using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace EDL.Util
{
    public static class Versao
    {
        public static string VersaoColetor()
        {
            return "Versão " + Assembly.GetExecutingAssembly().GetName().Version.Major + "." +
                               Assembly.GetExecutingAssembly().GetName().Version.Minor + "." +
                               Assembly.GetExecutingAssembly().GetName().Version.Build +"."+
                               Assembly.GetExecutingAssembly().GetName().Version.Revision;

        }
    }
}
