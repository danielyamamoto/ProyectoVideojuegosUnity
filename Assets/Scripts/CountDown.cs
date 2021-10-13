using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    public Text timeText;
    public static bool isStoped = false;

    [SerializeField] [Range(0, 10)] public int timeMinutes = 5;
    [SerializeField] [Range(0, 60)] public float timeSeconds = 0f;
        
    private float timeRemaining = 10.0f;

	private void Awake() {
        timeRemaining = (timeMinutes * 60 - 1) + timeSeconds;
	}

	void Update() {
        if (!isStoped) {
            if (timeRemaining > 0) {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
			} else {
                ChangeScene.Change("TBLose");
			}
		}
    }

    void DisplayTime(float time) {
        time += 1;
        float minutes = Mathf.FloorToInt(time / 60);   
        float seconds = Mathf.FloorToInt(time % 60);
        float milliSeconds = (time % 1) * 1000;
        timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}