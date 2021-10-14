using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {
    public AudioMixer mixer;
    public GameObject off;

    public void SetVolume(float volume) {
        if (volume == 0) { mixer.SetFloat("volume", -80); } 
        else { mixer.SetFloat("volume", Mathf.Log10(volume) * 20); }
    }

    public void Pause(bool off) {
        if (true) { SetVolume(0); } 
    }

    public void On(bool on) {
        if (true) { SetVolume(1); }
    }
}