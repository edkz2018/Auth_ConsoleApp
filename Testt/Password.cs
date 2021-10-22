using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Testt
{
    public static class Password
    {
        static string[] elements = { "abcdefghijklmnopqrstuvwxyz", "ABCDEFGHIJKLMNOPQRSTUVWXYZ", "0123456789", "!@#$%^&*()_-=+[]{};:<>/?.," };

        static Random r = new Random();
        static int x = r.Next(8, 12);
        static string password = "";

        public static string GetRandomPassword()
        {
            for (int i = 0; i < x; i++)
            {
                foreach (var item in elements)
                {
                    if(password.Length <= x)
                    {
                        var index = r.Next(item.Length);
                        password += item[index];
                    }
                }
            }
            return password;
        }

        public static string GetHashString(string s)
        {
                //переводим строку в байт-массим
                byte[] bytes = Encoding.Unicode.GetBytes(s);

                //создаем объект для получения средст шифрования
                MD5CryptoServiceProvider CSP =
                    new MD5CryptoServiceProvider();

                //вычисляем хеш-представление в байтах
                byte[] byteHash = CSP.ComputeHash(bytes);

                string hash = string.Empty;

                //формируем одну цельную строку из массива
                foreach (byte b in byteHash)
                    hash += string.Format("{0:x2}", b);

                return hash;
            
        }
    }
}
