using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prectise
{
    public class FactoryDesign
    {
        public interface IPizza
        {
            string Eat();
        }

        class VegPizza : IPizza
        {
            public string Eat()
            {
                return "Eating Veg Pizza";
            }
        }
        class NonVegPizza : IPizza
        {
            public string Eat()
            {
                return "Eating NonVeg Pizza";
            }
        }

        interface IpizzaChef // Factory
        {
            IPizza PreparePizza();
        }

        class VegPizzaChef : IpizzaChef
        {
            public IPizza PreparePizza()
            {
                return new VegPizza();
            }
        }

        class NonVegPizzaChef : IpizzaChef
        {
            public IPizza PreparePizza()
            {
                return new NonVegPizza();
            }
        }

        // final class Waiter client 

        public class waiter// client 
        {
            public IPizza GetPizza(string type)
            {
                IpizzaChef chef;

                switch (type)
                {
                    case "Veg":
                        chef = new VegPizzaChef();
                        break;
                    default:
                        chef = new NonVegPizzaChef();
                        break;
                }
                return chef.PreparePizza();
            }
        }
    }
}
