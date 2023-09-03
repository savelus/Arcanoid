using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Words;

public class LevelLoader : MonoBehaviour
{
    public Button exitButton;
    public List<Level> levels = new();
    public GameObject winLevelScreen;
    public GameObject loseLevelScreen;
    
    private LivesUI _livesUI;
    private AllWordsList _allWords;
    private int _levelsCount;
    private InterractionObjects _interractionObjects;
    private DownBorder _downBorder;
    private GameObject _levelUI;

    public void Initialize(AllWordsList allWords, LivesUI livesUI, InterractionObjects interractionObjects, DownBorder downBorder, GameObject levelUI)
    {
        _levelUI = levelUI;
        _downBorder = downBorder;
        _interractionObjects = interractionObjects;
        _livesUI = livesUI;
        _allWords = allWords;
        _levelsCount = levels.Count;
    }
    public void StartLevel(UnityAction openMainMenu)
    {
        _levelUI.SetActive(true);
        levels[Random.Range(0, _levelsCount - 1)].Initialize(_allWords, _livesUI, _interractionObjects, _downBorder, openMainMenu, winLevelScreen, loseLevelScreen, exitButton);
    }
}
