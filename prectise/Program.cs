using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static prectise.FactoryDesign;
using static prectise.ObserverPatterns;

namespace prectise
{
    public class Program
    {
        delegate void PrintMessage(string message);
        static void Main(string[] args)
        {
            // observerDesign Patterns example start
            WeatherStation weatherStation = new WeatherStation();

            //create observer

            PhoneDisplay phoneDisplay = new PhoneDisplay();
            WindowDisplay windowDisplay = new WindowDisplay();

            // Attach Observers
            weatherStation.Attach(phoneDisplay);
            weatherStation.Attach(windowDisplay);

            // Update Weather Station's temperature
            weatherStation.Temperature = 25.0f;
            weatherStation.Temperature = 30.0f;

            // Detach an observer
            weatherStation.Detach(phoneDisplay);

            // Update temperature again
            weatherStation.Temperature = 35.0f;

            // observerDesign Patterns example end

            // singleton and nonsingletone exapmle ###start

            Singleton obj =  Singleton.GetInstance();
            obj.Mehtod(); 


            NonSingleton  obj1 = new NonSingleton();
            obj1.method();

            // singleton and nonsingletone exapmle ##end


            // factory Design Parten start

            waiter  waiter = new waiter();
            IPizza pizza = waiter.GetPizza("NonVeg");
            Console.WriteLine(pizza.Eat());

            // factory Design Parten End


            // Prototype Design Parten Start

            PrototypePattern pattern1 = new PrototypePattern
            {
                Name = "Shubham",
                Age = 27,
                BirthDate = Convert.ToDateTime("1997-11-28"),
                address = new Address(10)
            };
            PrototypePattern pattern2 = pattern1.DeepClone(); 
            pattern1.address.Housenumber = 12; 

            Console.WriteLine(pattern2); 


            // Prototype Design Parten End


            // assign method to deligates
            PrintMessage print = DisplayMessage;
            print("Hello");

            print = (msg) => Console.WriteLine($"Lambda says: {msg}");
            print("Delegates are fun!");

            Console.ReadLine();
        }

        static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
