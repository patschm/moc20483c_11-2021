using Infrac;
using System;

namespace Heras
{
    public class Hek: IDetectable
    {
        public void Activate()
        {
            Open();
        }

        public void Open()
        {
            Console.WriteLine("Het hek gaat open");
        }
    }
}
