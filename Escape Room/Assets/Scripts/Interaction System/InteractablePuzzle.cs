using UnityEngine;

public class InteractablePuzzle : Interactable
{
    [SerializeField] private int _puzzleIndex;
    public override int IndexOfObjectHUD => _puzzleIndex;
    public override InteractionType Type => InteractionType.Puzzle;
    public override string Information => "Press E to enter Puzzle";

    public override void Interact()
    {
        PuzzlesManager.Singleton.SetObjectToActive(IndexOfObjectHUD);
    }
}
