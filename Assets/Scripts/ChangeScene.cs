using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    public static void Change(string sc) {
        SceneManager.LoadScene(sc);
    }

    public void ButtonChange() {
        SceneManager.LoadScene("Mapa");
    }
}