using System;

namespace FlatGebouw
{
    public class Lift
    {
        private int CurrentFloor;

        public void Call(int etage)
        {
            Console.WriteLine($"Lift naar de {etage}e");
            CurrentFloor = etage;
        }
        public int Current
        {
            get
            {
                return CurrentFloor;
            }
        }
    }
}