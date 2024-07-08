using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Patterns.Prototype
{
    public class UsePrototype
    {
        Prototype firstInstance;
        Prototype secondInstance;

        public void Run()
        {
            firstInstance = new Prototype() { ID = 1 };
            secondInstance = (Prototype)firstInstance.Clone();
            secondInstance.ID = 2;
            secondInstance.Namer = new NotInheritant("NotInheritant");
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(firstInstance.ToString());
            sb.AppendLine(secondInstance.ToString());
            return sb.ToString();
        }
    }
}
