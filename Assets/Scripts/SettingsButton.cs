using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour {
    public void Change() {
        SceneManager.LoadScene("SettingsMenu");
    }
}
