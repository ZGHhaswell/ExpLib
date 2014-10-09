using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEncrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IFormatProvider format = new System.Globalization.CultureInfo("zh-cn", true);

            var content = DateTime.Now.ToString(format);
            var code = EncryptService.DESEncrypt(content, "bejcxhds");
            var content1 = EncryptService.DESDecrypt(code, "bejcxhds");
            Console.WriteLine(content1);

            Console.WriteLine(DateTime.Parse(content, format));
        }
    }
}
