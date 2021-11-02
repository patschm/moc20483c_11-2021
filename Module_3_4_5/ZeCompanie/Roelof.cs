using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeCompanie
{
    class Roelof: Person
    {
        public void KanIets()
        {
            Console.WriteLine("Roelof maakt iets");
        }

        public override void Werken()
        {
            KanIets();
        }
    }
}
