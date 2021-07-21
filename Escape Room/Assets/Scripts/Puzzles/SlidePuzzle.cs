using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidePuzzle : MonoBehaviour
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
            if (imagesList[i].transform.position != imagesList[i].CorrectPosition)
            {
                return;
            }
        }

        // Win
        Debug.Log("Puzzle completed");
    }
}