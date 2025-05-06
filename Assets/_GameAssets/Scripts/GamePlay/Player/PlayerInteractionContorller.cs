

using UnityEngine;


public class PlayerInteractionContorller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("GoldWheat"))
        {
            other.gameObject?.GetComponent<GoldWheatCollectibles>().Collect();
        }
        if (other.CompareTag("HolyWheat"))
        {
            other.gameObject?.GetComponent<HolyWheatCollectibles>().Collect();
        }
        if (other.CompareTag("RottenWheat"))
        {
            other.gameObject?.GetComponent<RottenWheatCollectibles>().Collect();
        }
    }
}
