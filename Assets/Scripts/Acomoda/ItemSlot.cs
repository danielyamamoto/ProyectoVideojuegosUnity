using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ItemSlot : MonoBehaviour, IDropHandler {
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            Debug.Log($"Drop {int.Parse(eventData.pointerDrag.GetComponent<RectTransform>().gameObject.tag)}");

            int index = int.Parse(eventData.pointerDrag.GetComponent<RectTransform>().gameObject.tag);
            int pos = int.Parse(GetComponent<RectTransform>().gameObject.tag);
            Debug.Log($" Secuencia: {Spawner.Procesos[index].secuencia}");

            if (Spawner.Procesos[index].secuencia == pos) {
                Debug.Log("Correcto");
                Spawner.correctos[index] = true;
                Ganar();
            } else {
                Spawner.correctos[index] = true;
                Debug.Log("Falso");
            }
        }
    }

    public GameObject Panel;

    public void GoTo() {
        Panel.SetActive(true);
    }

    public void ReturnTo() {
        Panel.SetActive(false);
    }


    public void Ganar() {
        foreach (bool sec in Spawner.correctos) {
            if (!sec) {
                return;
            }
        }

        LoadManager.player.puntaje += 100;
        StartCoroutine(Win());
        SceneManager.LoadScene("AcomodaGanar");
        Debug.Log("Ganamos!");
    }

    IEnumerator Win() {
        string jsonData = JsonConvert.SerializeObject(LoadManager.player);
        Debug.Log("Puntos-> " + jsonData);
        UnityWebRequest web = UnityWebRequest.Put("http://localhost:3001/api/updatePlayer/" + LoadManager.player.id, jsonData);
        web.method = UnityWebRequest.kHttpVerbPUT;
        web.SetRequestHeader("Content-type", "application/json");
        web.SetRequestHeader("Accept", "application/json");
        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success) {
            Debug.Log(web.error);
        } else {
            Debug.Log($"Update {LoadManager.player.id} puntaje: {LoadManager.player.puntaje} complete!");
        }
    }
}
