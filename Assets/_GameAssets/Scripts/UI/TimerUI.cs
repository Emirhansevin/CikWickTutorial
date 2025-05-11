using DG.Tweening;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform _timerRotatableTransform;

    [SerializeField] private TMP_Text _timerText;

    [Header("Settings")]

    [SerializeField] private float _rotationDuration;

    [SerializeField] private Ease _rotaitonEase;

    private float _elapsedTime;

    private void Start()
    {
        PlayRotationAnimaiton();
        StartTimer();
    }
    private void PlayRotationAnimaiton()
    {
        _timerRotatableTransform.DORotate(new Vector3(0f, 0f, -360f), _rotationDuration,
            RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(_rotaitonEase);
    }

    private void StartTimer()
    {
        _elapsedTime = 0f;
        InvokeRepeating(nameof(UpdateTimerUI), 0f, 1f);
    }
    private void UpdateTimerUI()
    {
        _elapsedTime += 1f;

        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);

        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
