using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SequencePuzzle : Puzzle
{
    [SerializeField] private int[] _correctSequence;
    [SerializeField] private GameObject _spawnObject;
    private int[] _trySequence;
    private int _actualTryIndex;
    private List<Image> _imagesList = new List<Image>();
    private Color _buttonNormalColor = new Color(255, 255, 255, 255);
    private Color _buttonCorrectColor = new Color(0, 200, 0, 255);
    private Color _buttonWrongColor = new Color(200, 0, 0, 255);

    private void Awake()
    {
        _spawnObject.SetActive(false);
    }

    protected override void InitPuzzlePiecesList()
    {
        Transform background = transform.GetChild(0);

        for (int i = 0; i < background.childCount; i++)
        {
            _imagesList.Add(background.GetChild(i).GetComponent<Image>());
        }

        _trySequence = new int[background.childCount];
    }

    public void TryNumber(int number)
    {
        if (number == _correctSequence[_actualTryIndex])
        {
            _trySequence[_actualTryIndex] = number;
            SetButtonToCorrectColor(number, true);
            CheckPuzzle();
            _actualTryIndex++;
        }
        else
        {
            _trySequence = new int[10];
            _actualTryIndex = 0;
            StartCoroutine(RestartPuzzle(number));
        }
    }

    protected override bool CheckAllPieces()
    {
        for (int i = 0; i < _correctSequence.Length; i++)
        {
            if (_trySequence[i] != _correctSequence[i])
            {
                return false;
            }
        }

        _spawnObject.SetActive(true);
        return true;
    }

    private void SetButtonToCorrectColor(int number, bool isNumberCorrect)
    {
        Image button = _imagesList[number - 1];

        if (isNumberCorrect)
        {
            button.color = _buttonCorrectColor;
        }
        else
        {
            button.color = _buttonWrongColor;
        }
    }

    private IEnumerator RestartPuzzle(int number)
    {
        SetButtonToCorrectColor(number, false);
        yield return new WaitForSeconds(0.5f);
        SetAllButtonsToNormalColor();
    }

    private void SetAllButtonsToNormalColor()
    {
        foreach (Image button in _imagesList)
        {
            button.color = _buttonNormalColor;
        }
    }
}
