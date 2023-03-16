using Programming_Patterns.Proxy.Models;

namespace Programming_Patterns.Proxy
{
    public class ResponsiblePerson
    {
        public Person Responsible { get; set; }
        public int Age { get; set; }

        public ResponsiblePerson(Person person)
        {
            Responsible = person;
            this.Age = person.Age;
        }

        public string Drink()
        {
            bool isUnderage = Age >= 18;
            return isUnderage ? Responsible.Drink() : "too young";
        }
        public string Drive()
        {
            bool isUnderage = Age >= 16;
            return isUnderage ? Responsible.Drive() : "too young";
        }
        public string DrinkAndDrive() => "dead";
    }
}
