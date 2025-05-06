
using UnityEngine;

public class GoldWheatCollectibles : MonoBehaviour, ICollectible
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movementIncreaseSpeed, _resetBoostDuration;

    public void Collect()
    {
        _playerController.SetMovementSpeed(_movementIncreaseSpeed, _resetBoostDuration);
        Destroy(gameObject);
    }
    
}
