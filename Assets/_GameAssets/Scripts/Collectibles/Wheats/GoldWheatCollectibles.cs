
using UnityEngine;

public class GoldWheatCollectibles : MonoBehaviour, ICollectible
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movementIncreaseSpeed, _resetBoostDuration;

    public void Collect()
    {
        _playerController.SetMovementSpeed(_wheatDesignSO.IncreaseDecreaseMultipler, _wheatDesignSO.ResetBoostDureation);
        Destroy(gameObject);
    }
    
}
