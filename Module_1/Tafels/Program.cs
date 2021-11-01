using System;

namespace Tafels
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int tafel = 1; tafel <= 10; tafel++)
            {
                if (tafel == 5) continue;
                Console.WriteLine($"De tafel van {tafel}");
                for(int counter = 1; counter <= 10; counter++)
                {
                    if (counter == 5) continue;
                    Console.WriteLine($"{counter, -2} x {tafel, -2} = {counter * tafel}");
                }
            }
        }
    }
}
