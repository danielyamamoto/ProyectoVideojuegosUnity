using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public GameObject jugador;
    Material[] mats;
    public Text txtName;
    public Text txtPoints;

    // Start is called before the first frame update
    void Start()
    {
        txtName.text = LoadManager.player.nickname;
        txtPoints.text = LoadManager.player.puntaje + " puntos";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
                mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
                for (int i = 2; i <= 10; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
                }
                for (int i = 12; i <= 25; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
                }
    }

    // Update is called once per frame
    void Update()
    {
        txtName.text = LoadManager.player.nickname;
        txtPoints.text = LoadManager.player.puntaje + " puntos";
    }
}