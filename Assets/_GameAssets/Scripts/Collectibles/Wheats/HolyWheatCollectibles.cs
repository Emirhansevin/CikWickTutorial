using UnityEngine;
using UnityEngine.UI;

public class HolyWheatCollectibles : MonoBehaviour, ICollectible
{
    [SerializeField] private WheatDesignSO _wheatDesignSO;
    [SerializeField] private PlayerController _playerController;

    [SerializeField] private PlayerStateUI _playerStateUI;

    private RectTransform _playerboosterTransform;

    private Image _playerBoosterImage;

    private void Awake()
    {
        _playerboosterTransform = _playerStateUI.GetBoosterJumpTransform;
        _playerBoosterImage = _playerboosterTransform.GetComponent<Image>();
    }



    public void Collect()
    {
        _playerController.SetJumpForce(_wheatDesignSO.IncreaseDecreaseMultipler, _wheatDesignSO.ResetBoostDureation);

        _playerStateUI.PlayBoosterUIAnimations(_playerboosterTransform, _playerBoosterImage,
            _playerStateUI.GetHolyBoosterWheatImage, _wheatDesignSO.ActiveSprite,
            _wheatDesignSO.PassiveSprite, _wheatDesignSO.ActiveWheatSprite, _wheatDesignSO.PassiveWheatSprite,
            _wheatDesignSO.ResetBoostDureation);
        Destroy(gameObject);
    }
}
