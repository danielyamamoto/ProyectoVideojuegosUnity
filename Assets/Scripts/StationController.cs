using UnityEngine;

public class StationController : MonoBehaviour {
    public GameObject Recarga;

    void Awake() {
        if (LoadManager.recargaDisp) { Recarga.SetActive(true); }
        else { Recarga.SetActive(false); }
    }
}
