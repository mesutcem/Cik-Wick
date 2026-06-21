using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public event Action<GameState> OnGameStateChanged;  
    [Header("References")]
    [SerializeField] private EggCounterUI _eggCounter;
    [SerializeField] private WinLoseUI _winLoseUI;

    [Header("Settings")]
    [SerializeField] private int _maxEggCount;

    private GameState _currentGameState;
    private int _currentEggCount;

    private void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        ChangeGameState(GameState.Play);
    }

    public void ChangeGameState(GameState gameState)
    {
        OnGameStateChanged?.Invoke(gameState);
        _currentGameState = gameState;
        Debug.Log("Current Game State: " + gameState);
    }

    public void OnEggCollected()
    {
        _currentEggCount++;
        _eggCounter.SetEggCounterText(_currentEggCount, _maxEggCount);
        if(_currentEggCount == _maxEggCount)
        {
            //WIN
            _eggCounter.SetEggCompleted();

            ChangeGameState(GameState.GameOver);
            _winLoseUI.OnGameWin();
        }
    }

    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }
}
