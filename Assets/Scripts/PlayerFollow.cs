using UnityEngine;

public class PlayerFollow : MonoBehaviour {
    public Transform PlayerTransform;
    public bool lookAtPlayer = false;
    
    private Vector3 cameraOffset;

    [Range(0.1f, 1.0f)] public float smoothFactor = 0.5f;
    
    void Start() {   
        cameraOffset = transform.position - PlayerTransform.position;
    }

    void LateUpdate() {
        Vector3 newPos = PlayerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        if (lookAtPlayer) { transform.LookAt(PlayerTransform); }
    }
}
