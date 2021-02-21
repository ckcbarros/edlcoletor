using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace EDL.Util
{
    public static class Coletor
    {
        public static string NumeroColetor()
        {
            return Dns.GetHostName().ToString();
        }

        public static string IPColetor()
        {
            string numeroIP = "";

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            
            for (int i = 0; i < ipHostInfo.AddressList.Length; ++i)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    numeroIP = ipHostInfo.AddressList[i].ToString();
                    break;
                }
            }

            return numeroIP;
        }

    }
}
