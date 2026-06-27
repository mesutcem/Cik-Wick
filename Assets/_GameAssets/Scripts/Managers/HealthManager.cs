using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerHealthUI _playerHealthUI;
    
    [Header("Settings")]
    [SerializeField] private int _maxHealth = 3;

    public static HealthManager Instance {get; private set;}
    private int _currentHealth;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void Damage(int damageAmount)
    {
        if(_currentHealth > 0)
        {
            _currentHealth -= damageAmount;
            _playerHealthUI.AnimateDamage();
            
        }
        if(_currentHealth <= 0)
        {
            GameManager.Instance.PlayGameOver(); 
        }
    }

    public void Heal(int healAmount)
    {
        if(_currentHealth < _maxHealth)
        {
            _currentHealth = Mathf.Min(_currentHealth + healAmount, _maxHealth);
        }
    }
}
