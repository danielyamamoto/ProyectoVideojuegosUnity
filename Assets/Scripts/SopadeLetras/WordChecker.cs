using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class WordChecker : MonoBehaviour
{
    public GameData currentGameData;
    private string word;

    private int assignedPoints = 0;
    private int compleatedWords = 0;
    private Ray rayUp, rayDown;

    private Ray rayLeft, rayRight;
    private Ray rayDiagonalLeftUp, rayDiagonalLeftDown;
    private Ray rayDiagonalRightUp, rayDiagonalRightDown;
    private Ray currentRay = new Ray();

    private Vector3 rayStartPosition;
    private List<int> correctSquareList = new List<int>();


    private void OnEnable()
    {
        GameEvents.OnCheckSquare += SquareSelected;
        GameEvents.OnClearSelection += ClearSelection;
    }

    private void OnDisable()
    {
        GameEvents.OnCheckSquare -= SquareSelected;
        GameEvents.OnClearSelection -= ClearSelection;
    }

    // Start is called before the first frame update
    void Start()
    {
        assignedPoints = 0;
        compleatedWords = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (assignedPoints > 0 && Application.isEditor)
        {
            Debug.DrawRay(rayUp.origin, rayUp.direction * 4);
            Debug.DrawRay(rayDown.origin, rayDown.direction * 4);
            Debug.DrawRay(rayLeft.origin, rayLeft.direction * 4);
            Debug.DrawRay(rayRight.origin, rayRight.direction * 4);
            Debug.DrawRay(rayDiagonalLeftUp.origin, rayDiagonalLeftUp.direction * 4);
            Debug.DrawRay(rayDiagonalLeftDown.origin, rayDiagonalLeftDown.direction * 4);
            Debug.DrawRay(rayDiagonalRightUp.origin, rayDiagonalRightUp.direction * 4);
            Debug.DrawRay(rayDiagonalRightDown.origin, rayDiagonalRightDown.direction * 4);
        }
    }

    private void SquareSelected(string letter, Vector3 squarePosition, int squareIndex)
    {
        if (assignedPoints == 0)
        {
            rayStartPosition = squarePosition;
            correctSquareList.Add(squareIndex);
            word += letter;
            rayUp = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(0f, 1));
            rayDown = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(0f, -1));
            rayLeft = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(-1, 0f));
            rayRight = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(1, 0f));
            rayDiagonalLeftUp = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(-1, 1));
            rayDiagonalLeftDown = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(-1, -1));
            rayDiagonalRightUp = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(1, 1));
            rayDiagonalRightDown = new Ray(new Vector2(squarePosition.x, squarePosition.y), new Vector2(1, -1));
        }
        else if (assignedPoints == 1)
        {
            correctSquareList.Add(squareIndex);
            currentRay = SelectRay(rayStartPosition, squarePosition);
            GameEvents.SelectSquareMethod(squarePosition);
            word += letter;
            CheckWord();
        }
        else
        {
            if (IsPointOnTheRay(currentRay, squarePosition))
            {
                correctSquareList.Add(squareIndex);
                GameEvents.SelectSquareMethod(squarePosition);
                word += letter;
                CheckWord();
            }
        }

        assignedPoints++;


    }

    private void CheckWord()
    {
        foreach (var searchingWord in currentGameData.selectedBoardData.SearchWords)
        {
            if (word == searchingWord.Word)
            {
                GameEvents.CorrectWordMethod(word, correctSquareList);
                word = string.Empty;
                correctSquareList.Clear();
                compleatedWords++;
                CheckBoardCompleted();
                return;
            }
        }
    }

    private bool IsPointOnTheRay(Ray currentRay, Vector3 point)
    {
        var hits = Physics.RaycastAll(currentRay, 100.0f);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.position == point)
            {
                return true;
            }
        }
        return false;

    }

    private Ray SelectRay(Vector2 firstPosition, Vector2 secondPosition)
    {
        var direction = (secondPosition - firstPosition).normalized;
        float tolerance = 0.01f;
        if (Math.Abs(direction.x) < tolerance && Math.Abs(direction.y - 1f) < tolerance)//
        {
            return rayUp;
        }
        if (Math.Abs(direction.x) < tolerance && Math.Abs(direction.y - (-1f)) < tolerance)//
        {
            return rayDown;
        }
        if (Math.Abs(direction.x - (-1f)) < tolerance && Math.Abs(direction.y) < tolerance)//
        {
            return rayLeft;
        }
        if (Math.Abs(direction.x - 1f) < tolerance && Math.Abs(direction.y) < tolerance)//
        {
            return rayRight;
        }
        if (direction.x < 0f && direction.y > 0f)
        {
            return rayDiagonalLeftUp;
        }
        if (direction.x < 0f && direction.y < 0f)
        {
            return rayDiagonalLeftDown;
        }
        if (direction.x > 0f && direction.y > 0f)
        {
            return rayDiagonalRightUp;
        }
        if (direction.x > 0f && direction.y < 0f)
        {
            return rayDiagonalRightDown;
        }

        return rayDown;
    }

    private void ClearSelection()
    {
        assignedPoints = 0;
        correctSquareList.Clear();
        word = string.Empty;
    }

    private void CheckBoardCompleted()
    {
        if (currentGameData.selectedBoardData.SearchWords.Count == compleatedWords)
        {
            LoadManager.player.puntaje += 100;
            StartCoroutine(Win());
            SceneManager.LoadScene("SopaDeLetrasFin");
        }
    }

    IEnumerator Win()
    {
        string jsonData = JsonConvert.SerializeObject(LoadManager.player);
        Debug.Log("Puntos-> " + jsonData);
        UnityWebRequest web = UnityWebRequest.Put("http://localhost:3001/api/updatePlayer/" + LoadManager.player.id, jsonData);
        web.method = UnityWebRequest.kHttpVerbPUT;
        web.SetRequestHeader("Content-type", "application/json");
        web.SetRequestHeader("Accept", "application/json");
        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(web.error);
        }
        else
        {
            Debug.Log($"Update {LoadManager.player.id} puntaje: {LoadManager.player.puntaje} complete!");
        }
    }

}
