using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int c = 3;
            Console.Write(Sum(5, 3, out c) + "");

        }

        static int Sum(int a, int b, out int c)
        {
            c = a + b;
            return a + b + 10;
        }
    }
}
