using UnityEngine;

public class RottenWheatCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] public WheatDesignSO _wheatDesignSO;
    [SerializeField] private PlayerController _playerController;


    public void Collect()
    {
        _playerController.SetMovementSpeed(_wheatDesignSO.IncreaseDecreaseMultiplier, _wheatDesignSO.ResetBoostDuration);
        Destroy(this.gameObject);
    }
}
