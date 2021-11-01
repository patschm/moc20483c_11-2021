using System;
using System.Diagnostics;
using System.Text;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();

            Stopwatch watch = new Stopwatch();
            watch.Start();
            for(int i = 0; i < 100000; i++)
            {
                text.Append(i.ToString());
            }
            watch.Stop();

            Console.WriteLine(watch.Elapsed);
        }
    }
}
