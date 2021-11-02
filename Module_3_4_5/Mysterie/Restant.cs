using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysterie
{
    partial class Person
    {
        partial void Init(int x);
        
        public void Introduce()
        {
            Init(42);
            Console.WriteLine($"Ik ben {Firstname} {Lastname}");
        }
    }
}
