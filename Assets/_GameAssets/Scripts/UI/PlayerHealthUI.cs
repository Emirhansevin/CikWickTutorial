using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image[] _playerHealthImage;

    [Header("Sprites")]
    [SerializeField] private Sprite _playerHealthySprite;

    [SerializeField] private Sprite _playerUnhealthySprite;

    [Header("settings")]
    [SerializeField] private float _scaleDuration;


    private RectTransform[] _playerHealthTransforms;

    private void Awake()
    {
        _playerHealthTransforms = new RectTransform[_playerHealthImage.Length];

        for (int i = 0; i < _playerHealthImage.Length; i++)
        {
            _playerHealthTransforms[i] = _playerHealthImage[i].gameObject.GetComponent<RectTransform>();
            
        }

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            AnimiateDamage();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            AnimateDamageForAll();
        }
    }

    public void AnimiateDamage()
    {
        for (int i = 0; i < _playerHealthImage.Length; i++)
        {
            if (_playerHealthImage[i].sprite == _playerHealthySprite)
            {
                AnimateDamageSprite(_playerHealthImage[i], _playerHealthTransforms[i]);
                    
                break;
                
            }

        }
    }
    public void AnimateDamageForAll()
    {
        for (int i = 0; i < _playerHealthImage.Length; i++)
        {
             AnimateDamageSprite(_playerHealthImage[i], _playerHealthTransforms[i]);
            
        }
       
    }

    private void AnimateDamageSprite(Image activeImage , RectTransform activeImageTransform)
    {
        activeImageTransform.DOScale(0f, _scaleDuration).SetEase(Ease.InBack).OnComplete(() =>
        {
            activeImage.sprite = _playerUnhealthySprite;
            activeImageTransform.DOScale(1f, _scaleDuration).SetEase(Ease.OutBack);
        });
    }




}
