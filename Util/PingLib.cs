using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;

namespace EDL.Util
{
    public static class PingLib
    {
        #region API´s

        [DllImport("\\windows\\iphlpapi.dll", SetLastError = true)]
        static extern IntPtr IcmpCreateFile();

        [DllImport("\\windows\\iphlpapi.dll", SetLastError = true)]
        static extern bool IcmpCloseHandle(IntPtr handle);

        [DllImport("\\windows\\iphlpapi.dll", SetLastError = true)]
        static extern Int32 IcmpSendEcho(IntPtr icmpHandle, Int32 destinationAddress, String requestData, Int16 requestSize, ref IP_OPTION_INFORMATION requestOptions, ref ICMP_ECHO_REPLY replyBuffer, Int32 replySize, Int32 timeout);

        #endregion

        #region Estruturas

        [StructLayout(LayoutKind.Sequential)]
        public struct IP_OPTION_INFORMATION
        {
            public byte TTL;
            public byte TOS;
            public byte Flags;
            public byte OptionsSize;
            public IntPtr OptionsData;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct ICMP_ECHO_REPLY
        {
            public int Address;
            public int Status;
            public int RoundTripTime;
            public Int16 DataSize;
            public Int16 Reserved;
            public IntPtr DataPtr;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
            public String Data;
            public IP_OPTION_INFORMATION Options;
        }

        #endregion

        /// <summary>
        /// Pingar um endereco IP.
        /// </summary>
        /// <param name="ip">IP no formato xxx.xxx.xxx.xxx</param>
        /// <param name="timeout">Timeout para efetuar o Ping</param>
        /// <param name="info">Informacao retornada no formato DOS</param>
        /// <returns>Tempo em milisegundos</returns>
        public static int Ping(string ip, int timeout, out string info)
        {

            IPEndPoint host = null;

            host = new IPEndPoint(Dns.GetHostEntry(ip).AddressList[0], 0);

            if (host == null | Environment.OSVersion.Platform != PlatformID.WinCE)
            {
                info = "ip error!";
                return -1;
            }

            int result = -1;
            IntPtr ICMPHandle;
            Int32 iIP;
            String sData;
            IP_OPTION_INFORMATION oICMPOptions = new IP_OPTION_INFORMATION();
            ICMP_ECHO_REPLY ICMPReply = new ICMP_ECHO_REPLY();
            Int32 iReplies;

            ICMPHandle = IcmpCreateFile();
            iIP = BitConverter.ToInt32(host.Address.GetAddressBytes(), 0);
            sData = "abcdefghijklmnopqrstuvwxyz012345";
            oICMPOptions.TTL = 255;

            iReplies = IcmpSendEcho(ICMPHandle, iIP, sData,
                                   (Int16)sData.Length, ref oICMPOptions,
                                   ref ICMPReply, Marshal.SizeOf(ICMPReply),
                                   timeout);

            if (ICMPReply.Status == 0 && iReplies > 0)
            {
                result = ICMPReply.RoundTripTime;
                info = "ping bytes=" + sData.Length.ToString() + " time=" + result.ToString() + "ms TTL=" + oICMPOptions.TTL.ToString();
            }
            else
            {
                info = "ping　" + ip + "timed　out.";
            }

            IcmpCloseHandle(ICMPHandle);
            return result;
        }
    }
}
