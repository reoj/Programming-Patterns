using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
    public class CodeBuilder
    {
        public string ClassName { get; set; }
        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();

        public CodeBuilder(string className)
        {
            ClassName = className;
        }

        public CodeBuilder AddField(string name, string type)
        {
            Fields.Add(name, type);
            return this;
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();
            description.AppendLine($"public class {ClassName}").AppendLine("{");
            foreach (KeyValuePair<string, string> item in Fields)
            {
                description.AppendLine($"  public {item.Value} {item.Key};");
            }
            description.AppendLine("}");
            return description.ToString();
        }
    }
}
