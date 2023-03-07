using System.Reflection;
using System.Text;

namespace Programming_Patterns.Shared
{
    public class DataClassPrinter<T>
    {
        public T InstanceToPrint { get; set; }
        public StringBuilder Description { get; set; }
        private Type InstanceType = typeof(T);

        public DataClassPrinter(T instanceToPrint, string starterString)
        {
            this.InstanceToPrint = instanceToPrint;
            Description = new StringBuilder(starterString);
        }

        public string ProduceToString()
        {
            List<PropertyInfo> TClassProperties = GetAllInstanceProperties();
            Dictionary<PropertyInfo, Printable> printableProps = FilterForPrintable(
                TClassProperties
            );
            foreach (KeyValuePair<PropertyInfo, Printable> attributePropPair in printableProps)
                Description.Append(GenerateLabeledProperty(attributePropPair));

            return this.Description.ToString();
        }

        private static Dictionary<PropertyInfo, Printable> FilterForPrintable(
            List<PropertyInfo> classProperties
        )
        {
            return classProperties
                .Where(prop => prop.GetCustomAttribute<Printable>() is not null)
                .ToDictionary(
                    prop => prop,
                    prop =>
                        prop.GetCustomAttribute<Printable>() ?? throw new NullReferenceException()
                );
        }

        private List<PropertyInfo> GetAllInstanceProperties() =>
            InstanceType.GetProperties().ToList();

        private string GetPropertyValueOrDefault(PropertyInfo prop, string defaultValue) =>
            prop.GetValue(this.InstanceToPrint)?.ToString() ?? defaultValue;

        private string GenerateLabeledProperty(KeyValuePair<PropertyInfo, Printable> pair)
        {
            PropertyInfo extractedProperty = pair.Key;
            Printable attributeInfo = pair.Value;
            return new StringBuilder()
                .Append(attributeInfo.Label)
                .Append(": ")
                .AppendLine(
                    GetPropertyValueOrDefault(extractedProperty, attributeInfo.DefaultDescription)
                )
                .ToString();
        }
    }
}
