using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeCompanie
{
    // ACME biedt een contract aan (ACME is de provider van het contract)
    interface IContract
    {
        void Werkt();
    }

    class ACME
    {
        private List<IContract> people = new List<IContract>();

        public void Hire(IContract p)
        {
            people.Add(p);
        }
        public void Produceren()
        {
            Console.WriteLine($"{nameof(ACME)} begint te {nameof(Produceren).ToLower()}");
            foreach(IContract p in people)
            {
                p.Werkt();
            }
        }
    }
}
