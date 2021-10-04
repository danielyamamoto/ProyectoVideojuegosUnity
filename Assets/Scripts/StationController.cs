using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationController : MonoBehaviour
{
    public GameObject Recarga;
    // Start is called before the first frame update
    void Start()
    {
        if (LoadManager.recargaDisp){
            Recarga.SetActive(true);
        }
        else{
            Recarga.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
