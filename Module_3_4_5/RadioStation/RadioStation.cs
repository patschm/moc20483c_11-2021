using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStation
{
    delegate void ReceiptDel(string msg);

    class RadioStation
    {
        //private ReceiptDel _subs;
        public event ReceiptDel Subscribers;
        //{
        //    add
        //    {
        //        _subs += value;
        //    }
        //    remove
        //    {
        //        _subs -= value;
        //    }
        //}

        public void Broadcast()
        {
            Console.WriteLine("We zenden iets uit");
            Subscribers("Hallo luisteraars");
        }
    }
}
