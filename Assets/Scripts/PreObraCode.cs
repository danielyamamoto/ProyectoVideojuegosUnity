using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreObraCode : MonoBehaviour
{
    public void GoTo()
    {
       ChangeScene.Change("TernyObra"); 
    }

    public void ReturnTo()
    {
        ChangeScene.Change("Mapa");
    } 

}
