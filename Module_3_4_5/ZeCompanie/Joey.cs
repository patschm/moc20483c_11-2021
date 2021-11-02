using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeCompanie
{
    class Joey : Person, IContract
    {
        public void Proggt()
        {
            Console.WriteLine("Joey programmeert iets");
        }

        public override void Werken()
        {
            Proggt();
        }

        public new void Werkt()
        {
            Proggt();
        }
    }
}
