using System;

namespace Mysterie
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person { Firstname = "Paul", Lastname = "Dirac" };
            p.Introduce();
        }
    }
}
