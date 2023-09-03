using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Words
{
    public class AllWordsList
    {
        
        public List<string> allFacts = new();
        public readonly List<Word> _wordList = new();
        public readonly List<Fact> _facts = new();

        private int _counter;
        private int _currentFact;
        public AllWordsList(string facts)
        {
            allFacts = new(facts.Split(";"));
            
            foreach (var fact in allFacts)
            {
                var wordString = fact.Split(' ');
                List<Word> words = new();
                foreach (var word in wordString)
                {
                    var completeWord = new Word(word, _counter);
                    _wordList.Add(completeWord);
                    words.Add(completeWord);
                    _counter++;
                }
                _facts.Add(new Fact(words));
            }

           
        }

        
        public Word GetWord(int id)
        {
            return _wordList[id];
        }

        public Word GetRandomWord()
        {
            var notUnlockedWords = _wordList.Where(x => x.IsUnlocked = false).ToList();
            return notUnlockedWords[Random.Range(0, _wordList.Count - 1)];
        }

        public Fact GetNextFact(out int factNumber)
        {
            
            _currentFact = (_currentFact + 1) % _facts.Count;
            factNumber = _currentFact;
            return _facts[_currentFact];
        }
        
        public Fact GetPreviousFact(out int factNumber)
        {
            _currentFact--;
            if (_currentFact == -1) 
                _currentFact += _facts.Count;
            factNumber = _currentFact;
            return _facts[_currentFact];
        }

        public void SaveAllUnlockedWordsId()
        {
            StringBuilder stringBuilder = new();
            for (var i = 0; i < _wordList.Count; i++)
            {
                if (_wordList[i].IsUnlocked)
                    stringBuilder.Append(i + ";");
            }
            PlayerPrefs.SetString("savedWords", stringBuilder.ToString());
        }

        public List<Word> GetRandomWords(int countWords)
        {
            var wordsList = new List<Word>();
            var notUnlockedWords =  _wordList.Where(x => x.IsUnlocked == false).ToList();
            for (int i = 0; i < countWords; i++)
            {

                wordsList.Add(notUnlockedWords[Random.Range(0, notUnlockedWords.Count - 1)]);
            }

            return wordsList;
        }
    }
}

