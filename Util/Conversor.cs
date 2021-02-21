using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;

namespace EDL.Util
{
    public class Conversor
    {
        /// <summary>
        /// Cria e preenche uma DataTable a partir de uma coleção de objetos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="colObj"></param>
        /// <returns></returns>
        public static DataTable CriaDataTable<T>(IList<T> colObj)
        {
            if (colObj.Count != 0)
            {
                Type tipo = colObj[0].GetType();
                DataTable dt = new DataTable(tipo.Name);
                object[] indexArgs = { };
                PropertyInfo[] m_props = null;
                try
                {
                    m_props = tipo.GetProperties();
                    foreach (PropertyInfo pinfo in m_props)
                    {
                        dt.Columns.Add(pinfo.Name);
                    }
                    foreach (T obj in colObj)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (PropertyInfo pinf in m_props)
                        {
                            dr[pinf.Name] = pinf.GetValue(obj, indexArgs);
                        }
                        dt.Rows.Add(dr);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return dt;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Converte um DataTable para uma lista de objetos de um tipo definido.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto do qual a lista será formada.</typeparam>
        /// <param name="DtObjeto">DataTable que será convertido.</param>
        /// <returns>Lista de objetos da DataTable.</returns>
        public static List<T> DataTableParaListaObjetos<T>(DataTable DtObjeto) where T : new()
        {
            if ((DtObjeto != null) && (DtObjeto.Rows.Count > 0))
            {
                Type tipo = typeof(T);
                T objeto;
                PropertyInfo[] pi = null;
                List<T> lstT = new List<T>();

                try
                {
                    pi = tipo.GetProperties();
                    foreach (DataRow dr in DtObjeto.Rows)
                    {
                        objeto = new T();
                        foreach (PropertyInfo pinf in pi)
                        {
                            pinf.SetValue(objeto, dr[pinf.Name], null);
                        }
                        lstT.Add(objeto);
                    }
                }
                catch
                {
                    return new List<T>();
                }
                return lstT;
            }
            else
            {
                return new List<T>();
            }
        }

        /// <summary>
        /// Retorna um array de bytes de um aquivo.
        /// </summary>
        public static byte[] FileToByteArray(string FileNameAndPath)
        {
            if (!File.Exists(FileNameAndPath))
            {
                return null;
            }

            FileStream fsFile = new FileStream(FileNameAndPath, FileMode.Open, FileAccess.Read);

            byte[] bytArData = new byte[fsFile.Length];
            fsFile.Read(bytArData, 0, System.Convert.ToInt32(fsFile.Length));

            fsFile.Close();

            return bytArData;
        }

        /// <summary>
        /// Cria uma string contendo um hexadecimal a partir de um array de bytes.
        /// </summary>
        public static string ByteArrayToHexString(byte[] arByte)
        {
            if (arByte == null)
            {
                return String.Empty;
            }

            StringBuilder sbHex = new StringBuilder(arByte.Length * 2);

            foreach (byte b in arByte)
            {
                sbHex.AppendFormat(null, "{0:x2}", b);
            }

            return sbHex.ToString().ToUpper();
        }

        /// <summary>
        /// Gera um array de bytes baseado em uma string de hexadecimal.
        /// </summary>
        public static byte[] HexStringToByteArray(string strHex)
        {
            if (String.IsNullOrEmpty(strHex))
            {
                return null;
            }

            try
            {
                strHex = strHex.Replace("-", String.Empty);
                int NumberChars = strHex.Length;
                byte[] bytes = new byte[NumberChars / 2];
                for (int i = 0; i < NumberChars; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(strHex.Substring(i, 2), 16);
                }
                return bytes;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Cria um arquivo baseado no array de bytes.
        /// </summary>
        public static void ByteArrayToFile(byte[] arByte, string FileNameAndPath, bool ReplaceIfExists)
        {
            if (arByte == null || String.IsNullOrEmpty(FileNameAndPath))
            {
                return;
            }


            if (File.Exists(FileNameAndPath))
            {
                if (ReplaceIfExists)
                {
                    File.Delete(FileNameAndPath);
                }
                else
                {
                    return;
                }
            }

            FileStream fs = new FileStream(FileNameAndPath, FileMode.Create, FileAccess.Write);
            fs.Write(arByte, 0, arByte.Length);
            fs.Close();
        }
    }
}
