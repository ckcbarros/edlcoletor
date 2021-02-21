using System;
using System.Runtime.InteropServices;

namespace EDL.Util
{
    public class DataHora
    {
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        [DllImport("coredll.dll")]
        public extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("coredll.dll")]
        public extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("coredll.dll")]
        public extern static uint SetLocalTime(ref SYSTEMTIME lpSystemTime);

        public static void AcertaDataHora(string trts)
        {
            SYSTEMTIME st;

            //st.wYear = (ushort)trts.Year;
            //st.wMonth = (ushort)trts.Month;
            //st.wDayOfWeek = (ushort)trts.DayOfWeek;
            //st.wDay = (ushort)trts.Day;
            //st.wHour = (ushort)trts.Hour;
            //st.wMinute = (ushort)trts.Minute;
            //st.wSecond = (ushort)trts.Second;
            //st.wMilliseconds = (ushort)trts.Millisecond;

            st.wYear = (ushort)Convert.ToInt32(trts.Substring(0,4));
            st.wMonth = (ushort)Convert.ToInt32(trts.Substring(5,2));
            st.wDayOfWeek = (ushort)Convert.ToDateTime(trts).DayOfWeek;
            st.wDay = (ushort)Convert.ToInt32(trts.Substring(8,2));
            st.wHour = (ushort)Convert.ToInt32(trts.Substring(11,2));
            st.wMinute = (ushort)Convert.ToInt32(trts.Substring(14,2));
            st.wSecond = (ushort)Convert.ToInt32(trts.Substring(17,2));
            st.wMilliseconds = 0;

            SetSystemTime(ref st);
            SetLocalTime(ref st);
        }
    }
}
