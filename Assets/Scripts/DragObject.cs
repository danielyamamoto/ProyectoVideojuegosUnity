using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// fuente: https://www.patreon.com/posts/unity-3d-drag-22917454

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        Debug.Log(transform.gameObject.tag);
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
}
