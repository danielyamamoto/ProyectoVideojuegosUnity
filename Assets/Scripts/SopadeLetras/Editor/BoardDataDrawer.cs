using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Text.RegularExpressions;
using System;


[CustomEditor(typeof(BoardData), false)]
[CanEditMultipleObjects]
[System.Serializable]
public class BoardDataDrawer : Editor
{
    private BoardData GameDataInstance => target as BoardData;
    private ReorderableList dataList;

    private void OnEnable()
    {
        InitializeReordableList(ref dataList, "SearchWords", "Searching Words");

    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawColumnsRowInputFields();
        EditorGUILayout.Space();

        ConvertToUpperButton();

        if (GameDataInstance.board != null && GameDataInstance.col > 0 && GameDataInstance.rows > 0)
        {
            DrawBoardTable();
        }

        GUILayout.BeginHorizontal();
        ClearBoardButton();
        FillUpWithRandomLettersButton();
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        dataList.DoLayoutList();

        serializedObject.ApplyModifiedProperties();
        if (GUI.changed)
        {
            EditorUtility.SetDirty(GameDataInstance);
        }
    }

    private void DrawColumnsRowInputFields()
    {
        var colTemp = GameDataInstance.col;
        var rowTemp = GameDataInstance.rows;

        GameDataInstance.col = EditorGUILayout.IntField("Columns", GameDataInstance.col);
        GameDataInstance.rows = EditorGUILayout.IntField("Rows", GameDataInstance.rows);

        if ((GameDataInstance.col != colTemp || GameDataInstance.rows != rowTemp) &&
        GameDataInstance.col > 0 && GameDataInstance.rows > 0)
        {
            GameDataInstance.CreateNewBoard();
        }

    }

    private void DrawBoardTable()


    {
        var tableStyle = new GUIStyle("box");
        tableStyle.padding = new RectOffset(10, 10, 10, 10);
        tableStyle.margin.left = 32;
        var headerColumnStyle = new GUIStyle();
        headerColumnStyle.fixedWidth = 35;

        var columnStyle = new GUIStyle();
        columnStyle.fixedWidth = 50;

        var rowStyle = new GUIStyle();
        rowStyle.fixedHeight = 25;
        rowStyle.fixedWidth = 40;
        rowStyle.alignment = TextAnchor.MiddleCenter;

        var textFieldStyle = new GUIStyle();

        textFieldStyle.normal.background = Texture2D.grayTexture;
        textFieldStyle.normal.textColor = Color.white;
        textFieldStyle.fontStyle = FontStyle.Bold;
        textFieldStyle.alignment = TextAnchor.MiddleCenter;

        EditorGUILayout.BeginHorizontal(tableStyle);
        for (var x = 0; x < GameDataInstance.col; x++)
        {
            EditorGUILayout.BeginVertical(x == -1 ? headerColumnStyle : columnStyle);
            for (var y = 0; y < GameDataInstance.rows; y++)
            {
                if (x >= 0 && y >= 0)
                {
                    EditorGUILayout.BeginHorizontal(rowStyle);
                    var character = (string)EditorGUILayout.TextArea(GameDataInstance.board[x].row[y], textFieldStyle);
                    if (GameDataInstance.board[x].row[y].Length > 1)
                    {
                        character = GameDataInstance.board[x].row[y].Substring(0, 1);
                    }
                    GameDataInstance.board[x].row[y] = character;
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();


    }

    private void InitializeReordableList(ref ReorderableList list, string propertyName, string listLabel)
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName), true, true, true, true);
        list.drawHeaderCallback = (Rect rect) =>
        {
            EditorGUI.LabelField(rect, listLabel);
        };

        var l = list;

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
        {
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, EditorGUIUtility.labelWidth,
            EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("Word"), GUIContent.none);

        };
    }

    private void ConvertToUpperButton()
    {
        if (GUILayout.Button("To Upper"))
        {
            for (var i = 0; i < GameDataInstance.col; i++)
            {
                for (var j = 0; j < GameDataInstance.rows; j++)
                {
                    var errorCounter = Regex.Matches(GameDataInstance.board[i].row[j], @"[a-z]").Count;
                    if (errorCounter > 0)
                    {
                        GameDataInstance.board[i].row[j] = GameDataInstance.board[i].row[j].ToUpper();
                    }
                }

                foreach (var searchWord in GameDataInstance.SearchWords)
                {
                    var errorCounter = Regex.Matches(searchWord.Word, @"[a-z]").Count;
                    if (errorCounter > 0)
                    {
                        searchWord.Word = searchWord.Word.ToUpper();
                    }

                }
            }
        }
    }
    private void ClearBoardButton()
    {
        if (GUILayout.Button("Clear Board"))
        {
            for (int i = 0; i < GameDataInstance.col; i++)
            {
                for (int j = 0; j < GameDataInstance.rows; j++)
                {
                    GameDataInstance.board[i].row[j] = " ";
                }
            }
        }
    }

    private void FillUpWithRandomLettersButton()
    {
        if (GUILayout.Button("Fill up with random"))
        {
            for (int i = 0; i < GameDataInstance.col; i++)
            {
                for (int j = 0; j < GameDataInstance.rows; j++)
                {
                    int errorCounter = Regex.Matches(GameDataInstance.board[i].row[j], @"[a-zA-Z]").Count;
                    string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int index = UnityEngine.Random.Range(0, letters.Length);

                    if (errorCounter == 0)
                    {
                        GameDataInstance.board[i].row[j] = letters[index].ToString();
                    }
                }
            }
        }
    }
}
