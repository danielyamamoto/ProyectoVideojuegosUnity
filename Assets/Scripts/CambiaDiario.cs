using UnityEngine;

public class CambiaDiario : MonoBehaviour {
    public GameObject Panel;
    
    public void GoTo() {
       Panel.SetActive(true); 
    }

    public void ReturnTo() {
        Panel.SetActive(false);
    } 
}
