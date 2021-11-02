using System;

namespace MoreInteraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Joey joey = new Joey();
            Patrick p = new Patrick();

            IetDel d = p.Opdracht;

            joey.Execute(d);

            d(23);

            // Ik doe het zelf
            //p.Opdracht();
            joey.Execute(p.Opdracht);
            joey.Execute(Bla);

        }

        static int Bla(int x)
        {
            Console.WriteLine($"Blaat {x} keer");
            return 100;
        }
    }
}
