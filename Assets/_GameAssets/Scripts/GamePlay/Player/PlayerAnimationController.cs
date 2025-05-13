using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private PlayerController _playerController;
    private StateController _stateController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _stateController = GetComponent<StateController>();
    }
    private void Start()
    {
        _playerController.OnPlayerJumped += PlayerController_OnPlayerJumped;
    }

   

    private void Update()
    {
        if (GameManager.Instance.GetCurrentGameState() != GameState.Play
            && GameManager.Instance.GetCurrentGameState() != GameState.Resume)
        {
            return;
        }
        SetPlayerAnimations();


    }

    private void PlayerController_OnPlayerJumped()
    {
        _playerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMP�NG, true);
        Invoke(nameof(ResetJumping), 0.5f);


    }
    private void ResetJumping()
    {
        _playerAnimator.SetBool(Consts.PlayerAnimations.IS_JUMP�NG, false);
    }

    private void SetPlayerAnimations()
    {
        var currentState = _stateController.GetCurrentState();

       
        switch(currentState)
        {
            case PlayerState.Idle:
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING,false);
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_MOV�NG, false);
                break;
            case PlayerState.Move:
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, false);
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_MOV�NG, true);
                break;

            case PlayerState.SlideIdle:
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, true);
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACT�VE, false);
                break;
            case PlayerState.Slide:
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING, true);
                _playerAnimator.SetBool(Consts.PlayerAnimations.IS_SLIDING_ACT�VE, true);
                break;
        }
    }
}
