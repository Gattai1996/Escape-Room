using System.Collections.Generic;
using UnityEngine;

public class PasswordPuzzle : MonoBehaviour
{
    [SerializeField] private Event _unlockedLockEvent;
    private List<PasswordPiece> _piecesList = new List<PasswordPiece>();

    private void Start()
    {
        Transform background = transform.GetChild(0);

        for (int i = 0; i < background.childCount; i++)
        {
            _piecesList.Add(background.GetChild(i).GetComponent<PasswordPiece>());
        }
    }

    private bool CheckPieces()
    {
        foreach (PasswordPiece piece in _piecesList)
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
            _unlockedLockEvent.TriggerEvent();
            HUDManager.Singleton.ShowMessageText("Puzzle completed", 3f);
            PuzzlesManager.Singleton.DestroyPasswordPuzzle();
        }
    }
}
