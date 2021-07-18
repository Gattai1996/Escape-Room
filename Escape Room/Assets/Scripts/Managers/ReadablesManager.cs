using UnityEngine;

public class ReadablesManager : HUDObjectsManager
{
    [SerializeField] private Event exitedOfReadableEvent;
    public static ReadablesManager Singleton { get; private set; }

    protected override Event OnDesactivateEvent => exitedOfReadableEvent;

    private void Start()
    {
        Singleton = this;
        SetupList();
    }
}
