
using System.Collections.Generic;
using System.Text;

namespace Words
{
    public class Fact
    {
        private readonly List<Word> _wordsInFact = new();
        
        public Fact(AllWordsList wordList, List<int> numbersOfWords)
        {
            foreach (var wordInt in numbersOfWords)
            {
                _wordsInFact.Add(wordList.GetWord(wordInt));
            }
        }

        public Fact(List<Word> words)
        {
            _wordsInFact = new List<Word>(words);
        }

        public string GetFact()
        {
            StringBuilder stringBuilder = new();

            foreach (var word in _wordsInFact)
            {
                stringBuilder.Append(word.GetWordForFacts);
                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }
    }
}