using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mysterie
{
    partial class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        partial void Init(int x)
        {
            Console.WriteLine($"En nu wel {x}");
        }
    }
}
