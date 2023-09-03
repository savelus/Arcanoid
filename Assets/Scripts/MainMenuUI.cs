using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Words;

public class MainMenuUI : MonoBehaviour
{
     public Button exitButton;
     public Button previousFactButton;
     public Button nextFactButton;

     public TMP_Text factNumberText;
     public TMP_Text factInfoText;

     public Button startGame;
     
     private AllWordsList _allWordsList;

     public void Initialize(AllWordsList allWordsList, LevelLoader levelLoader)
     {
          exitButton.onClick.AddListener(Application.Quit);
          _allWordsList = allWordsList;
          nextFactButton.onClick.AddListener(NextFact);
          previousFactButton.onClick.AddListener(PreviousFact);
          startGame.onClick.AddListener(() => levelLoader.StartLevel(OpenMainMenu));
          startGame.onClick.AddListener(CloseMainMenu);
     }

     private void PreviousFact()
     {
          var fact = _allWordsList.GetPreviousFact(out var factNumber);
          ChangeFact(factNumber, fact);
     }

     private void NextFact()
     {
          var fact = _allWordsList.GetNextFact(out var factNumber);
          ChangeFact(factNumber, fact);
     }

     private void ChangeFact(int factNumber, Fact fact)
     {
          factNumberText.text = $"Факт {factNumber  + 1}";
          factInfoText.text = fact.GetFact();
     }

     private void OpenMainMenu()
     {
          gameObject.SetActive(true);
          // NextFact();
          // PreviousFact();
     }
     private void CloseMainMenu()
     {
          gameObject.SetActive(false);
     }
}
