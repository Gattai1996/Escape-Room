using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : Interactable
{

    public override InteractionType Type => InteractionType.Pickup;

    public override string Information => $"Press E to pickup {gameObject.name}";

    public override void Interact()
    {
        PickupControls.Singleton.PickupItem(transform);
    }
}
