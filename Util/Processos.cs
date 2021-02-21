using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace EDL.Util
{
    public class Processo
    {

        #region "Classe Interna"
        public class ProcessInfo
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public Int32 ProcessId;
            public Int32 ThreadId;
        }
        #endregion

        #region "Variaveis Internas"
        private Int32 m_pID;
        private ProcessInfo m_pInformation;
        #endregion

        #region "API - CoreDLL"

        [DllImport("CoreDll.DLL", SetLastError = true)]
        private static extern int CreateProcess(string imageName, string cmdLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, Int32 boolInheritHandles, Int32 dwCreationFlags, IntPtr lpEnvironment, IntPtr lpszCurrentDir, byte[] si, ProcessInfo pi
        );

        [DllImport("CoreDll.dll")]
        private static extern Int32 GetLastError();

        [DllImport("CoreDll.dll")]
        private static extern int TerminateProcess(IntPtr processIdOrHandle, IntPtr exitCode);

        #endregion

        public Processo()
        {
            m_pID = -1;
            m_pInformation = new ProcessInfo();
        }

        /// <summary>
        /// Retorna o ProcessID da aplicacao executada.
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public int ProcessID
        {
            get { return m_pID; }
        }

        /// <summary>
        /// Retorna a estrutura processinfo da aplicacao criada
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public ProcessInfo ProcessInformation
        {
            get { return m_pInformation; }
        }

        /// <summary>
        /// Iniciar um processo dentro da aplicacao.
        /// </summary>
        /// <param name="ExeName">Nome do aplicativo a ser executado</param>
        /// <param name="CmdLine">Parametros que podem ser passados. Caso nao tenha parametros, passe uma string vazia</param>
        /// <param name="pInfo">Parametros opcionais, passe nothing caso nao use</param>
        /// <returns>True se bem sucedido ou false se ocorrer erro</returns>
        /// <remarks></remarks>
        public bool IniciarProcesso(string ExeName, string CmdLine, ProcessInfo pInfo)
        {

            bool bolRet = false;

            if (pInfo == null)
            {
                pInfo = new ProcessInfo();
            }

            byte[] si = new byte[128];

            bolRet = CreateProcess(ExeName, CmdLine, IntPtr.Zero, IntPtr.Zero, 0, 0, IntPtr.Zero, IntPtr.Zero, si, pInfo) != 0;
            
            m_pID = Convert.ToInt32(pInfo.ProcessId);

            m_pInformation = pInfo;

            return bolRet;
        }

        /// <summary>
        /// Finalizar o processo criado anteriormente 
        /// </summary>
        /// <returns>Um inteiro com o valor retornado pelo TerminateProcess</returns>
        /// <remarks></remarks>
        public int FinalizarProcesso()
        {
            int dwExitCode = 0;
            int intRet = 0;
            intRet = TerminateProcess((IntPtr)m_pID, (IntPtr)dwExitCode);
            System.Threading.Thread.Sleep(100);
            return intRet;
        }
    }
}
