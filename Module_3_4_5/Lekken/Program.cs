using System;

namespace Lekken
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[][] access = new byte[1000][];

            Action<int> xd = (p) => {
                byte[] data = new byte[10000000];
                access[p] = data;
            };

            for(int i = 0; i < 1000; i++)
            {
                xd(i);
            }

            Console.ReadLine();
        }
    }
}
