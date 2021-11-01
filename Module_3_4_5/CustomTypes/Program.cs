using System;

namespace CustomTypes
{
    enum DayOfWeek : ulong
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64
    }
    class Program
    {
        static void Main(string[] args)
        {
            int dag = 2;
            DayOfWeek day = DayOfWeek.Monday;
            Console.WriteLine((int)day);
            Console.WriteLine((DayOfWeek)dag);

            int x = 35;
            int res = x & (int)DayOfWeek.Wednesday;
            Console.WriteLine(res);
        }
    }
}
