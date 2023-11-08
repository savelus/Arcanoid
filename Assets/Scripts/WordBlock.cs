using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Words;

public class WordBlock : StoneBlock
{
    public SpawnedText spawnedWord;

    private Word _word;

    private UnityAction<WordBlock> _preDestroyAction;

    public void Initialize(Word word, UnityAction<WordBlock> preDestroyAction)
    {
        gameObject.SetActive(true);
        _preDestroyAction = preDestroyAction;
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
            
       _preDestroyAction?.Invoke(this);
       
       Destroy(this);
    }
}