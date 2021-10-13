using UnityEngine;

public class PreTernyPideBotones : MonoBehaviour {
    public void GoTo() {
        ChangeScene.Change("TernyPide");
    }

    public void ReturnTo() {
        ChangeScene.Change("CasaDeCampoSc");
    }
}