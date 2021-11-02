using System;
using System.Collections;
using System.Collections.Generic;

namespace GehannesMetVishaken
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList lst = new ArrayList();
            lst.Add(2);
            lst.Add(3);
            lst.Add("4");

            List<int> nrs = new List<int>();
            nrs.Add(3);


            float a = 10;
            float b = 20;

            Console.WriteLine($"a = {a}, b = {b}");
            Swap<float>(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");
        }

        private static void Swap<T>(ref T a, ref T b) 
        {
            T c = a;
            a = b;
            b = c;

        }
        private static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;

        }
    }
}
