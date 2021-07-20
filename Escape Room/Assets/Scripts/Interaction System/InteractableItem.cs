using System;
using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField] private string _message;
    [SerializeField] private float _timeToShowTheMessage;
    public override InteractionType Type { get => InteractionType.Interact; }
    public override string Information { get => PickupControls.Singleton.IsHoldingItem 
        ? $"Can not use {PickupControls.Singleton.ObjectHolding.name} here, press Q to drop it" 
        : $"Press E to interact with {gameObject.name}"; }

    public override void Interact()
    {
        HUDManager.Singleton.ShowMessageText(_message, _timeToShowTheMessage);
    }
}
