using UnityEngine;

public class PuzzlesManager : HUDObjectsManager
{
    [SerializeField] private Event _exitedOfPuzzleEvent;
    public static PuzzlesManager Singleton { get; private set; }
    protected override Event OnDesactivateEvent => _exitedOfPuzzleEvent;
    private void Start()
    {
        Singleton = this;
        SetupList();
    }

    public void DestroyInteractablePuzzle(InteractablePuzzle interactablePuzzle)  
    {
        Destroy(interactablePuzzle.gameObject, 0.1f); // Destroy with delay of 0.1f, because can cause a Exception on
                                                      // the Event Listeners of Scripable Object Event System
        SetObjectToDesactive();
    }
}
