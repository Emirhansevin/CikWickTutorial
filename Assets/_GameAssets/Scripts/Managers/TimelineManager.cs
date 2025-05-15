using System;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private PlayableDirector _palyableDirector;

    private void Awake()
    {
        _palyableDirector = GetComponent<PlayableDirector>();


    }
    private void OnEnable()
    {
        _palyableDirector.Play();
        _palyableDirector.stopped += OnTimelineFinished;
    }

    private void OnTimelineFinished(PlayableDirector director)
    {
        _gameManager.ChangeGameState(GameState.Play);
    }
}
