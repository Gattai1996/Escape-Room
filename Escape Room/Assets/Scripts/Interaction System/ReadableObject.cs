using UnityEngine;

public class ReadableObject : Interactable
{
    [SerializeField] private int _readIndex;
    [SerializeField] private Event enteredOnPuzzleEvent;
    public override int IndexOfObjectHUD => _readIndex;
    public override InteractionType Type => InteractionType.Read;
    public override string Information => PickupControls.Singleton.IsHoldingItem
            ? $"Can not use {PickupControls.Singleton.ObjectHolding.name} here, press Q to drop it" 
            : $"Press E to read {gameObject.name}";

public override void Interact()
    {
        ReadablesManager.Singleton.SetObjectToActive(IndexOfObjectHUD);
        enteredOnPuzzleEvent.TriggerEvent();
    }
}
