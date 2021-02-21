using System;
using System.Runtime.InteropServices;

namespace EDL.Util
{
    public class MostraCursor
    {
        private const int hourGlassCursorID = 32514;

        [DllImport("coredll.dll")]
        private extern static int LoadCursor(int zeroValue, int cursorID);

        [DllImport("coredll.dll")]
        private extern static int SetCursor(int cursorHandle);

        public static void CursorAguarde(bool ativo)
        {
            int cursorHandle = 0;
            if (ativo)
                cursorHandle = LoadCursor(0, hourGlassCursorID);

            SetCursor(cursorHandle);
        }
    }
}
