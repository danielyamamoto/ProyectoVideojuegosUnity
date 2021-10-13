using UnityEngine;

public class ClosePanelsTB : MonoBehaviour {
    public GameObject Panel;

    public void ClosePanel() {
        Panel.SetActive(false);
        MovementInput.canMove = true;
        CountDown.isStoped = false;
        if (UIManagerTB.recolectados == 10) { ChangeScene.Change("TBWin"); }
    }
}
