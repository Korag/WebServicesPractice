using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PersonClient.localhost;

namespace PersonClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var PS = new PersonService();
            Console.WriteLine(PS.HelloWorld());


            Console.ReadLine();
        }
    }
}
