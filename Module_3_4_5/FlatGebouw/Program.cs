using System;

namespace FlatGebouw
{
    static class HairExtensions
    {
        public static string Reverse(this string x)
        {
            char[] str = x.ToCharArray();
            Array.Reverse(str);
            return new string(str);
        }
    }

    class Etage
    {
        public int Nummer { get; set; }
        private static Lift Elevator = new Lift();

        public void CallElevator()
        {
            Etage.Elevator.Call(Nummer);
        }
        public void ShowElevatorStatus()
        {
            Console.WriteLine($"Lift staat nu op de {Elevator.Current}e verdieping");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hallo";
            string sr = s.Reverse();
            Console.WriteLine(sr);

            Complex a1 = new Complex { Real = 10, Imaginary = 20 };
            Complex a2 = new Complex { Real = 100, Imaginary = 200 };

            Complex result = a1 + a2;
            Console.WriteLine(result);
            result = a1 + a2;
            Console.WriteLine(result);

            Console.ReadLine();

            Etage[] flat = new Etage[30]; 

            for(int i = 0; i < flat.Length; i++)
            {
                flat[i] = new Etage { Nummer = i };
            }

            flat[19].CallElevator();

            foreach(Etage et in flat)
            {
                et.ShowElevatorStatus();
            }
        }
    }
}
