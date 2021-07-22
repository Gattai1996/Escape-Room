using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField] private InteractablePuzzle _interactablePhysicPuzzle;
    [SerializeField] private AudioClip _puzzleMovedPieceSound;
    private AudioSource _audioSource;
    protected List<PuzzlePiece> _piecesList = new List<PuzzlePiece>();

    private void Start()
    {
        InitPuzzlePiecesList();

        try
        {
            _audioSource = GetComponent<AudioSource>();
        }
        catch (Exception)
        {
            throw new Exception($"GameObject {gameObject.name} needs a AudioSource Component");
        }
    }

    protected virtual void InitPuzzlePiecesList()
    {
        Transform background = transform.GetChild(0);
        for (int i = 0; i < background.childCount; i++)
        {
            _piecesList.Add(background.GetChild(i).GetComponent<PuzzlePiece>());
        }
    }

    protected virtual bool CheckAllPieces()
    {
        foreach (PuzzlePiece piece in _piecesList)
        {
            if (!piece.IsOnCorrectCondition)
            {
                return false;
            }
        }

        return true;
    }

    public virtual void CheckPuzzle()
    {
        if (CheckAllPieces())
        {
            PuzzleCompleted();
        }
    }

    protected void PuzzleCompleted()
    {
        HUDManager.Singleton.ShowMessageText("Puzzle completed", 3f);
        StartCoroutine(PuzzleCompletedCoroutine());
    }

    private IEnumerator PuzzleCompletedCoroutine()
    {
        yield return new WaitForSeconds(1f);
        PuzzlesManager.Singleton.DestroyInteractablePuzzle(_interactablePhysicPuzzle);
    }

    public void PlayMovedPieceSound()
    {
        _audioSource.PlayOneShot(_puzzleMovedPieceSound);
    }
}
