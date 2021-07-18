using UnityEngine;

public class PuzzlesManager : HUDObjectsManager
{
    [SerializeField] private Event exitedOfPuzzleEvent;
    public static PuzzlesManager Singleton { get; private set; }
    protected override Event OnDesactivateEvent => exitedOfPuzzleEvent;

    private void Start()
    {
        Singleton = this;
        SetupList();
    }
}
