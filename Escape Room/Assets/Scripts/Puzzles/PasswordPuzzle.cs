using UnityEngine;

public class PasswordPuzzle : Puzzle
{
    [SerializeField] private Event _unlockedLockEvent;

    public override void CheckPuzzle()
    {
        if (CheckAllPieces())
        {
            _unlockedLockEvent.TriggerEvent();
            PuzzleCompleted();
        }
    }
}
