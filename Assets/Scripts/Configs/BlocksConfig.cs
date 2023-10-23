using System.Collections.Generic;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "AllBlocks", menuName = "Configs/Blocks")]
    public class BlocksConfig : ScriptableObject
    {
        public Vector2 BlockSize;
        public List<StoneBlock> AllBlocks;
    }
}