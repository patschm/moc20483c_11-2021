using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Link
{
    [AttributeUsage(AttributeTargets.Class)]
    class CustomAttribute: Attribute
    {
        public string Bla { get; set; }
    }

    [Custom(Bla = "hoi")]
    [Obsolete("Nie gebruuuke", true)]
    class Dummy
    {
        public string First { get; set; }
        public string Last { get; set; }
    }
    class Program
    {
        static List<Person> people = new List<Person>();
        static List<Company> companies = new List<Company>();
        static List<PersonCompany> peopleCompanies = new List<PersonCompany>();

        static bool PersonWithFirstNameStartingWithAnA(Person p)
        {
            return p.FirstName.StartsWith("A");
        }
        static bool PersonWithFirstNameStartingWithAnB(Person p)
        {
            return p.FirstName.StartsWith("B");
        }
        static void Main(string[] args)
        {
            Dummy d = new Dummy();
            // SetupDatabase();
            QueryDatabase();
            //string letter = "D";
            //Initialize();

            //var query = people
            //    .Where(p => p.FirstName.StartsWith(letter))
            //    .OrderBy(p => p.Age)
            //    .Select(p => new  { First = p.FirstName, Last = p.LastName });

            //var q2 = from p in people 
            //         where p.LastName.StartsWith(letter) 
            //         orderby p.Age 
            //         select new { First = p.FirstName, Last = p.LastName };


            //foreach (var person in q2)
            //{
            //    Console.WriteLine($"{person.First} {person.Last}");
            //}

            //foreach(var person in query.Take(4))
            //{
            //    Console.WriteLine($"[{person.Id}] {person.FirstName} {person.LastName} ({person.Age})");
            //}
        }

        private static void QueryDatabase()
        {
            string consString = @"Server=.\sqlexpress;Database=ACME;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
            bld.UseSqlServer(consString);
            ACMEContext context = new ACMEContext(bld.Options);

            var query = context.People
                .Include(p => p.PersonCompanies)
                    .ThenInclude(pc => pc.Company);

            foreach(Person p in query)
            {
                Console.WriteLine($"{p.FirstName} {p.LastName}");
                foreach(PersonCompany pc in p.PersonCompanies)
                {
                    Console.WriteLine($"\t{pc.Company.Name}");
                }
            }
        }

        private static void SetupDatabase()
        {
            Initialize();
            string consString = @"Server=.\sqlexpress;Database=ACME;Trusted_Connection=True;MultipleActiveResultSets=true;";
            DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
            bld.UseSqlServer(consString);

            ACMEContext context = new ACMEContext(bld.Options);
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            var qp = from p in peopleCompanies group p by p.Person;
            foreach (var item in qp)
            {
                Person p = item.Key;
                foreach (var cps in item)
                {
                    p.PersonCompanies.Add(cps);
                }
            }
            //var query = peopleCompanies.Select(p => p.Person).Distinct();
            //var result = query.ToList();
            var result = qp.Select(pp => pp.Key).ToList();
            context.People.AddRange(result);

            context.SaveChanges();


            Console.WriteLine("Gelukt!!");

        }

        private static void Initialize()
        {
            var fp = new Faker<Person>();
            fp //.RuleFor(p => p.Id, fk => fk.UniqueIndex)
                .RuleFor(p => p.FirstName, fk => fk.Name.FirstName())
                .RuleFor(p => p.LastName, fk => fk.Name.LastName())
                .RuleFor(p => p.Age, fk => fk.Random.Number(0, 123));

            people = fp.Generate(1000).ToList();

            companies = new Faker<Company>()
                //.RuleFor(c => c.Id, fk => fk.UniqueIndex)
                .RuleFor(c => c.Name, fk => fk.Company.CompanyName())
                .Generate(800)
                .ToList();

            peopleCompanies = new Faker<PersonCompany>()
                .RuleFor(p => p.Person, fk => fk.PickRandom(people))
                .RuleFor(p => p.Company, fk => fk.PickRandom(companies))
                .Generate(200)
                .ToList();


        }
    }
}
