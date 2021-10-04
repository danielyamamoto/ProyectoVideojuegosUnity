using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreAcomoda : MonoBehaviour
{
    public void GoTo()
    {
        ChangeScene.Change("Acomoda");
    }

    public void ReturnTo()
    {
        ChangeScene.Change("CasaDeCampoSc");
    }
}
