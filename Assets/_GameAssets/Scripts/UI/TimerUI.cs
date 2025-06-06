using DG.Tweening;
using System;
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
    private bool _isTimerRunning;
    private Tween _rotationTween;
    private string _finalTime;

    private void Start()
    {
        

        GameManager.Instance.OnGmaeStateChanged += GameManager_OnGameStateChanged;
    }

    private void GameManager_OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                PlayRotationAnimaiton();
                StartTimer();
                break;
            case GameState.Pause:
                StopTimer();
                break;
            case GameState.Resume:
                ResumaTimer();
                break;
            case GameState.GameOver:
                FinishTimer();
                break;
        }
    }

    private void PlayRotationAnimaiton()
    {
        _rotationTween = _timerRotatableTransform.DORotate(new Vector3(0f, 0f, -360f), _rotationDuration,
            RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(_rotaitonEase);
    }

    private void StartTimer()
    {
        _isTimerRunning = true;
        _elapsedTime = 0f;
        InvokeRepeating(nameof(UpdateTimerUI), 0f, 1f);
    }

    private void StopTimer()
    {
        _isTimerRunning = false;
        CancelInvoke(nameof(UpdateTimerUI));
        _rotationTween.Pause();

    }

    private void ResumaTimer()
    {
        if (!_isTimerRunning)
        {
            _isTimerRunning = true;
            InvokeRepeating(nameof(UpdateTimerUI), 0f, 1f);
            _rotationTween.Play();
        }

    }

    private void FinishTimer()
    {
        StopTimer();
        _finalTime = GetFormattedElapsedTime();
    }
    private string GetFormattedElapsedTime()
    {
        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);

        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void UpdateTimerUI()
    {
        if(!_isTimerRunning) { return; }
        _elapsedTime += 1f;

        int minutes = Mathf.FloorToInt(_elapsedTime / 60f);

        int seconds = Mathf.FloorToInt(_elapsedTime % 60f);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public string GetFinalTime()
    {
        return _finalTime;
    }

}
