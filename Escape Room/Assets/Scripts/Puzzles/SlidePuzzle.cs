using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : Puzzle
{
    private List<SlidePiece> imagesList;

    private void Start()
    {
        imagesList = new List<SlidePiece>();

        foreach (GameObject image in GameObject.FindGameObjectsWithTag("Slide Piece"))
        {
            imagesList.Add(image.GetComponent<SlidePiece>());
        }
    }

    public void CheckVictory()
    {
        for (int i = 0; i < imagesList.Count; i++)
        {
            if (Vector3.Distance(imagesList[i].transform.position, imagesList[i].CorrectPosition) > 10f)
            {
                return;
            }
        }

        PuzzleCompleted();
    }
}