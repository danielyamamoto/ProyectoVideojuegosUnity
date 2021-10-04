using UnityEngine;

public class LManager : MonoBehaviour {
    public GameObject jugador;
    Material[] mats;

    void Start() {
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
                mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
                
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
        }
                
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load(LoadManager.player.color) as Texture;
        }
    }
}