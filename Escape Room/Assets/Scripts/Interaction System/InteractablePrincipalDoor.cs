using UnityEngine;

public class InteractablePrincipalDoor : Interactable
{
    [SerializeField] private Event _desactivatePlayerControlsEvent;
    [SerializeField] private Event _winEvent;
    [SerializeField] private AudioClip _openedLockSound;
    [SerializeField] private AudioClip _doorLockedSound;
    [SerializeField] private AudioClip _doorOpeningSound;
    private Animator _doorAnimator;
    private AudioSource _doorAudioSource;
    private int _locksRemaining = 3;
    public int LocksRemaining => _locksRemaining;

    public override InteractionType Type => InteractionType.Door;

    public override string Information => PickupControls.Singleton.IsHoldingItem
                        ? $"Can not use {PickupControls.Singleton.ObjectHolding.name} here, press Q to drop it"
                        : $"Press E to interact with {gameObject.name}";

    private void Start()
    {
        _doorAnimator = GetComponent<Animator>();
        _doorAudioSource = GetComponent<AudioSource>();
    }

    public override void Interact()
    {
        if (_locksRemaining > 0)
        {
            _doorAnimator.SetTrigger("Locked");
            HUDManager.Singleton.ShowMessageText($"The door is firmily locked by {_locksRemaining} locks", 4f);
            _doorAudioSource.PlayOneShot(_doorLockedSound);
        }
        else
        {
            _doorAnimator.SetTrigger("Opened");
        }
    }

    public void UnlockedLock()
    {
        _locksRemaining--;
        _doorAudioSource.PlayOneShot(_openedLockSound);
    }

    public void TriggerDesactivatePlayerControls()
    {
        _desactivatePlayerControlsEvent.TriggerEvent();
        _doorAudioSource.PlayOneShot(_doorOpeningSound);
    }

    public void TriggerWin()
    {
        _winEvent.TriggerEvent();
    }
}
