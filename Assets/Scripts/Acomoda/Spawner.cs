using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public struct cordo
    {
        public int x;
        public int y;
    }
    public cordo[] cordenadas;
    public Text[] textos;
    public static List<Acomoda> Procesos;
    private int idProceso = 1;
    private string url;
    public static bool[] correctos;

    void Start()
    {
        correctos = new bool[8];
        url = "http://localhost:3001/api/cargaAcomoda/";
        StartCoroutine(loadAcomoda());

    }

    IEnumerator loadAcomoda()
    {
        UnityWebRequest web = UnityWebRequest.Get(url + idProceso);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if (web.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(web.downloadHandler.text);
            Procesos = JsonConvert.DeserializeObject<List<Acomoda>>(web.downloadHandler.text);
            if (Procesos.Count > 0)
            {
                for (int i = 0; i < Procesos.Count; i++)
                {
                    textos[i].text = Procesos[i].subproceso;
                }
            }
        }
    }

    /*
    public int numberToSpawn;
    public List<GameObject> spawnPool;
    public GameObject quad;
    // Start is called before the first frame update


    public void spawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numberToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];
            screenX = Random.Range(300, 800);
            screenY = Random.Range(-460, 740);
            pos = new Vector2(screenX, screenY);

            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
        }
    }
    private void destroyObject()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Spawnable"))
        {
            Destroy(o);
        }
    }*/
}
