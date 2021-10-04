using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanelsTB : MonoBehaviour
{
    public GameObject Panel;
    
    public void ClosePanel(){
        Panel.SetActive(false);
        if(UIManagerTB.recolectados == 10){
            ChangeScene.Change("TBWin");
        }
    }
}
