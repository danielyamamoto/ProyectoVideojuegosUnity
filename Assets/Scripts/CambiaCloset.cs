using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class CambiaCloset : MonoBehaviour {
    public GameObject Panel;
    
    public void GoTo() {
       Panel.SetActive(true); 
    }

    public void ReturnTo() {
        StartCoroutine(Guardar());
        Panel.SetActive(false);
    } 

    IEnumerator Guardar() {
        string jsonData = JsonConvert.SerializeObject(LoadManager.player);
        Debug.Log("Color-> " + jsonData);
        UnityWebRequest web = UnityWebRequest.Put("http://localhost:3001/api/updatePlayer/" + LoadManager.player.id, jsonData);
        web.method = UnityWebRequest.kHttpVerbPUT;
        web.SetRequestHeader("Content-type", "application/json");
        web.SetRequestHeader("Accept", "application/json");
        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success) { Debug.Log(web.error); } 
        else { Debug.Log($"Update {LoadManager.player.id} color: {LoadManager.player.color} complete!"); }
    }
}