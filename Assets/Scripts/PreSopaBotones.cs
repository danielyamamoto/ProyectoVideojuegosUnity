using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreSopaBotones : MonoBehaviour
{
    public void GoTo()
    {
        ChangeScene.Change("SopaDeLetras");
    }

    public void ReturnTo()
    {
        ChangeScene.Change("CasaDeCampoSc");
    }
}
