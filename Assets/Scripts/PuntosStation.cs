using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class PuntosStation : MonoBehaviour {
    public GameObject Recarga;
    public GameObject Panel;
    
    public void ButtonRecarga() {
        Panel.SetActive(true);
        Recarga.SetActive(false);
        LoadManager.player.puntaje += 50;
        LoadManager.player.diasConsec += 1;
        LoadManager.recargaDisp = false;
    }

    public void ClosePanel(){
        StartCoroutine(Guardar());
        Panel.SetActive(false);
    }

    IEnumerator Guardar() {
        string jsonData = JsonConvert.SerializeObject(LoadManager.player);
        Debug.Log("Puntos-> " + jsonData);
        UnityWebRequest web = UnityWebRequest.Put("http://localhost:3001/api/updatePlayer/" + LoadManager.player.id, jsonData);
        web.method = UnityWebRequest.kHttpVerbPUT;
        web.SetRequestHeader("Content-type", "application/json");
        web.SetRequestHeader("Accept", "application/json");
        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success) { Debug.Log(web.error); }
        else { Debug.Log($"Update {LoadManager.player.id} puntaje: {LoadManager.player.puntaje} complete!"); }
    }
}
