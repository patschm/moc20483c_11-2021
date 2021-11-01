using System;

namespace bAsICs
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 4 * int.Parse("1000000000");

            //short sm = age as short;
            short sh = (short)age;
            short vbs = Convert.ToInt16(age);

            string es = (string)"Hello";
            string s = "hello" as string;
            long lng = age;

            string name = null;
            DateTime nu;
            int? x =null;

            Console.WriteLine(age) ;
        }
    }
}
