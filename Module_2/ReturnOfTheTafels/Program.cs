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
            do
            {
                Console.Write("Welke tafel? ");
                string snr = Console.ReadLine();
                try
                {
                    return int.Parse(snr);
                }
                catch(FormatException fe)
                {
                    Console.WriteLine($"{snr} is geen getal. Probeer het nog eens");
                }
                catch(OverflowException oc)
                {
                    Console.WriteLine($"Het getal moet tussen {int.MinValue} en {int.MaxValue} liggen");
                }
                catch(Exception e)
                {
                    Console.WriteLine("Onbekende fout");
                }
            }
            while (true);
        }
    }
}
