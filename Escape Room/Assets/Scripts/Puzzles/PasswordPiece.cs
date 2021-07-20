using System.Collections.Generic;
using UnityEngine;

public class PasswordPiece : PuzzlePiece
{
    [SerializeField] private int _correctIndex;
    [SerializeField] private int _initialIndex;
    [SerializeField] private Event _movedPasswordPieceEvent;
    private List<GameObject> _buttonsList = new List<GameObject>();

    public override int InitialIndex { get => _initialIndex; protected set { } }
    public override int CorrectIndex { get => _correctIndex; protected set { } }
    public override Event MovedPieceEvent => _movedPasswordPieceEvent;
    public override List<GameObject> PiecesList => _buttonsList;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _buttonsList.Add(transform.GetChild(i).gameObject);
        }

        SetIndex(_initialIndex);
    }
}
