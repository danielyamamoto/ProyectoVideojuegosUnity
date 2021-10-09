using UnityEngine;

public class ClosePanelsTB : MonoBehaviour {
    public GameObject Panel;

    private GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    public void ClosePanel() {
        Panel.SetActive(false);
        player.GetComponent<MovementInput>().canMove = true;
        if (UIManagerTB.recolectados == 10) { ChangeScene.Change("TBWin"); }
    }
}
