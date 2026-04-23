using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Consts.WheatTypes.GOLD_WHEAT))
        {
            Debug.Log("Gold Wheat Collected!");
            other.gameObject?.GetComponent<GoldWheatCollectable>().Collect();
        }
                if(other.CompareTag(Consts.WheatTypes.HOLY_WHEAT))
        {
            Debug.Log("Holy Wheat Collected!");
            other.gameObject?.GetComponent<HolyWheatCollectable>().Collect();
        }
                if(other.CompareTag(Consts.WheatTypes.ROTTEN_WHEAT))
        {
            Debug.Log("Rotten Wheat Collected!");
            other.gameObject?.GetComponent<RottenWheatCollectable>().Collect();
        }
    }
}
