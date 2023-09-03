using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public List<Image> livesImages = new();

    public void ViewCountLives(int livesCount)
    {
        for (var i = 0; i < livesImages.Count; i++)
        {
             livesImages[i].gameObject.SetActive(i < livesCount);
        }
    }
}
