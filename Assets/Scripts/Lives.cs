using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public List<Image> livesImages = new();

    public void ViewCountLives(int livesCount)
    {
        if (IsIncorrectCountLives(livesCount)) return;

        for (var i = 0; i < livesImages.Count; i++)
        {
             livesImages[i].gameObject.SetActive(i < livesCount);
        }
    }

    private bool IsIncorrectCountLives(int livesCount)
    {
        if (livesCount is >= 0 and <= 3) return false;
        print($"{GetType().Name}: Ввод неправильного количества жизней");
        return true;
    }
}
