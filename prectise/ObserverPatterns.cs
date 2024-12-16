using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prectise
{
    public class ObserverPatterns
    {
        // Observer Interface
        public interface IObserver
        {
            void Update(float temperature);
        }

        // Subject Interface
        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }

        public class WeatherStation : ISubject
        {
            private readonly List<IObserver> _observers = new List<IObserver>();
            private float _temperature;

            public float Temperature
            {
                get => _temperature;
                set
                {
                    _temperature = value;
                    Notify();
                }
            }
            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            public void Detach(IObserver observer)
            {
                _observers.Remove(observer);
            }

            public void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(_temperature);
                }
            }
        }
        public class PhoneDisplay : IObserver
        {
            public void Update(float temperature)
            {
                Console.WriteLine($"PhoneDisplay: Current Temperature is {temperature}°C");
            }
        }

        public class WindowDisplay : IObserver
        {
            public void Update(float temperature)
            {
                Console.WriteLine($"WindowDisplay: Current Temperature is {temperature}°C");
            }
        }
    }
}
