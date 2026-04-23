using UnityEngine;

public class HolyWheatCollectable : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _jumpIncrease;
    [SerializeField] private float _resetBoostDuration;

    public void Collect()
    {
        _playerController.SetJumpForce(_jumpIncrease, _resetBoostDuration);
        Destroy(this.gameObject);
    }
}
