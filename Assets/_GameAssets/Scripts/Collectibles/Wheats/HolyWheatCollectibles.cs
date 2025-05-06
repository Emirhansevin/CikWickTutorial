using UnityEngine;

public class HolyWheatCollectibles : MonoBehaviour, ICollectible
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _forcetIncrease, _resetBoostDuration;

    public void Collect()
    {
        _playerController.SetJumpForce(_forcetIncrease, _resetBoostDuration);
        Destroy(gameObject);
    }
}
