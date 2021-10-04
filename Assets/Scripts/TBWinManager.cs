using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class TBWinManager : MonoBehaviour
{
    public void ReturnTo()
    {
        LoadManager.player.puntaje += 250;
        StartCoroutine(Win());
        ChangeScene.Change("Mapa");
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
