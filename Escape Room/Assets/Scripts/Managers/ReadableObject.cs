using UnityEngine;

public class ReadableObject : Interactable
{
    [SerializeField] private int _readIndex;
    public override int IndexOfObjectHUD => _readIndex;
    public override InteractionType Type => InteractionType.Read;
    public override string Information => "Press E to Read";


    public override void Interact()
    {
        PapersManager.Singleton.SetObjectToActive(IndexOfObjectHUD);
    }
}
