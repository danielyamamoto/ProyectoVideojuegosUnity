using UnityEngine;
using UnityEngine.UI;

public class UIManagerTB : MonoBehaviour {
    public Text txtRecolectados;
    public static int recolectados;
    
    void Awake() {
        recolectados = 0;
        txtRecolectados.text = recolectados + "/ 10";
    }

    void Update() {
        txtRecolectados.text = recolectados + " / 10";
    }
}
