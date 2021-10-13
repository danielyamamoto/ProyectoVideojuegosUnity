using UnityEngine;

public class PreBuscaCode : MonoBehaviour {
    public void GoTo() {
       ChangeScene.Change("TernyBuscaSc"); 
    }

    public void ReturnTo() {
        ChangeScene.Change("Mapa");
    } 
}
