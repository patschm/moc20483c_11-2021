using System;

namespace RadioStation
{
    class Program
    {
        static void Main(string[] args)
        {
            RadioStation r538 = new RadioStation();
            r538.Subscribers += ViaKabel;
            r538.Subscribers += ViaPostduif;
            r538.Subscribers += ViaEther;
            r538.Subscribers += ViaKabel;
            r538.Subscribers += ViaPostduif;
            r538.Subscribers += ViaEther;
            r538.Subscribers += ViaKabel;
            r538.Subscribers += ViaPostduif;
            r538.Subscribers += ViaEther;
            r538.Subscribers += ViaKabel;
            r538.Subscribers += ViaPostduif;
            r538.Subscribers += ViaEther;

            r538.Subscribers += msg => Console.WriteLine($"Via hack {msg}");
            r538.Broadcast();

            //r538.Subscribers("Hey!");
            //Console.WriteLine(r538.Subscribers.GetInvocationList()[0].Method.Name);
        }

        static void ViaKabel(string message)
        {
            Console.WriteLine($"Via kabel: {message}");
        }
        static void ViaEther(string message)
        {
            Console.WriteLine($"Via ether: {message}");
        }
        static void ViaPostduif(string message)
        {
            Console.WriteLine($"Via postduif: {message}");
        }
    }
}
