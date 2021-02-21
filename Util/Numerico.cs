using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EDL.Util
{
    public static class Numerico
    {
        public static void FiltraNumero(ref TextBox texto, KeyPressEventArgs e, Boolean usaDecimal)
        {
            if (e.KeyChar != 8)
            {

                if (e.KeyChar < 48 || e.KeyChar > 57) e.Handled = true;
                if (e.KeyChar == 46)
                {
                    if (usaDecimal && texto.Text.IndexOf(",") == -1 && texto.Text.Trim() != "")
                    {
                        texto.SelectedText = ",";
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        public static String FormataNumero(String texto, int casasDecimais)
        {
            return String.Format("{0:N" + casasDecimais + "}", Convert.ToDecimal(texto.Replace(",", "."))).Replace(",", "").Replace(".", ",");
        }
    }
}
