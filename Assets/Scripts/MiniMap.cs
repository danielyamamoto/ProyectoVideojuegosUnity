using UnityEngine;

public class MiniMap : MonoBehaviour {
    private Transform player;

	private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate() {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
    }
}