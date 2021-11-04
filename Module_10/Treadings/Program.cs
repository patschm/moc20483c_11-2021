using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Treadings
{
    class Program
    {
        static void Main(string[] args)
        {
            //DefaultWerk();
            //OuweMeuk_Deel_1();
            //OuweMeuk_Deel_2();
            //ModerneWereld();
            //FunFouten();
            //MoreFunWithTasks();
            //HetWordtNogMooier();
            //DirigerenAsync();
            //GeinigSpul();
            //DeGarage();
            ConcurrentBoodschappentas();
            Console.WriteLine("En verder");
            Console.ReadLine();
        }

        private static void ConcurrentBoodschappentas()
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();
            bag.Add(4);

        }

        private static void DeGarage()
        {
            Random rnd = new Random();
            SemaphoreSlim garage = new SemaphoreSlim(20, 20);
            Parallel.For(0, 100, idx => {
                Console.WriteLine($"Wagen {idx} Komt eraan en wacht");
                garage.Wait();
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine($"Wagen {idx} rijdt naar binnen");
                Console.ResetColor();
                Task.Delay(rnd.Next(15000, 18000)).Wait();
                garage.Release();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Wagen {idx} rijdt naar buiten");
                Console.ResetColor();

            });
        }

        static object stokje = new object();

        private static void GeinigSpul()
        {
            int counter = 0;

            Parallel.For(0, 15, idx => {             
                lock (stokje)
                {
                    int ct = counter;
                    Task.Delay(500).Wait();
                    Console.WriteLine(++ct);
                    counter = ct;
                }
            });
        }

        private static async Task DirigerenAsync()
        {
            int a = 0;
            int b = 0;

            var t1 = Task.Run(() => {
                Task.Delay(3000).Wait();
                a = 20;
            });
            var t2 = Task.Run(() => {
                Task.Delay(1000).Wait();
                b = 10;
            });

            await Task.WhenAll(t1, t2);
            int result = a + b;
            Console.WriteLine(result);
        }

        private static async void HetWordtNogMooier()
        {
            try
            {
                //await Task.Run(() => IetsFouts());
            }
            catch(AggregateException ae)
            {
                Console.WriteLine(ae?.InnerException.Message);
            }

            Task<int> t = Task.Run(() => LongAdd(9, 10));

            int result  = await t;
            Console.WriteLine(result);

            result = await LongAddAsync(8, 9);
            Console.WriteLine(result);
            result = await LongAddAsync(18, 9);
            Console.WriteLine(result);
        }

        private static void MoreFunWithTasks()
        {
            CancellationTokenSource nikko = new CancellationTokenSource();
            CancellationToken bommetje = nikko.Token;

            Task.Run(() => { 
                for(int a = 0; true ; a++)
                {
                    //bommetje.ThrowIfCancellationRequested()
                    if (bommetje.IsCancellationRequested)
                    {
                        Console.WriteLine("Kaboooom");
                        return;
                    }
                    Console.WriteLine(a);
                    Task.Delay(500).Wait();
             }
            });

            Console.WriteLine("Niks te zien. Doorlopen...");
            //Console.ReadLine();
            nikko.CancelAfter(5000);
        }

        private static void FunFouten()
        {
            Task.Run(() => IetsFouts())
            .ContinueWith(pt => {
                if (pt.Exception != null)
                {
                    Console.WriteLine(pt.Exception.InnerException.Message);
                }
            });        
        }

        private static void IetsFouts()
        {
            Task.Delay(500).Wait();
            throw new NotImplementedException();
        }

        private static void ModerneWereld()
        {
            //Task t1 = new Task(() => {
            //    int res = LongAdd(1, 2);
            //    Console.WriteLine(res);
            //});
            //t1.Start();
            //Task<int> t2 = new Task<int>(() => {
            //    int RESULT = LongAdd(5, 6);
            //    return RESULT;
            //});

            //t2.ContinueWith(prevTask =>{ 
            //    int result = t2.Result;
            //    Console.WriteLine(result);
            //});
            //t2.Start();

            Task.Run(() => LongAdd(9, 10))
                .ContinueWith(pt => Console.WriteLine(pt.Result));
            
           // Task.Factory.FromAsync
        }

        private static void OuweMeuk_Deel_1()
        {
            Func<int, int, int> del = LongAdd;
            IAsyncResult ar = del.BeginInvoke(4, 5, null, null);

            while(!ar.IsCompleted)
            {
                Console.Write(".");
                Task.Delay(100).Wait();
            }

           int res =  del.EndInvoke(ar);
            Console.WriteLine(res);
        }
        private static void OuweMeuk_Deel_2()
        {
            Func<int, int, int> del = LongAdd;

            del.BeginInvoke(4, 5, (IAsyncResult arr) => {
                 int res = del.EndInvoke(arr);
                 Console.WriteLine(res);
            }, null);
           
        }
        private static void DefaultWerk()
        {
            int res = LongAdd(1, 2);
            Console.WriteLine(res);
        }

        static int LongAdd(int a, int b)
        {
            Task.Delay(10000).Wait();
            return a + b;
        }
        static Task<int> LongAddAsync(int a, int b)
        {
            return Task.Run(() => LongAdd(a, b));
        }
    }
}
