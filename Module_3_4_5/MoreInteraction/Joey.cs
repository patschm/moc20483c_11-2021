using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreInteraction
{
    delegate int IetDel(int a);

    class Joey
    {
        public void Execute(IetDel wat)
        {
            Console.WriteLine("Joey gaat iets doen");
            int result = wat(34);
            Console.WriteLine(result);
        }
    }
}
