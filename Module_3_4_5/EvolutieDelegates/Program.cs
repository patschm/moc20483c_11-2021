using System;

namespace EvolutieDelegates
{

    delegate int MathDel(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            // .NET 1.0/1.1
            MathDel m1 = new MathDel(Multiply);
            int result = m1(1, 2);

            // .NET 2.0
            MathDel m2 = Multiply;
            result = m2(2, 3);

            int c = 2;

            MathDel m3 = delegate (int a, int b)
             {
                 return a * b + c;
             };

            result = m3(3, 4);

            // .NET 3.0/3.5
            MathDel m4 = (a, b) => a * b;
            result = m4(4, 5);

            // Procedures
            Action<string> a1 = msg => Console.WriteLine(msg);
            a1("hoi");

            // Functions
            Func<int, int, int> m5 = Multiply;
            result = m5(5, 6);

            a1(result.ToString());
            Console.WriteLine(result);


            // C# 8.0
            int Multiply(int a, int b)
            {
                return a * b;
            }
        }

        //static int Multiply(int a, int b)
        //{
        //    return a * b;
        //}
    }
}
