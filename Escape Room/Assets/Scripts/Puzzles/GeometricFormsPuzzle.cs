using System.Collections.Generic;
using UnityEngine;

public class GeometricFormsPuzzle : MonoBehaviour
{
    private List<GeometricPiece> _piecesList = new List<GeometricPiece>();

    private void Awake()
    {
        Transform background = transform.GetChild(0);

        for (int i = 0; i < background.childCount; i++)
        {
            _piecesList.Add(background.GetChild(i).GetComponent<GeometricPiece>());
        }
    }

    private bool CheckPieces()
    {
        foreach (GeometricPiece piece in _piecesList)
        {
            if (!piece.IsOnCorrectIndex)
            {
                return false;
            }
        }

        return true;
    }

    public void CheckPuzzle()
    {
        if (CheckPieces())
        {
            HUDManager.Singleton.ShowMessageText("Puzzle completed", 3f);
            PuzzlesManager.Singleton.DestroyGeometricFormsPuzzle();
        }
    }
}
