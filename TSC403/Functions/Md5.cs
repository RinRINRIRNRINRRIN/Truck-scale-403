using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TSC403.Functions
{
    internal class Md5
    {
        public static string _key_programNumber { get; set; }
        public static string _key_type { get; set; }


        public static string GEN_MD5()
        {
            string MD5Key = "";
            try
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    string DateMD5 = DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("th-TH"));

                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(_key_programNumber + _key_type + DateMD5));

                    StringBuilder sBuilder = new StringBuilder();

                    for (int i = 0; i < data.Length; i++)
                    {
                        sBuilder.Append(data[i].ToString("x2"));
                    }
                    MD5Key = sBuilder.ToString();
                }
            }
            catch
            {
                return "ERROR";
            }
            return MD5Key;
        }
    }
}
