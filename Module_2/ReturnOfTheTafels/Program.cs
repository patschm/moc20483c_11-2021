using System;

namespace ReturnOfTheTafels
{
    class Program
    {
        static void Main(string[] args)
        {
            int nr = AskInput();
            ShowTafel(nr);
        }

        static void ShowTafel(int tafel)
        {
            Console.WriteLine($"De tafel van {tafel}");
            for(int counter = 1; counter <= 10; counter++)
            {
                Console.WriteLine($"{counter} x {tafel} = {counter * tafel}");
            }
        }

        static int AskInput()
        {
            throw new NotImplementedException();
        }
    }
}
