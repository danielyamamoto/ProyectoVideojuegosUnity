using UnityEngine;

public class ChColor : MonoBehaviour {
    public GameObject jugador;
    Material[] mats;
    
    public void ChangeColorRed() {
        LoadManager.player.color = "red";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("red") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("red") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("red") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("red") as Texture;
        }
    }

    public void ChangeColorBlue() {
        LoadManager.player.color = "blue";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("blue") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("blue") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("blue") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("blue") as Texture;
        }
    }
    
    public void ChangeColorOrange() {
        LoadManager.player.color = "orange";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("orange") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("orange") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("orange") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("orange") as Texture;
        }
    }

    public void ChangeColorYellow() {
        LoadManager.player.color = "yellow";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("yellow") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("yellow") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("yellow") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("yellow") as Texture;
        }
    }

    public void ChangeColorGreen() {
        LoadManager.player.color = "green";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("green") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("green") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("green") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("green") as Texture;
        }
    }

    public void ChangeColorPurple() {
        LoadManager.player.color = "purple";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("purple") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("purple") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("purple") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("purple") as Texture;
        }
    }
    
    public void ChangeColorPink() {
        LoadManager.player.color = "pink";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("pink") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("pink") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("pink") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("pink") as Texture;
        }
    }

    public void ChangeColorGray() {
        LoadManager.player.color = "gray";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("gray") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("gray") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("gray") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("gray") as Texture;
        }
    }

    public void ChangeColorTeal() {
        LoadManager.player.color = "teal";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("teal") as Texture;
        mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
        mats[0].mainTexture = Resources.Load("teal") as Texture;
        
        for (int i = 2; i <= 10; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("teal") as Texture;
        }
        
        for (int i = 12; i <= 25; i++) {
            mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
            mats[0].mainTexture = Resources.Load("teal") as Texture;
        }
    }
}
