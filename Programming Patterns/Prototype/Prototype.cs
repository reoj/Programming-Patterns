using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programming_Patterns.Prototype
{
    public class Prototype : ICloneable
    {
        public int ID { get; set; }
        public NotInheritant Namer { get; set; }
        public void DoesPrototypeThings()
        {
            Console.WriteLine("This is the functionality of the prototype.");
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public override string ToString()
        {
            return $"ID: {ID}, Namer: {Namer.Name}";
        }
    }
}
