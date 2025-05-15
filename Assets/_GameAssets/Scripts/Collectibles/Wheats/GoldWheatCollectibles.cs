
using UnityEngine;
using UnityEngine.UI;

public class GoldWheatCollectibles : MonoBehaviour, ICollectible
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _movementIncreaseSpeed, _resetBoostDuration;
    [SerializeField] private PlayerStateUI _playerStateUI;

    private RectTransform _playerboosterTransform;

    private Image _playerBoosterImage;

    private void Awake()
    {
        _playerboosterTransform = _playerStateUI.GetBoosterSpeedTransform;
        _playerBoosterImage = _playerboosterTransform.GetComponent<Image>();
    }

    public void Collect()
    {
        _playerController.SetMovementSpeed(_wheatDesignSO.IncreaseDecreaseMultipler, _wheatDesignSO.ResetBoostDureation);

        _playerStateUI.PlayBoosterUIAnimations(_playerboosterTransform, _playerBoosterImage,
            _playerStateUI.GetGoldBoosterWheatImage, _wheatDesignSO.ActiveSprite,
            _wheatDesignSO.PassiveSprite, _wheatDesignSO.ActiveWheatSprite, _wheatDesignSO.PassiveWheatSprite,
            _wheatDesignSO.ResetBoostDureation);
        CameraShake.Instance.ShakeCamera(0.5f, 0.5f);
        AudioManager.Instance.Play(SoundType.PickupGoodSound);

        Destroy(gameObject);
    }
    
}
