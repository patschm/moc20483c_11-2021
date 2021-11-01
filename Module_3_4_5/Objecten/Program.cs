using System;

namespace Objecten
{
    abstract class Vehicle
    {
        public string Color { get; set; }
        protected int AantalCylinders { get; set; } = 4;

        public abstract void Rijden();
        //{
        //    Console.WriteLine($"Het vehicle rijdt");
        //}
    }

    class Taxi : Vehicle
    {
        public override void Rijden()
        {
            Console.WriteLine("De taxi scheurt rond");
        }
    }

    // Blauwdruk van een schoolbus
    class SchoolBus : Vehicle
    {
        // Eigenschappen sla je op in fields (veredelde variabelen)
        private int _aantalZitplaatsen = 14;
        //private string color;


        //// Auto generating properties
        //public string Color { get; set; }

        // Properties. Voor gecontroleerde toegang tot private fields (Encapsulation)
        public int AantalZitPlaatsen
        {
            get
            {
                return _aantalZitplaatsen;
            }
            set
            {
                if (value >= 0 && value < 1000)
                {
                    _aantalZitplaatsen = value;
                }
            }
        }

        // Gedrag leg je vast in methods (veredelde functies of procedures)
        public override void Rijden()
        {            
            Console.WriteLine($"De {Color} schoolbus rijdt met {_aantalZitplaatsen} schoolkindertjes");
        }

        // Constructors. Bedoeld om fields een initiele waarde te geven.
        public SchoolBus() : this(42)
        {

        }
        public SchoolBus(int nr)
        {
            _aantalZitplaatsen = nr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vehicle obj = new SchoolBus();
            obj.Color = "groene";
           
            obj.Rijden();

            Vehicle v1 = new Taxi();
            v1.Rijden();

        }
    }
}
