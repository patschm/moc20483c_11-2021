using System;

namespace Geinige
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex { Real = 10, Imaginary = 20 };
            Console.WriteLine(c1);
            DoeIets(c1);
            Console.WriteLine(c1);
        }

        private static void DoeIets(Complex cccc)
        {
            cccc.Imaginary = 2000;
            cccc.Real = 10000;
        }
    }
}
