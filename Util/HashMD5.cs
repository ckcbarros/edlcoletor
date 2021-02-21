using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace EDL.Util
{
    public static class HashMD5
    {
        public static string GeraHashMD5(string Texto)
        {
            Byte[] bytOriginal;
            Byte[] bytCodigo;
            MD5 md5Objeto;
            string strResult = string.Empty;

            md5Objeto = new MD5CryptoServiceProvider();
            bytOriginal = ASCIIEncoding.Default.GetBytes(Texto);
            bytCodigo = md5Objeto.ComputeHash(bytOriginal);
            strResult = BitConverter.ToString(bytCodigo);
            strResult = strResult.Replace("-", string.Empty);

            return strResult;
        }

    }
}
