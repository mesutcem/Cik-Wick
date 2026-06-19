using UnityEngine;

public class EggCollactable : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        GameManager.Instance.OnEggCollected();
        Destroy(gameObject);
    }
}
