using System;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = "Configs/LevelConfig", fileName = "Level")]
    public class LevelConfig : ScriptableObject
    {
        [Range(0,3)]
        public int CountLives;
        [Space]
        public LevelLine[] Lines;
    }

    [Serializable]
    public class LevelLine
    {
        public BlockType[] BlocksInLine;
    }
    
}