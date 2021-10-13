using UnityEngine;

public class ChangeScene2 : MonoBehaviour {
    [SerializeField] private string toScene;
    
    private SceneController sceneController;
    
    void Awake() {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            sceneController.LoadScene(toScene);
        }
    }

    public void LoadScene() {
        sceneController.LoadScene(toScene);
    }
}
