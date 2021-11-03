using System;
using System.Diagnostics;
using System.Text;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            //StringBuilder text = new StringBuilder();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for(int i = 0; i < 100000; i++)
            {
                text += i.ToString();
                //text.Append(i.ToString());
            }
            watch.Stop();

            Console.WriteLine(watch.Elapsed);

            Console.ReadLine();
        }
    }
}
