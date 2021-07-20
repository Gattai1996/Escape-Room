using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{
    public abstract int InitialIndex { get; protected set; }
    public int CurrentIndex { get; private set; }
    public abstract int CorrectIndex { get; protected set; }
    public bool IsOnCorrectIndex { get; private set; }
    public abstract Event MovedPieceEvent { get; }
    public abstract List<GameObject> PiecesList { get; }

    public void OnPointerClick(PointerEventData eventData)
    {
        CurrentIndex = (CurrentIndex + 1) % PiecesList.Count;
        SetIndex(CurrentIndex);
        MovedPieceEvent.TriggerEvent();
    }

    protected void SetIndex(int index)
    {
        foreach (GameObject piece in PiecesList)
        {
            piece.SetActive(false);
        }

        PiecesList[index].SetActive(true);
        IsOnCorrectIndex = index == CorrectIndex;
    }
}
