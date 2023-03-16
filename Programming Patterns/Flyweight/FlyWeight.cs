using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Patterns.Flyweight
{
    public partial class Sentence
    {
        public List<WordToken> Tokens { get; set; } = new List<WordToken>();
        public List<string> EnumerableText { get; set; }

        public Sentence(string plainText) //CTOR
        {
            EnumerableText = plainText.Split(' ').ToList();
            Tokens = EnumerableText.Select(word => new WordToken()).ToList();
        }

        public WordToken this[int index] //Indexer
        {
            get { return Tokens[index]; }
        }

        private void AppendEveryWordRecorded(StringBuilder sb)
        {
            List<KeyValuePair<int, string>> multi = EnumerableText
                .Select((word, index) => new KeyValuePair<int, string>(index, word))
                .ToList();
            multi.ForEach(x => AppendWord(sb, x.Key, x.Value));
        }

        private void AppendWord(StringBuilder sb, int index, string currentWord)
        {
            string toAppend = CheckBeforeAppending(
                currentWord,
                tokenShouldBeCapitalized: Tokens[index].Capitalize,
                nextSpaceIsNotTrailing: index < Tokens.Count - 1
            );
            sb.Append(toAppend);
        }

        private static string CheckBeforeAppending(
            string currentWord,
            bool tokenShouldBeCapitalized,
            bool nextSpaceIsNotTrailing
        )
        {
            string toAppend = currentWord;

            if (tokenShouldBeCapitalized)
                toAppend = currentWord.ToUpper();
            if (nextSpaceIsNotTrailing)
                toAppend = $"{toAppend} ";

            return toAppend;
        }

        public override string ToString()
        {
            StringBuilder formated = new StringBuilder();
            AppendEveryWordRecorded(formated);
            return formated.ToString();
        }
    }
}
