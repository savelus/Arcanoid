using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Words;
using Object = UnityEngine.Object;

public class WordBlock : StoneBlock
{
    public SpawnedText spawnedWord;
    private AllWordsList _allWordsList;

    private Word _word;

    private UnityAction _checkEndAction;

    public void Initialize(Word word, UnityAction checkEndAction)
    {
        gameObject.SetActive(true);
        _checkEndAction = checkEndAction;
        _word = word;
    }

    protected override void OnCollisionEnter2D(Collision2D collision2D)
    {
        var unlockedWord = _word.UnlockWord();
        var word = Instantiate(spawnedWord, transform.position, Quaternion.identity);
        word.SpawnText(unlockedWord);
        DOTween.Sequence()
            .Append(word.transform.DOMoveY(10f, 6f))
           .AppendCallback(() => Destroy(word.gameObject));
            
        gameObject.SetActive(false);
        _checkEndAction?.Invoke();
    }
}