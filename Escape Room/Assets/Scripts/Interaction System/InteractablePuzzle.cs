using UnityEngine;

public class InteractablePuzzle : Interactable
{
    [SerializeField] private int _puzzleIndex;
    [SerializeField] private Event enteredOnPuzzleEvent;
    public override int IndexOfObjectHUD => _puzzleIndex;
    public override InteractionType Type => InteractionType.Puzzle;
    public override string Information => PickupControls.Singleton.IsHoldingItem 
        ? $"Can not use {PickupControls.Singleton.ObjectHolding.name} here, press Q to drop it"
        : $"Press E to enter on {gameObject.name}";

    public override void Interact()
    {
        PuzzlesManager.Singleton.SetObjectToActive(IndexOfObjectHUD);
        enteredOnPuzzleEvent.TriggerEvent();
    }
}
