using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace prectise
{
    // seald for any further inheritence
    public sealed class Singleton
    {
        private static Singleton instance = null;
        // thread safe 
        private static object locker = new object();
        private Singleton() // private for no one create object of this class
        {
        }

        //  will check whether the instance is null, if yes then it will create the new instance and 
        //  if no then it will return the same instance 
        public static Singleton GetInstance()
        { 
            if (instance == null)//  double lock thrad check
            {
                lock (locker) // lock for thread safe
                {
                    if (instance == null)
                        instance = new Singleton();
                } 
            }

            return instance;
        }
        // getting user help of singleton 
        public void Mehtod()
        {
            Console.WriteLine("Method Created from signleton");
        }
    }
    // normal classs without singleton
    public class NonSingleton
    {
        public void method()
        {
            Console.WriteLine("Method Created from NonSignleton");
        }
    }

}
