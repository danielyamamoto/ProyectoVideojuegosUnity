using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class LoadManager : MonoBehaviour {
    string loadGameURL = "http://localhost:3001/api/getJugador/";
    int playerID = 1;
    public static Player player;
    public static bool recargaDisp = true;

    public string url = "http://localhost:8080/juego?playerID=2";

    void Start() {
        //int p = Application.absoluteURL.IndexOf("?");
        int p = url.IndexOf("?");
        if (p!=-1) {
            //string p1 = Application.absoluteURL.Split("?"[0])[1];
            string p1 = url.Split("?"[0])[1];
            Debug.Log("p1: " + p1);

            int e = p1.IndexOf("=");
            Debug.Log("e: " + e);
            if (e != -1) {
                playerID = Int32.Parse(p1.Split("="[0])[1]);
                Debug.Log($"{p1.Split("="[0])[0]}: {playerID}");
            }
        }
        player = new Player();
        StartCoroutine(LoadPlayer());
    }

    IEnumerator LoadPlayer() { 
        UnityWebRequest web = UnityWebRequest.Get(loadGameURL + playerID);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success) {
            player.color = "red";
            player.puntaje = 0;
            player.nickname = "Terny default";
        } else {
            Debug.Log(web.downloadHandler.text);
            List<Player> playerList = JsonConvert.DeserializeObject<List<Player>>(web.downloadHandler.text);
            if (playerList.Count > 0){
                player = playerList[0];
            }
        }
    }
}
