using System;

namespace FunWithdelegates
{
    delegate int MathDel(int a, int b);

    class Program
    {
        static void Main(string[] args)
        {
            MathDel md = Add;

            md += Subtract;
            md += Add;
            md -= Add;
            //- Subtract + Add - Subtract;

            foreach(var del in md.GetInvocationList())
            {
                Console.WriteLine(del.Method.Name);
            }


            int result = md(1, 2);

            md += Subtract;
            Console.WriteLine(result);
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
}
