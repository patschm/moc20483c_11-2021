using Infrac;
using System;

namespace DoomsdayPreppers
{
    public class Valkuil : IDetectable
    {
        public void Activate()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("De valkuil opent");
        }

    }
}
