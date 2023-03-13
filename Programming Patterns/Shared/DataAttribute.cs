using System.Reflection;

namespace Programming_Patterns.Shared
{
    [AttributeUsage(System.AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class Printable : Attribute
    {
        public string Label { get; init; }
        public string? Unit { get; init; }
        public string DefaultDescription { get; } = "Not Specified";

        public Printable(string label, string? unit = null, string? defaultDesctipion = null)
        {
            Label = label;
            Unit = unit;
            DefaultDescription = defaultDesctipion is not null
                ? defaultDesctipion
                : $"{label} not specified";
        }
    }
}
