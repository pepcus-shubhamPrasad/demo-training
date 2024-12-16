using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace prectise
{
    class ReflectionExample
    {
        static void Main(string[] args)
        {
            Type type = typeof(Person);
            Console.WriteLine($"Class: {type.Name}");

            Console.WriteLine("\nProperties:");
            foreach (var prop in type.GetProperties())
                Console.WriteLine(prop.Name);

            Console.WriteLine("\nMethods:");
            foreach (var method in type.GetMethods())
                Console.WriteLine(method.Name);

            Console.WriteLine("\nInvoking Method:");
            var person = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Greet");
            methodInfo.Invoke(person, new object[] { "Shubham" });
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void Greet(string name)
            {
                Console.WriteLine($"Hello, {name}!");
            }
        }
    }
}
