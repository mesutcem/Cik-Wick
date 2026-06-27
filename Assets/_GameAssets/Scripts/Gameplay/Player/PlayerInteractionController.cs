using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField] private Transform _playerVisualTransform;
    private PlayerController _playerController;
    private Rigidbody _playerRigidbody;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<ICollectable>(out var collectable))
        {
            collectable.Collect();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent<IBoostables>(out var boostables))
        {
            boostables.Boost(_playerController);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.TryGetComponent<IDamageables>(out var damageables))
        {
            damageables.GiveDamage(_playerRigidbody, _playerVisualTransform);
        }
    }
}
