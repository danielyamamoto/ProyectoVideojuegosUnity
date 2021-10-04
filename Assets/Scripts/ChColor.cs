using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChColor : MonoBehaviour
{
    public GameObject jugador;
    Material[] mats;
    
    public void ChangeColorRed(){
        LoadManager.player.color = "red";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("red") as Texture;
                mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("red") as Texture;
                for (int i = 2; i <= 10; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("red") as Texture;
                }
                for (int i = 12; i <= 25; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("red") as Texture;
                }
    }
    public void ChangeColorBlue(){
        LoadManager.player.color = "blue";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("blue") as Texture;
                mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("blue") as Texture;
                for (int i = 2; i <= 10; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("blue") as Texture;
                }
                for (int i = 12; i <= 25; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("blue") as Texture;
                }
    }
    public void ChangeColorPurple(){
        LoadManager.player.color = "purple";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("purple") as Texture;
                mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("purple") as Texture;
                for (int i = 2; i <= 10; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("purple") as Texture;
                }
                for (int i = 12; i <= 25; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("purple") as Texture;
                }
    }
        public void ChangeColorGreen(){
            LoadManager.player.color = "green";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("green") as Texture;
                mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("green") as Texture;
                for (int i = 2; i <= 10; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("green") as Texture;
                }
                for (int i = 12; i <= 25; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("green") as Texture;
                }
    }
        public void ChangeColorOrange(){
            LoadManager.player.color = "orange";
        mats = jugador.transform.GetChild(0).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("orange") as Texture;
                mats = jugador.transform.GetChild(2).GetComponent<Renderer>().materials;
                mats[0].mainTexture = Resources.Load("orange") as Texture;
                for (int i = 2; i <= 10; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("orange") as Texture;
                }
                for (int i = 12; i <= 25; i++)
                {
                    mats = jugador.transform.GetChild(i).GetComponent<Renderer>().materials;
                    mats[0].mainTexture = Resources.Load("orange") as Texture;
                }
    }
    
}
