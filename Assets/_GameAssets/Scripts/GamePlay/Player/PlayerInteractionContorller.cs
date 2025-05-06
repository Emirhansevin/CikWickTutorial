

using UnityEngine;


public class PlayerInteractionContorller : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.TryGetComponent<ICollectible>(out var collectible))
        {
            collectible.Collect();
        }

       
    }
}
