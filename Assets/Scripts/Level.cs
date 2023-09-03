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
    private int _currentLives = 3;
    private LivesUI _livesUI;
    private InterractionObjects _interractionObjects;
    private AllWordsList _allWords;
    private UnityAction _openMainMenuAction;
    private GameObject _loseLevelScreen;
    private GameObject _winLevelScreen;

    public void Initialize(AllWordsList allWords, 
        LivesUI livesUI, 
        InterractionObjects interractionObjects, 
        DownBorder downBorder, 
        UnityAction openMainMenuAction, 
        GameObject winLevelScreen, 
        GameObject loseLevelScreen,
        Button exitButton)
    {
        _currentLives = 3;
        _winLevelScreen = winLevelScreen;
        _loseLevelScreen = loseLevelScreen;
        _openMainMenuAction = openMainMenuAction;
        _allWords = allWords;
        _livesUI = livesUI;
        _interractionObjects = interractionObjects;
        _interractionObjects.gameObject.SetActive(true);
        _livesUI.gameObject.SetActive(true);
        UpdateViewLives();
        downBorder.Initialize(LoseLive);
        gameObject.SetActive(true);
        var wordsForBlocks = allWords.GetRandomWords(wordBlocks.Count);
        for (var i = 0; i < wordBlocks.Count; i++)
        {
            var wordBlock = wordBlocks[i];
            wordBlock.Initialize(wordsForBlocks[i], CheckEndLevel);
        }

        if (allShieldBlocks.Count > 0)
        {
            foreach (var shieldBlock in allShieldBlocks)
            {
                shieldBlock.Initialize(CheckEndLevel);
            }
        }

        interractionObjects.ball.Initialize(ballPosition.transform.position);
        
        exitButton.onClick.RemoveAllListeners();
        exitButton.onClick.AddListener(LoseLevel);
    }

    private void LoseLive()
    {
        _currentLives--;
        UpdateViewLives();
        _interractionObjects.ball.gameObject.SetActive(false);
        _interractionObjects.ball.Initialize(ballPosition.transform.position);
        if (_currentLives <= 0)
        {
            _interractionObjects.ball.ballRigidbody.AddForce(Vector2.zero);
            LoseLevel();
        }
        
    }

    private void LoseLevel()
    {
        gameObject.SetActive(false);
        _interractionObjects.gameObject.SetActive(false);
        _livesUI.gameObject.SetActive(false);
        _openMainMenuAction?.Invoke();
        _loseLevelScreen.SetActive(true);
        
    }

    public void UpdateViewLives()
    {
        _livesUI.ViewCountLives(_currentLives);
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
        _allWords.SaveAllUnlockedWordsId();
        _interractionObjects.gameObject.SetActive(false);
        _livesUI.gameObject.SetActive(false);
        gameObject.SetActive(false);
        _openMainMenuAction?.Invoke();
        _winLevelScreen.SetActive(true);
    }
}
