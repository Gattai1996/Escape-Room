using UnityEngine;

public class PuzzlesManager : HUDObjectsManager
{
    [SerializeField] private Event _exitedOfPuzzleEvent;
    public static PuzzlesManager Singleton { get; private set; }
    protected override Event OnDesactivateEvent => _exitedOfPuzzleEvent;
    private GameObject _geometricFormsPuzzle, _sequencePuzzle, _passwordPuzzle, _slidePuzzle;

    private void Start()
    {
        Singleton = this;
        SetupList();
        _geometricFormsPuzzle = GameObject.Find("Geometric Forms Puzzle");
        _sequencePuzzle = GameObject.Find("Sequence Puzzle");
        _passwordPuzzle = GameObject.Find("Password Puzzle");
    }

    public void DestroyGeometricFormsPuzzle()
    {
        Destroy(_geometricFormsPuzzle);
        SetObjectToDesactive();
    }

    public void DestroySequencePuzzle()
    {
        Destroy(_sequencePuzzle);
    }

    public void DestroyPasswordPuzzle()
    {
        Destroy(_passwordPuzzle);
        SetObjectToDesactive();
    }

    public void DestroySlidePuzzle()
    {
        Destroy(_slidePuzzle);
    }
}
