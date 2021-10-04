using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSelector : MonoBehaviour
{
    public GameData currentGameData;
    public GameLevelData levelData;

    // Start is called before the first frame update
    void Awake()
    {
        SelectSequentialBoardData();
    }

    private void SelectSequentialBoardData()
    {
        foreach (var data in levelData.data)
        {
            if (data.categoryName == currentGameData.selectedCategoryName)
            {
                //Debug.Log($"DentroIf: {currentGameData.selectedCategoryName}");
                var boardIndex = 0; //TODO
                Debug.Log(data.boardData.Count);
                currentGameData.selectedBoardData = data.boardData[0];
                /*if (boardIndex < data.boardData.Count)
                {
                    //Debug.Log("if");
                    Debug.Log($" BoardData {data.boardData[boardIndex].rows}");
                    currentGameData.selectedBoardData = data.boardData[0];
                }
                else
                {
                    var randomIndex = Random.Range(0, data.boardData.Count);
                    currentGameData.selectedBoardData = data.boardData[randomIndex];
                    Debug.Log(currentGameData.selectedBoardData);
                }*/
            }
        }
    }
}
