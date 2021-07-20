using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual int IndexOfObjectHUD { get; }
    public abstract InteractionType Type { get; }
    public abstract string Information { get; }
    public abstract void Interact();
}
