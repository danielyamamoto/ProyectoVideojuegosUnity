using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchingWord : MonoBehaviour
{
    public Text displayedText;
    public Image crossLine;
    private string word;
    void Start()
    {

    }

    private void OnEnable()
    {
        GameEvents.OnCorrectWord += CorrectWord;
    }

    private void OnDisable()
    {
        GameEvents.OnCorrectWord -= CorrectWord;
    }

    public void SetWord(string w)
    {
        word = w;
        displayedText.text = w;
    }

    private void CorrectWord(string w, List<int> squareIndexes)
    {
        if (w == word)
        {
            crossLine.gameObject.SetActive(true);
        }
    }

}
