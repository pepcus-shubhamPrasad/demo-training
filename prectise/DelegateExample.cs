using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prectise
{
    class DelegateExample
    {
        delegate int MathOperation(int a, int b);

        static void Main(string[] args)
        {
            MathOperation add = (a, b) => a + b;
            MathOperation multiply = (a, b) => a * b;
            MathOperation substraction = (a, b) => a - b;
            MathOperation Devidation = (a, b) => a / b;

            Console.WriteLine("Addition: " + add(5, 10));
            Console.WriteLine("Multiplication: " + multiply(5, 10));

            Console.WriteLine("Custom Delegate:");
            PerformOperation(10, 20, add);
            PerformOperation(10, 20, multiply);
        }

        static void PerformOperation(int x, int y, MathOperation operation)
        {
            Console.WriteLine("Result: " + operation(x, y));
        }
    }
}
