using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vullis
{
    class UnmanagedResource : IDisposable
    {
        private FileStream file;
        private static  bool isOpen = false;

        public void Close()
        {
            Console.WriteLine("We gaan sluiten");
            isOpen = false;
        }
        public void Open()
        {
            if (isOpen)
            {
                Console.WriteLine("Helaas. Reeds in gebruik");
            }
            else
            {
                Console.WriteLine("Ok. Openen...");
                isOpen = true;
                file = new FileStream(@"D:\bla.text", FileMode.OpenOrCreate);
            }
        }
        protected void RuimOp(bool fromFin)
        {         
            Close();
            if (!fromFin)
            {
                file.Dispose();
            }
        }
        public void Dispose()
        {
            RuimOp(false);
          
            GC.SuppressFinalize(this);
        }

        ~UnmanagedResource() => RuimOp(true);

    }
}
