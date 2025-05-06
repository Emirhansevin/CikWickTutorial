using UnityEngine;

public class SpatulaBooster : MonoBehaviour, IBoostable
{

    [SerializeField] private Animator _spatulaAnimator;

    [Header("Settings")]
    [SerializeField] private float _jumpForce;
    private bool _isActivated;
    public void Boost(PlayerController playerController)
    {

        if(_isActivated) { return; }
        PlayBoostAnimaiton();
        Rigidbody playerRigidbody = playerController.GetPlayerRigidBody();

        playerRigidbody.linearVelocity = new Vector3(playerRigidbody.linearVelocity.x,0f,playerRigidbody.linearVelocity.z);
        playerRigidbody.AddForce(transform.forward * _jumpForce, ForceMode.Impulse);
        _isActivated = true;
        Invoke(nameof(ResetActivation), 0.2f);
    }

    private void PlayBoostAnimaiton()
    {
        _spatulaAnimator.SetTrigger("IsSpatulaJumping");

    }

    private void ResetActivation()
    {
        _isActivated = false;
    }
}
