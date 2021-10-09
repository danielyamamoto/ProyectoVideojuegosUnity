using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class LoadManager : MonoBehaviour
{
    string loadGameURL = "http://localhost:3001/api/getJugador/";
    int playerID = 1;
    public static Player player;
    public static bool recargaDisp = true;

    // Start is called before the first frame update
    void Start()
    {
        int p = Application.absoluteURL.IndexOf("?");
        if (p!=-1)
        {
            //Debug.Log(testURL.Split("?"[0])[1]);
            string p1 = Application.absoluteURL.Split("?"[0])[1];

            int e = p1.IndexOf("=");
            if (e != -1)
            {
                playerID = Int32.Parse(p1.Split("="[0])[1]);
                Debug.Log($"{p1.Split("="[0])[0]}: {playerID}");
                
            }
        }
        player = new Player();
        StartCoroutine(LoadPlayer());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LoadPlayer(){

        UnityWebRequest web = UnityWebRequest.Get(loadGameURL + playerID);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success)
        {
            player.color = "red";
            player.puntaje = 0;
            player.nickname = "nombre";
        }
        else
        {
            Debug.Log(web.downloadHandler.text);
            List<Player> playerList = JsonConvert.DeserializeObject<List<Player>>(web.downloadHandler.text);
            if (playerList.Count > 0){
                player = playerList[0];
            }
        }
    }
}
