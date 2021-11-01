using System;

namespace FuncProcs
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            DoeIets(out a);
            Console.WriteLine(a);
           int result = TelOp(c:12);
            ShowNumber(result);
            ShowNumber();
        }
     
        static void DoeIets(out int bla)
        {
           bla = 200;
        }
        static int TelOp(int a = 0, int b = 0, int c = 0)
        {
            return a + b + c;
        }
        static int TelOp(int a, int b)
        {
            int c =a +b;
            return c;
        }
        static int TelOp(params int[] nrs)
        {
            int result = 0;
            foreach(int nr in nrs)
            {
                result += nr;
            }
            return result;
        }
        static void ShowNumber(int nr = 42)
        {
            Console.WriteLine($"Het nummer is {nr}");
        }
    }
}
