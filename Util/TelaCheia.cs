using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EDL.Util
{
    public static class TelaCheia
    {
        #region Enumeracoes

        [Flags()]
        private enum FullScreenFlags : int
        {
            SwHide = 0,
            ShowTaskbar = 0x1,
            HideTaskbar = 0x2,
            ShowSipButton = 0x4,
            HideSipButton = 0x8,
            SwRestore = 9,
            ShowStartIcon = 0x10,
            HideStartIcon = 0x20
        }

        #endregion

        #region API Calls

        [DllImport("coredll.dll")]
        private static extern IntPtr GetCapture();

        [DllImport("coredll.dll")]
        private static extern IntPtr SetCapture(IntPtr hWnd);


        [DllImport("aygshell.dll", SetLastError = true)]
        private static extern bool SHFullScreen(IntPtr hwnd, int state);


        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr FindWindowW(string lpClass, string lpWindow);


        [DllImport("coredll.dll", SetLastError = true)]
        private static extern IntPtr MoveWindow(IntPtr hwnd, int x, int y, int w, int l, int repaint);

        [DllImport("aygshell.dll")]
        static extern bool SHFullScreen(IntPtr hwndRequester, uint dwState);

        #endregion

        #region Metodos

        private static IntPtr GetHWnd(Control c)
        {
            IntPtr hOldWnd = GetCapture();
            c.Capture = true;
            IntPtr hWnd = GetCapture();
            c.Capture = false;
            SetCapture(hOldWnd);
            return hWnd;
        }

        /// <summary>
        /// Travar a tela do coletor de dados. 
        /// Neste momento se estiver utilizando Pocket PC , o Start Menu será movido
        /// para baixo.
        /// </summary>
        /// <param name="c">Form a ser controlado</param>
        public static void SetFullScreen(Control c)
        {
            IntPtr iptr = GetHWnd(c);
            SHFullScreen(iptr, (int)FullScreenFlags.HideStartIcon);

            // move the viewing window north 24 pixels to get rid of the command bar 
            MoveWindow(iptr, 0, -24, 240, 344, 1);

            // move the task bar south 24 pixels so that its not visible anylonger 
            IntPtr iptrTB = FindWindowW("HHTaskBar", null);
            MoveWindow(iptrTB, 0, 320, 240, 24, 1);
        }

        /// <summary>
        /// Destravar a tela do coletor.
        /// </summary>
        /// <param name="c">Formulario a ser controlado</param>
        public static void UnsetFullScreen(Control c)
        {
            IntPtr iptr = GetHWnd(c);
            SHFullScreen(iptr, (int)FullScreenFlags.ShowStartIcon);
            MoveWindow(iptr, 0, 0, 240, 296, 1);

            IntPtr iptrTB = FindWindowW("HHTaskBar", null);
            MoveWindow(iptrTB, 0, 296, 240, 24, 1);
        }

        #endregion

        #region Constantes
        const uint SHFS_SHOWTASKBAR = 0x0001;
        const uint SHFS_HIDETASKBAR = 0x0002;
        const uint SHFS_SHOWSIPBUTTON = 0x0004;
        const uint SHFS_HIDESIPBUTTON = 0x0008;
        const uint SHFS_SHOWSTARTICON = 0x0010;
        const uint SHFS_HIDESTARTICON = 0x0020;
        #endregion

        #region Bloqueio de Teclas

        [DllImport("coredll.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnregisterFunc1(uint fsModifiers, uint id);

        [DllImport("coredll.dll", SetLastError = true)]
        private static extern bool RegisterHotKey(
        IntPtr hWnd,              // handle to window 
        int id,                   // hot key identifier 
        KeyModifiers Modifiers,   // key-modifier options 
        int key                   //virtual-key code 
        );

        private enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8,
            Modkeyup = 0x1000,
            WM_HOTKEY = 0x312
        }

        private enum KeysHardware : int
        {
            Hardware1 = 193,
            Hardware2 = 194,
            Hardware3 = 195,
            Hardware4 = 196
        }

        /// <summary>
        /// Desabilitar teclas do Sistema Operacional
        /// </summary>
        /// <param name="c">Formulario Principal</param>
        public static void RegistraHotKey(Form c)
        {
            c.Capture = true;
            IntPtr hwnd = GetCapture();
            c.Capture = false;
            RegisterHotKey(hwnd, 1001, KeyModifiers.Control, 27);  //VK_ESCAPE
            RegisterHotKey(hwnd, 1002, KeyModifiers.Control, 9);   //VK_TAB
            RegisterHotKey(hwnd, 1003, KeyModifiers.Alt, 27);      //VK_ESCAPE
            RegisterHotKey(hwnd, 1004, KeyModifiers.Alt, 9);       //VK_TAB
        }

        #endregion

        #region Bloqueio de Tela

        /// <summary>
        /// Bloquear barra de tarefas do sistema operacional
        /// </summary>
        /// <param name="OnOff">true se desejar desabilitar, false se desejar habilitar</param>
        /// <param name="c">Formulario controlado</param>
        /// <returns>True se bem sucedido,False em caso de erro</returns>
        public static bool TaskBarOnOff(bool OnOff, Form c)
        {
            c.Capture = true;
            IntPtr hwnd = GetCapture();
            c.Capture = false;
            if (OnOff)
                return SHFullScreen(hwnd, SHFS_HIDETASKBAR | SHFS_HIDESIPBUTTON | SHFS_HIDESTARTICON);
            else
                return SHFullScreen(hwnd, SHFS_SHOWTASKBAR | SHFS_SHOWSIPBUTTON | SHFS_SHOWSTARTICON);
        }

        #endregion
    }
}
