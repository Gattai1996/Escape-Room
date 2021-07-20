using UnityEngine;

public class InteractablePrincipalDoor : Interactable
{
    [SerializeField] private Event _desactivatePlayerControlsEvent;
    [SerializeField] private Event _winEvent;
    private Animator _doorAnimator;
    private int _locksRemaining = 3;
    public int LocksRemaining => _locksRemaining;

    public override InteractionType Type => InteractionType.Door;

    public override string Information => PickupControls.Singleton.IsHoldingItem
                        ? $"Can not use {PickupControls.Singleton.ObjectHolding.name} here, press Q to drop it"
                        : $"Press E to interact with {gameObject.name}";

    private void Start()
    {
        _doorAnimator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (_locksRemaining > 0)
        {
            _doorAnimator.SetTrigger("Locked");
            HUDManager.Singleton.ShowMessageText($"The door is firmily locked by {_locksRemaining} locks", 4f);
        }
        else
        {
            _doorAnimator.SetTrigger("Opened");
        }
    }

    public void UnlockedLock()
    {
        _locksRemaining--;
    }

    public void TriggerDesactivatePlayerControls()
    {
        _desactivatePlayerControlsEvent.TriggerEvent();
    }

    public void TriggerWin()
    {
        _winEvent.TriggerEvent();
    }
}
