namespace Programming_Patterns.Proxy.Models
{
    public class Person
    {
        public int Age { get; set; }

        public string Drink() => "drinking";

        public string Drive() => "driving";

        public string DrinkAndDrive() => "driving while drunk";
    }
}
