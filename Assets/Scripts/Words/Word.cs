using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

namespace Words
{
    public class Word
    {
        public int Id;
        public bool IsUnlocked;
        public readonly string Label;
        private readonly string _cipher;

        public Word(string label, int id)
        {
            Id = id;
            Label = label;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append('?',label.Length);
            _cipher = stringBuilder.ToString();
        }

        public string GetWordForFacts => IsUnlocked ? Label : _cipher;

        public string UnlockWord()
        {
            IsUnlocked = true;
            return Label;
        }
    }
}