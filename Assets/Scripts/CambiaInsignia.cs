using UnityEngine;

public class CambiaInsignia : MonoBehaviour {
    public GameObject Panel;
    
    public void GoTo() {
       Panel.SetActive(true); 
    }

    public void ReturnTo() {
        Panel.SetActive(false);
    }
}
