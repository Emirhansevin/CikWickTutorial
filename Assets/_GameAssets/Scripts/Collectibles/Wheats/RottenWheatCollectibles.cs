using UnityEngine;

public class RottenWheatCollectibles : MonoBehaviour, ICollectible
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movementDecreaseSpeed, _resetBoostDuration;

    public void Collect()
    {
        _playerController.SetMovementSpeed(_movementDecreaseSpeed, _resetBoostDuration);
        Destroy(gameObject);
    }
}
