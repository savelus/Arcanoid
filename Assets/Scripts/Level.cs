using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Words;

public class Level : MonoBehaviour
{
    public List<WordBlock> wordBlocks;
    public List<StoneBlock> allCrushedBlocks;
    public List<ShieldBlock> allShieldBlocks;
    public GameObject ballPosition;
    public int StartLivesCount = 3;
    
    public  int CurrentLivesCount
    {
        get => _currentLivesCount;
        private set
        {
            _currentLivesCount = value;
            UpdateViewLives();
        }
    }

    private int _currentLivesCount;
    private Lives _lives;
    private InterractionObjects _interractionObjects;
    private AllWordsList _allWordsList;
    private UnityAction _openMainMenuAction;
    private GameObject _loseLevelScreen;
    private GameObject _winLevelScreen;

    public void Initialize(AllWordsList allWords, 
        Lives lives, 
        InterractionObjects interractionObjects, 
        DownBorder downBorder, 
        UnityAction openMainMenuAction, 
        GameObject winLevelScreen, 
        GameObject loseLevelScreen,
        Button exitButton)
    {
        
        _winLevelScreen = winLevelScreen;
        _loseLevelScreen = loseLevelScreen;
        _openMainMenuAction = openMainMenuAction;
        _allWordsList = allWords;
        _lives = lives;
        _interractionObjects = interractionObjects;
        _interractionObjects.gameObject.SetActive(true);
        _lives.gameObject.SetActive(true);
        downBorder.Initialize(LoseLive);
        gameObject.SetActive(true);
        interractionObjects.ball.Initialize(ballPosition.transform.position);
        
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(LoseLevel);
    }

    public void StartLevel(AllWordsList allWordsList)
    {
        CurrentLivesCount = StartLivesCount;
        InitializeWordBlocks(allWordsList.GetRandomWords(wordBlocks.Count));
        InitializeShields();
    }

    private void InitializeWordBlocks( List<Word> wordsForBlocks)
    {
        for (var i = 0; i < wordBlocks.Count; i++)
        {
            var wordBlock = wordBlocks[i];
            wordBlock.Initialize(wordsForBlocks[i], CheckEndLevel);
        }
    }

    private void InitializeShields()
    {
        if (allShieldBlocks.Count <= 0) return;
        foreach (var shieldBlock in allShieldBlocks) 
            shieldBlock.Initialize(CheckEndLevel);
    }

    private void LoseLive()
    {
        CurrentLivesCount--;
        _interractionObjects.ball.gameObject.SetActive(false);
        _interractionObjects.ball.Initialize(ballPosition.transform.position);
        if (CurrentLivesCount <= 0)
        {
            _interractionObjects.ball.ballRigidbody.AddForce(Vector2.zero);
            LoseLevel();
        }
        
    }

    private void LoseLevel()
    {
        gameObject.SetActive(false);
        _interractionObjects.gameObject.SetActive(false);
        _lives.gameObject.SetActive(false);
        _openMainMenuAction?.Invoke();
        _loseLevelScreen.SetActive(true);
        
    }

    public void UpdateViewLives()
    {
        _lives.ViewCountLives(CurrentLivesCount);
    }

    public void CheckEndLevel()
    {
        foreach (var crushedBlock in allCrushedBlocks)
        {
            if (crushedBlock.gameObject.activeSelf)
            {
                return;
            }
        }
        EndLevel();
    }

    private void EndLevel()
    {
        _allWordsList.SaveAllUnlockedWordsId();
        _interractionObjects.gameObject.SetActive(false);
        _lives.gameObject.SetActive(false);
        gameObject.SetActive(false);
        _openMainMenuAction?.Invoke();
        _winLevelScreen.SetActive(true);
    }
}
