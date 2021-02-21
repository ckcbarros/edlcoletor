/***************************************************************************************
* Propósito    : Obter status da bateria principal, backup e verificar se coletor
*                ou dispositivo movel está na base ou nao. 
****************************************************************************************
* Plataforma   : Windows Mobile
* Linguagem    : Visual C# (3.0) - Visual Studio .NET 2005 (Framework 2.0)
****************************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;

namespace EDL.Util
{
    public class SYSTEM_POWER_STATUS_EX
    {
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public uint BatteryLifeTime;
        public uint BatteryFullLifeTime;
        public byte Reserved2;
        public byte BackupBatteryFlag;
        public byte BackupBatteryLifePercent;
        public byte Reserved3;
        public uint BackupBatteryLifeTime;
        public uint BackupBatteryFullLifeTime;
    }

    public class Bateria
    {
        private static SYSTEM_POWER_STATUS_EX status = null;

        [DllImport("coredll")]
        private static extern uint GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);

        public int BatteryLifePercent()
        {
            status = new SYSTEM_POWER_STATUS_EX();
            if (GetSystemPowerStatusEx(status, false) == 1)
                return status.BatteryLifePercent;
            else
                return 0;
        }

        public bool UsingACPower()
        {
            status = new SYSTEM_POWER_STATUS_EX();
            if (GetSystemPowerStatusEx(status, false) == 1)
            {
                return (status.ACLineStatus == 1);
            }
            else
                return false;
        }

        public Image BatteryImage()
        {
            Bateria status =  new Bateria();

            if (status.BatteryLifePercent() > 75)
            {
                return EDL.Properties.Resources.bateria_4;
            }
            else if (status.BatteryLifePercent() > 50)
            {
                return EDL.Properties.Resources.bateria_3;
            }
            else if (status.BatteryLifePercent() > 25)
            {
                return EDL.Properties.Resources.bateria_2;
            }
            else
            {
                return EDL.Properties.Resources.bateria_1;
            }
        }
    }
}
