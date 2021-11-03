using System;

namespace Vullis
{
    class Program
    {
        static UnmanagedResource res1 = new UnmanagedResource();
        static UnmanagedResource res2 = new UnmanagedResource();

        static void Main(string[] args)
        {
            try
            {
                res1.Open();
            }
            finally
            {
                 res1.Dispose();
                 res1 = null;
            }
           
            //res1?.Close();

            GC.Collect();
            GC.WaitForPendingFinalizers();

            using (res2)
            {
                res2.Open();
            }
            
            res2 = null;

            using (UnmanagedResource res3  = new UnmanagedResource())
            {
                res3.Open();
            }

        }
    }
}
