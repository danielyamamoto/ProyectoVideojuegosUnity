using UnityEngine;

public class ChColor : MonoBehaviour {
    public GameObject jugador;
    
    [SerializeField] private string color = "red";

    private Material[] mats;
    
    public void ChangeColor(string color) {
        LoadManager.player.color = color;
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load(color) as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load(color) as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load(color) as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load(color) as Texture;
        }
    }
}
