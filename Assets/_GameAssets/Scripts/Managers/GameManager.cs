using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public event Action<GameState> OnGmaeStateChanged;

    [Header("References")]

    [SerializeField] private CatController _catController;
    [SerializeField] private EggCounterUI _eggCounterUI;

    [SerializeField] private WinLoseUI _winLoseUI;

    [SerializeField] private PlayerHealthUI _playerHealthUI;

    [Header("Settings")]
    [SerializeField] private int _maxEggCount = 5;

    [SerializeField] private float _delay = .3f;

    private GameState _currentGameState;

    private int _currentEggCount;
    private bool _isCatCached;
    

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        HealthManager.Instance.OnPlayerDeath += HealthManager_OnPlayerDeath;
        _catController.OnCatCatched += CatController_OnCatCached;
    }

    private void CatController_OnCatCached()
    {
        if (!_isCatCached)
        {
            _playerHealthUI.AnimateDamageForAll();
            StartCoroutine(OnGameOver(true));
            CameraShake.Instance.ShakeCamera(1.5f, 2f, 0.5f);
            _isCatCached = true;
        }
       

       
    }

    private void HealthManager_OnPlayerDeath()
    {
        StartCoroutine(OnGameOver(false));
    }

    private void OnEnable()
    {
        ChangeGameState(GameState.CutScene);
        BackgroundMusic.Instance.PlayBackgroundMusic(true);
    }
    public void ChangeGameState(GameState gameState)
    {
        OnGmaeStateChanged?.Invoke(gameState);
        _currentGameState = gameState;
        Debug.Log("Game State" + gameState);
    }
    public void OnEggCollected()
    {
        _currentEggCount++;
        _eggCounterUI.SetEggCounterText(_currentEggCount, _maxEggCount);

        if(_currentEggCount == _maxEggCount)
        {
            //WIN
            _eggCounterUI.SetEggCompleted();
            ChangeGameState(GameState.GameOver);
            _winLoseUI.OnGameWin();
        }

        Debug.Log("Egg Count" + _currentEggCount);
    }

    private IEnumerator OnGameOver(bool isCatCached)
    {
        yield return new WaitForSeconds(_delay);
        ChangeGameState(GameState.GameOver);
        _winLoseUI.OnGameLose();
        if (isCatCached)
        {
             AudioManager.Instance.Play(SoundType.CatSound);
        }
       
    }
 
    public GameState GetCurrentGameState()
    {
        return _currentGameState;
    }


}
