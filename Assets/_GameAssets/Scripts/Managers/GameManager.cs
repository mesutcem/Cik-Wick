using System;
using System.Collections;
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
    [SerializeField] private float _delay;

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

    private IEnumerator OnGameOver()
    {
        yield return new WaitForSeconds(_delay);
        ChangeGameState(GameState.GameOver);
        _winLoseUI.OnGameLose();
    }

    public void PlayGameOver()
    {
        StartCoroutine(OnGameOver());
    }

    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    } 
}
