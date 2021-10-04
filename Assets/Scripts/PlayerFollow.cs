using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Transform PlayerTransform;

    private Vector3 cameraOffset;
    public bool lookAtPlayer = false;

    [Range(0.1f, 1.0f)]
    public float smoothFactor = 0.5f;
    // Start is called before the first frame update
    void Start()
    {   
        cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = PlayerTransform.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        if (lookAtPlayer) {
            transform.LookAt(PlayerTransform);
        }
    }
}
