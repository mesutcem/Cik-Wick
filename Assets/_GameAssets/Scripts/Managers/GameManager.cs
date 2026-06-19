using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    [Header("References")]
    [SerializeField] private EggCounterUI _eggCounter;

    [Header("Settings")]
    [SerializeField] private int _maxEggCount;
    private int _currentEggCount;

    private void Awake()
    {
        Instance = this;
    }

    public void OnEggCollected()
    {
        _currentEggCount++;
        _eggCounter.SetEggCounterText(_currentEggCount, _maxEggCount);
        if(_currentEggCount == _maxEggCount)
        {
            //WIN

            Debug.Log("Game won");
            _eggCounter.SetEggCompleted();
        }

        Debug.Log("Egg count: " + _currentEggCount);
    }
}
