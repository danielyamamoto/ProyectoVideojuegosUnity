using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OtroLado : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OtroLado");

        if (eventData.pointerDrag != null)
        {
            Debug.Log($"Lado {int.Parse(eventData.pointerDrag.GetComponent<RectTransform>().gameObject.tag)}");
            int index = int.Parse(eventData.pointerDrag.GetComponent<RectTransform>().gameObject.tag);
            Spawner.correctos[index] = false;

        }
    }

}


