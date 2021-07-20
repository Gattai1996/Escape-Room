using UnityEngine;

public class CombinableObject : Interactable
{
    [SerializeField] private PickableObject _usefullObject;
    [SerializeField] private string _extraInformation;
    [SerializeField] private Event _unlockedLockEvent;
    public override InteractionType Type => InteractionType.Combinable;
    public override string Information => PickupControls.Singleton.ObjectHolding ? "Press E to use item" : "Press E to examine";
    public string ExtraInformation => _extraInformation;

    public override void Interact()
    {
        if (PickupControls.Singleton.ObjectHolding == _usefullObject)
        {
            HUDManager.Singleton.ShowMessageText($"Used {PickupControls.Singleton.ObjectHolding.name}", 3f);

            if (_unlockedLockEvent != null)
            {
                _unlockedLockEvent.TriggerEvent();
            }

            Destroy(gameObject);
        }
        else
        {
            HUDManager.Singleton.ShowMessageText($"Can not use {PickupControls.Singleton.ObjectHolding.name} here", 3f);
        }
    }
}
