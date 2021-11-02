using System;

namespace ZeCompanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Mees m = new Mees();
            Joey j = new Joey();
            Roelof r = new Roelof();
            Bokito bok = new Bokito();
            ACME acm = new ACME();
            acm.Hire(bok);
            acm.Hire(j);
            acm.Hire(r);


            acm.Produceren();
        }
    }
}
