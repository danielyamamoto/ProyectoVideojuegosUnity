using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibClicks : MonoBehaviour
{
    public GameObject metal;
    void Start()
    {
        metal.tag = "MetalFinal";
    }

    void OnMouseDown()
    {
        Vector3 pos = gameObject.transform.position;
        Destroy(gameObject);
        Instantiate(metal, pos, metal.transform.rotation);
    }
}
