using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRules
{
    public class MD5
    {
        public static string EncriptrarClave(string Clave)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(Clave));
            byte[] resultado = md5.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 1; i < resultado.Length; i++)
            {
                str.Append(resultado[i].ToString("x2"));
            }
            return str.ToString();
        }
    }
}

