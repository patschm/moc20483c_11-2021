using System;

namespace SomeLibrary
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private int age;

        public int Age
        {
            get { return age; }
            set {
                if (value >= 0 && value < 123)
                    age = value; 
            }
        }

        public void Show()
        {
            Console.WriteLine($"{FirstName} {LastName} {Age}");
        }
    }
}
