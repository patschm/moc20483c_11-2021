using System;
using System.Reflection;

namespace TheClien_t
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person p = new Person { Age = 34, FirstName = "Marieke", LastName = "Janssen" };
            //p.Show();

            Assembly asm = Assembly.LoadFrom(@"D:\SomeLibrary.dll");
            Console.WriteLine(asm.FullName);

            //Examine(asm);
            Type tpers = asm.GetType("SomeLibrary.Person");

            object p = Activator.CreateInstance(tpers);

            PropertyInfo fnProp = tpers.GetProperty("FirstName");
            fnProp.SetValue(p, "Mark");

            PropertyInfo lnProp = tpers.GetProperty("LastName");
            lnProp.SetValue(p, "Rutte");

            PropertyInfo agProp = tpers.GetProperty("Age");
            agProp.SetValue(p, 45);

            FieldInfo fi = tpers.GetField("age", BindingFlags.Instance | BindingFlags.NonPublic);
            fi.SetValue(p, -45);

            MethodInfo showInf = tpers.GetMethod("Show");
            showInf.Invoke(p, new object[] { });

            dynamic p2 = Activator.CreateInstance(tpers);
            p2.FirstName = "Willem";
            p2.LastName = "Holleeder";
            p2.Age = 67;

            p2.Show();

        }

        private static void Examine(Assembly asm)
        {
            foreach(Type tp in asm.GetTypes())
            {
                Console.WriteLine(tp.FullName);

                foreach(PropertyInfo prop in tp.GetProperties())
                {
                    Console.WriteLine(prop.Name);
                }
                foreach (MethodInfo prop in tp.GetMethods())
                {
                    Console.WriteLine(prop.Name);
                }
                Console.WriteLine("=======Fields=================");
                foreach (FieldInfo prop in tp.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                {
                    Console.WriteLine(prop.Name);
                }
            }
        }
    }
}
