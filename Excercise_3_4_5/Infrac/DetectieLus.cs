using IEEE;
using System;
using System.Collections.Generic;

namespace Infrac
{
    public class DetectieLus
    {
        private List<IDetectable> devices = new List<IDetectable>();

        public void Connect(IDetectable device)
        {
            devices.Add(device);
        }
        public void Detecteert()
        {
            Console.WriteLine("De detectielus detecteert iets");
            foreach(IDetectable device in devices)
            {
                device.Activate();
            }
        }
    }
}
