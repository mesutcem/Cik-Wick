using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    private PlayerController _playerController;

    void Awake()
    {
        _playerController = GetComponent<PlayerController>();
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
}
