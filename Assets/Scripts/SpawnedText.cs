using TMPro;
using UnityEngine;

public class SpawnedText : MonoBehaviour
{
    public TMP_Text text;
    public void SpawnText(string textToSpawn)
    {
        text.text = textToSpawn;
        
    }
}