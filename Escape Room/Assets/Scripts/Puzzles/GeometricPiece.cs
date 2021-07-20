using System.Collections.Generic;
using UnityEngine;

public class GeometricPiece : PuzzlePiece
{
    [SerializeField] private int _correctIndex;
    [SerializeField] private int _initialIndex;
    [SerializeField] private Event _movedGeometricPieceEvent;
    private List<GameObject> _imagesList = new List<GameObject>();

    public override int InitialIndex { get => _initialIndex; protected set { } }
    public override int CorrectIndex { get => _correctIndex; protected set { } }
    public override Event MovedPieceEvent => _movedGeometricPieceEvent;
    public override List<GameObject> PiecesList => _imagesList;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _imagesList.Add(transform.GetChild(i).gameObject);
        }

        SetIndex(_initialIndex);
    }
}
