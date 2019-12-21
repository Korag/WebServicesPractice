using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator_ASMX_klient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.KalkulatorSoapClient Serwisik = new ServiceReference1.KalkulatorSoapClient();

            Console.Write("2 + 4 = {0}", Serwisik.Add(2, 4));
            Console.Read();
        }
    }
}
