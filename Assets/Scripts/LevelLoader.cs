using System;
using System.Collections.Generic;
using System.Linq;
using Configs;
using UnityEngine;
using UnityEngine.Serialization;
using Words;
using Zenject;
using Random = UnityEngine.Random;

public class LevelLoader : MonoBehaviour {
    //public Button exitButton;
    // public GameObject WinLevelScreen;
    // public GameObject LoseLevelScreen;
    public Lives Lives;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private LevelConfig[] _levels;
    [SerializeField] private Transform Parent;
    [SerializeField] private BlocksConfig blocks;
    
    private AllWordsList _allWords;
    private int _levelsCount;
    private InteractionObjects _interactionObjects;
    private DownBorder _downBorder;
    private GameObject _levelUI;
    
    private Vector2 _blockSize;
    private Vector2 _blocksGridStartPosition;
    private AllWordsList _allWordsList;

    private List<WordBlock> _allWordBlocks;
    private List<StoneBlock> _allCrushedBlocks;
    private List<ShieldBlock> _allShieldBlocks;
    
    [Inject]
    public void Construct(AllWordsList allWordsList) {
        _allWords = allWordsList;
    }
    private void Awake()
    {
        _canvas.worldCamera = Camera.main;
    }

    public void StartLevel()
    {
        _blockSize = blocks.BlockSize;
        var currentLevel = _levels[Random.Range(0, _levels.Length - 1)];
        
        SetupBlocks(currentLevel);
        SetupPlatform();
    }

    private void SetupPlatform()
    {
        
    }

    private void SetupBlocks(LevelConfig level)
    {
        _allWordBlocks.Clear();
        _allCrushedBlocks.Clear();
        _allShieldBlocks.Clear();
        
        var lines = level.Lines;
        _blocksGridStartPosition = GetBlocksGridStartPosition(lines[0].BlocksInLine.Length - 1, lines.Length);
        
        for (var numberOfLine = 0; numberOfLine < lines.Length; numberOfLine++)
            FillLine(lines[numberOfLine].BlocksInLine, numberOfLine);
    }

    private void FillLine(BlockType[] blocksInLine, int numberOfLine)
    {
        for (var numberOfColumn = 0; numberOfColumn < blocksInLine.Length; numberOfColumn++)
        {
            var blockTypeToSpawn = blocksInLine[numberOfColumn];
            var gameObjectToInstantiate = blocks.AllBlocks.FirstOrDefault(x => x.BlockType == blockTypeToSpawn);
            if (gameObjectToInstantiate == null)
                throw new NullReferenceException("Данного вида блоков не существует");
            
            var spawnPosition = GetBlockSpawnPosition(numberOfLine, numberOfColumn);
            Instantiate(gameObjectToInstantiate, 
                spawnPosition, 
                Quaternion.identity, 
                Parent);
            
            if (gameObjectToInstantiate is WordBlock wordBlock)
                InitializeWorldBlock(wordBlock);
            else if(gameObjectToInstantiate is ShieldBlock shieldBlock) 
                InitializeShieldBlock(shieldBlock);
        }
    }

    private Vector2 GetBlockSpawnPosition(int numberOfLine, int numberOfColumn) =>
        new Vector2(_blockSize.x * numberOfColumn, -_blockSize.y * numberOfLine) + _blocksGridStartPosition;

    private Vector2 GetBlocksGridStartPosition(int countColumns, int countRows) => 
        new(_blockSize.x * countColumns / -2, countRows * _blockSize.y);

    private void InitializeWorldBlock(WordBlock wordBlock)
    {
        _allWordBlocks.Add(wordBlock);
        _allCrushedBlocks.Add(wordBlock);
        var word = _allWords.GetRandomWord();
        wordBlock.Initialize(word, PreDestroyWordBlockAction);
    }

    private void InitializeShieldBlock(ShieldBlock shieldBlock)
    {
        _allShieldBlocks.Add(shieldBlock);
        _allCrushedBlocks.Add(shieldBlock);
        shieldBlock.Initialize();
    }

    private void PreDestroyWordBlockAction(WordBlock wordBlock)
    {
        _allWordBlocks.Remove(wordBlock);
        _allCrushedBlocks.Remove(wordBlock);
    }
    
    
}
