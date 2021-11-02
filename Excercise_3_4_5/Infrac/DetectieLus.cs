using IEEE;
using System;
using System.Collections.Generic;

namespace Infrac
{
    public delegate void DetectorDel();

    public class DetectieLus
    {
        private List<IDetectable> devices = new List<IDetectable>();
        private List<DetectorDel> devices2 = new List<DetectorDel>();

        public void Connect(DetectorDel dev)
        {
            devices2.Add(dev);
        }
        public void Connect(IDetectable device)
        {
            devices.Add(device);
        }
        public void Detecteert()
        {
            Console.WriteLine("De detectielus detecteert iets");
            Console.WriteLine("Via delegates");
            foreach(DetectorDel dev in devices2)
            {
                dev();
            }
            Console.WriteLine("Via interfaces");
            foreach(IDetectable device in devices)
            {
                device.Activate();
            }
        }
    }
}
