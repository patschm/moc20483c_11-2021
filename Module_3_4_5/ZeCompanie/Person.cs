using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeCompanie
{
    abstract class Person : IContract
    {
        public abstract void Werken();

        public void Werkt()
        {
            Werken();
        }
    }
}
