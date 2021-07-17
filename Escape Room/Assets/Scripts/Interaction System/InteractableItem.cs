using System;
using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField] private string _message;
    [SerializeField] private float _timeToShowTheMessage;
    public override int IndexOfObjectHUD => throw new Exception($"An {nameof(InteractableItem)} does not contains {nameof(IndexOfObjectHUD)}!");
    public override InteractionType Type { get => InteractionType.Interact; }
    public override string Information { get => "Press E to Interact"; }

    public override void Interact()
    {
        Debug.Log("Interact");
        HUDManager.Singleton.ShowMessageText(_message, _timeToShowTheMessage);
    }
}
