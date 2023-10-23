using System;
using System.Linq;
using Configs;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Serialization;
using Words;
using Random = UnityEngine.Random;

public class LevelLoader : MonoBehaviour
{
    //public Button exitButton;
    // public GameObject WinLevelScreen;
    // public GameObject LoseLevelScreen;
    public Lives Lives;
    private AllWordsList _allWords;
    private int _levelsCount;
    private InterractionObjects _interractionObjects;
    private DownBorder _downBorder;
    private GameObject _levelUI;
    [SerializeField] private Canvas _canvas;

    [SerializeField] private LevelConfig[] _levels;
    [FormerlySerializedAs("LevelLeftUpPosition")] [SerializeField] private Transform Parent;
    [SerializeField] private BlocksConfig blocks;
    private Vector2 _blockSize;
    private Vector2 _blocksGridStartPosition;

    private void Awake()
    {
        _canvas.worldCamera = Camera.main;
    }

    public void StartLevel()
    {
        _blockSize = blocks.BlockSize;
        var currentLevel = _levels[Random.Range(0, _levels.Length - 1)];
        SetupBlocks(currentLevel);
    }

    private void SetupBlocks(LevelConfig level)
    {
        var lines = level.Lines;
        _blocksGridStartPosition = GetBlocksGridStartPosition(lines[0].BlocksInLine.Length - 1, lines.Length);
        for (var numberOfLine = 0; numberOfLine < lines.Length; numberOfLine++)
        {
            FillLine(lines[numberOfLine].BlocksInLine, numberOfLine);
        }
    }

    private void FillLine(BlockType[] blocksInLine, int numberOfLine)
    {
        for (var numberOfColumn = 0; numberOfColumn < blocksInLine.Length; numberOfColumn++)
        {
            var gameObjectToInstantiate = blocks.AllBlocks.FirstOrDefault(x => x.BlockType == blocksInLine[numberOfColumn]);
            if (gameObjectToInstantiate == null)
                throw new NullReferenceException("Данного вида блоков не существует");
            var spawnPosition = GetBlockSpawnPosition(numberOfLine, numberOfColumn);
            Instantiate(gameObjectToInstantiate, 
                spawnPosition, 
                Quaternion.identity, 
                Parent);
        }
    }

    private Vector2 GetBlockSpawnPosition(int numberOfLine, int numberOfColumn) =>
        new Vector2(_blockSize.x * numberOfColumn, -_blockSize.y * numberOfLine) + _blocksGridStartPosition;

    private Vector2 GetBlocksGridStartPosition(int countColumns, int countRows) => 
        new(_blockSize.x * countColumns / -2, countRows * _blockSize.y);
}
