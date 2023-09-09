using Infrastructure.StateMachine;
using UnityEngine;
using Words;
using Zenject;

namespace Infrastructure.States
{
    public class GameStartState: IState
    {
        private AllWordsList _allWordsList;

        [Inject]
        public void Initialize(AllWordsList allWordsList)
        {
            _allWordsList = allWordsList;
        }
        public void Enter()
        {
            UnlockSavedWords();
        }

        public void Exit()
        {
            
        }
        
        public void UnlockSavedWords()
        {
            var unlockedWords = PlayerPrefs.GetString("savedWords", "none");
            if (unlockedWords == "none") return;
            var unlockedWordsStrings = unlockedWords.Split(';');
            foreach (var unlockedWordsString in unlockedWordsStrings)
            {
                if(int.TryParse(unlockedWordsString, out int number))
                    _allWordsList._wordList[number].IsUnlocked = true;
            }
        }
    }
}