using DoomsdayPreppers;
using Heras;
using Infrac;
using Philips;
using System;

namespace DeOprijlaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Valkuil kuil = new Valkuil();
            Hek hek = new Hek();
            DetectieLus lus = new DetectieLus();
            Lamp lamp = new Lamp();

            lus.Connect(hek);
            lus.Connect(kuil);
            lus.Connect(lamp);

            lus.Connect(hek.Open);
            lus.Connect(kuil.Open);
            lus.Connect(lamp.Aan);

            lus.Detecteert();
        }
    }
}
