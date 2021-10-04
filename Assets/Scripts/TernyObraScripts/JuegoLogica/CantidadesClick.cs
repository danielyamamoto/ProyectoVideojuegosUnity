using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantidadesClick : MonoBehaviour
{
    Material m_Material;
    public int clicks;

    void Start()
    {
        //Fetch the Renderer component of the GameObject
        m_Material = GetComponent<Renderer>().material;
        clicks = Random.Range(1, clicks);

        UpdateText(clicks.ToString());
    }

    void LateUpdate()
    {
        if (clicks == 0)
        {
            m_Material.SetColor("_Color", Color.green);

            UpdateText("");
        }
    }

    void OnMouseDown()
    {
        clicks--;
        UpdateText(clicks.ToString());
        
    }

    public int GetClicks()
    {
        return clicks;
    }

    private void UpdateText(string s)
    {
        var txt = gameObject.transform.Find("NumText").gameObject;
        
        txt.GetComponent<TextMesh>().text = s;  
    }
}
