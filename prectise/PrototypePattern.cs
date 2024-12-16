using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prectise
{
    public class PrototypePattern
    {
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public Address address { get; set; }

        public PrototypePattern ShallowClone()
        {
            return new PrototypePattern { Age = Age, BirthDate = BirthDate, Name = Name  , address = address};
        }

        public PrototypePattern DeepClone()
        {
            return new PrototypePattern { Age = Age, BirthDate = BirthDate, Name = Name, address = new Address(address.Housenumber) };
        }
        public override string ToString()
        {
            return $"Name : {Name} , Age : {Age} , BirthDate : {BirthDate} , Address : {address.Housenumber}";
        }
    }

    public class Address
    {
        public int Housenumber { get; set; }

        public Address(int Housenumber)
        {
            this.Housenumber = Housenumber;
        }
    }
}
