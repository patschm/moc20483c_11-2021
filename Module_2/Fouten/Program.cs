using System;

namespace Fouten
{
    class Program
    {
        static void Main(string[] args)
        {
            DoeIets();

        }

        static void DoeIets()
        {
            try
            {
                int nr = MaakGetal();
                Console.WriteLine(nr);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Dit is geen nummer");
            }
            catch(OverflowException oe)
            {
                Console.WriteLine("Te groot of te klein");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Ik van alles wat gemist wordt");
                throw;
            }
        }

        static int MaakGetal()
        {
            throw new Exception("Ooops");
        }
    }
}
