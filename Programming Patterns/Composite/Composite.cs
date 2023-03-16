using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Patterns.Composite
{
    public interface IValueContainer
    {
        void Add(int value);
        IEnumerator<int> GetEnumerator();
    }

    public class SingleValue : IEnumerable<int>, IValueContainer
    {
        public int Value;

        public void Add(int value) => this.Value = value;

        public IEnumerator<int> GetEnumerator()
        {
            yield return Value;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ManyValues : List<int>, IValueContainer
    {
        IEnumerator<int> IValueContainer.GetEnumerator() => this.Select(i => i).GetEnumerator();
    }

    public static class ExtensionMethods
    {
        public static int Sum(this List<IValueContainer> containers)
        {
            int result = 0;
            foreach (var c in containers)
                foreach (var i in c)
                    result += i;
            return result;
        }
    }
}
