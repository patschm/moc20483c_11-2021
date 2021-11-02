using Infrac;
using System;

namespace Philips
{
    public class Lamp: IDetectable
    {
        public void Aan()
        {
            Console.WriteLine("De lamp gaat aan");
        }

        public void Activate()
        {
            Aan();
        }
    }
}
