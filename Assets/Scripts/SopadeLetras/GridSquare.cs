using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSquare : MonoBehaviour
{
    public int SquareIndex { get; set; }
    public AlphabetData.LetterData normalLetterData; //<--
    public AlphabetData.LetterData selectedLetterData;
    public AlphabetData.LetterData correctLetterData;

    private SpriteRenderer displayedImage;

    private bool selected;
    private bool clicked;
    private int index = -1;
    private bool correct;

    public void SetIndex(int i)
    {
        index = i;
    }

    public int GetIndex()
    {
        return index;
    }

    void Start()
    {
        selected = false;
        clicked = false;
        displayedImage = GetComponent<SpriteRenderer>();
        correct = false;
    }

    private void OnEnable()
    {
        GameEvents.OnEnableSquareSelection += OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection += OnDisableSquareSelection;
        GameEvents.OnSelectSquare += SelectSquare;
        GameEvents.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        GameEvents.OnEnableSquareSelection -= OnEnableSquareSelection;
        GameEvents.OnDisableSquareSelection -= OnDisableSquareSelection;
        GameEvents.OnSelectSquare -= SelectSquare;
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    private void CorrectWord(string w, List<int> squareIndexes)
    {
        if (selected && squareIndexes.Contains(index))
        {
            correct = true;
            displayedImage.sprite = correctLetterData.image;
        }

        selected = false;
        clicked = false;
    }

    public void OnEnableSquareSelection()
    {
        clicked = true;
        selected = false;
    }

    public void OnDisableSquareSelection()
    {
        selected = false;
        clicked = false;

        if (correct == true)
        {
            displayedImage.sprite = correctLetterData.image;
        }
        else
        {
            displayedImage.sprite = normalLetterData.image;
        }
    }

    private void SelectSquare(Vector3 position)
    {
        if (this.gameObject.transform.position == position)
        {
            displayedImage.sprite = selectedLetterData.image;
        }
    }


    public void SetSprite(AlphabetData.LetterData normalLetterData2, AlphabetData.LetterData selectedLetterData2, AlphabetData.LetterData correctLetterData2)
    {
        //.Log(normalLetterData2.letter);
        normalLetterData = normalLetterData2;
        selectedLetterData = selectedLetterData2;
        correctLetterData = correctLetterData2;

        GetComponent<SpriteRenderer>().sprite = normalLetterData.image;

    }

    private void OnMouseDown()
    {
        OnEnableSquareSelection();
        GameEvents.EnableSquareSelectionMethod();
        CheckSquare(); //
        //Debug.Log($"{normalLetterData.letter} NormalLetter");
        displayedImage.sprite = selectedLetterData.image;
    }

    private void OnMouseEnter()
    {
        CheckSquare();
    }

    private void OnMouseUp()
    {
        GameEvents.ClearSelectionMethod();
        GameEvents.DisableSquareSelectionMethod();
    }

    public void CheckSquare()
    {
        //Debug.Log($"{normalLetterData.letter} CRAYOLA");
        if (selected == false && clicked == true)
        {
            selected = true;
            //Debug.Log($"{normalLetterData.letter} HOLA");
            GameEvents.CheckSquareMethod(normalLetterData.letter, gameObject.transform.position, index);//<--
        }
    }
}
