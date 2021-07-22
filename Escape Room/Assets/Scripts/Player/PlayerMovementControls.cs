using System.Collections;
using UnityEngine;

public class PlayerMovementControls : MonoBehaviour
{
    private CharacterController _characterController;
    private float _speed = 5f;
    private bool _hasHUDObjectActive;
    private bool _isWalking;
    private bool _isPlayingSound;
    private Animator _animator;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!_hasHUDObjectActive)
        {
            HandleMovementControls();
        }
    }

    private void HandleMovementControls()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * xMovement + transform.forward * zMovement;
        movement *= _speed * Time.deltaTime;

        _characterController.Move(movement);

        if (_characterController.velocity != Vector3.zero && !_isWalking && !_isPlayingSound && !_hasHUDObjectActive)
        {
            _isWalking = true;
            InvokeRepeating(nameof (PlayWalkSoundCoroutine), 0.5f, 0.5f);
        }
        else if (_characterController.velocity == Vector3.zero || _hasHUDObjectActive)
        {
            _isWalking = false;
            CancelInvoke(nameof(PlayWalkSoundCoroutine));
        }
    }

    private void PlayWalkSoundCoroutine()
    {
        int ramdomSoundIndex = Random.Range(0, 9);
        AudioManager.Singleton.Play($"Walk{ramdomSoundIndex}");
        StartCoroutine(DelaySound());
    }

    private IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(0.49f);
    }

    public void DesativateMovements()
    {
        _hasHUDObjectActive = true;
        CancelInvoke(nameof(PlayWalkSoundCoroutine));
    }

    public void ActivateMovements()
    {
        _hasHUDObjectActive = false;
    }

    public void DesactivateAnimator()
    {
        _animator.enabled = false;
    }
}
