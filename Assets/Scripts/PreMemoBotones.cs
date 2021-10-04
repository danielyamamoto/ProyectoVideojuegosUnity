using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreMemoBotones : MonoBehaviour
{
    public void GoTo()
    {
        ChangeScene.Change("Memorama");
    }

    public void ReturnTo()
    {
        ChangeScene.Change("CasaDeCampoSc");
    }
}
