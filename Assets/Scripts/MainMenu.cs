using System.Collections;
using System.Collections.Generic;
using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Words;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [Space]
    public Button exitButton;
    public Button startGameButton;
    [Space]
    public Button previousFactButton;
    public Button nextFactButton;
    [Space]
    public TMP_Text factNumberText;
    public TMP_Text factInfoText;

    private AllWordsList _allWordsList;

    private int _currentFact;

    [Inject]
    public void Initialize(AllWordsList allWordsList)
    {
        _allWordsList = allWordsList;
    }

    public void LoadMenu()
    {
        exitButton.onClick.AddListener(Application.Quit);
        nextFactButton.onClick.AddListener(NextFact);
        previousFactButton.onClick.AddListener(PreviousFact);
        startGameButton.onClick.AddListener(StartGame);
    }
    
    public void UnloadMenu()
    {
        exitButton.onClick.RemoveAllListeners();
        nextFactButton.onClick.RemoveAllListeners();
        previousFactButton.onClick.RemoveAllListeners();
        startGameButton.onClick.RemoveAllListeners();
    }

    private void StartGame() => 
        GameStateMachine.Enter<LoadLevelState>();

    private void PreviousFact()
    {
        _currentFact--;
        ChangeFact();
    }

    private void NextFact()
    {
        _currentFact++;
        ChangeFact();
    }

    private void ChangeFact()
    {
        Fact fact = _allWordsList.GetFact(_currentFact);
        
        factNumberText.text = $"Факт {fact.FactNumber + 1}";
        factInfoText.text = fact.GetStringFact;
    }
}