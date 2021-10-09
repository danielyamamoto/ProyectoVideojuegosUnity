using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "inputX", "inputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {
    [Header("Animation Smoothing")]
    [Range(0, 1f)] public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)] public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)] public float StartAnimTime = 0.3f;
    [Range(0, 1f)] public float StopAnimTime = 0.15f;

	public bool canMove = true;

	[SerializeField] private float Velocity;
	[SerializeField] private float desiredRotationSpeed = 0.01f;
	[SerializeField] private float allowPlayerRotation = 0.1f;

	private Animator anim;
	private Camera cam;
	private CharacterController controller;

	private float inputX, inputZ, speed, verticalVel;
	private bool isGrounded;

	private void Awake () {
		anim = GetComponent<Animator>();
		cam = Camera.main;
		controller = GetComponent<CharacterController>();
	}
	
	private void Update () {
		PlayerGround();
		if (canMove) { InputMagnitude (); }
    }

    void PlayerMoveAndRotation(float inputX, float inputZ) {
		//PlayerMove(cam.transform.forward.normalized * inputZ);
		//LookAt(cam.transform.right.normalized * inputX);
		PlayerMove(cam.transform.forward.normalized * inputZ + cam.transform.right.normalized * inputX);
		LookAt(cam.transform.forward.normalized * inputZ + cam.transform.right.normalized * inputX);
	}
		
	private void PlayerMove(Vector3 move) {
		controller.Move(move * Time.deltaTime * Velocity);
	}

    public void LookAt(Vector3 pos) {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

	// Stay play in the ground/plane
	private void PlayerGround() {
		isGrounded = controller.isGrounded;

		if (isGrounded) { verticalVel -= 0; }
		else { verticalVel -= 1; }

		controller.Move(new Vector3(0, verticalVel * 0.2f * Time.deltaTime, 0));
	}

	//public void RotateToCamera(Transform t) {
        //desiredMoveDirection = cam.transform.forward;
        //t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    //}

	void InputMagnitude() {
		//Calculate Input Vectors
		inputX = Input.GetAxis("Horizontal");
		inputZ = Input.GetAxis("Vertical");
		
		//Calculate the Input Magnitude
		speed = new Vector2(inputX, inputZ).sqrMagnitude;

        //Physically move player
		if (speed > allowPlayerRotation) {
			anim.SetFloat ("Blend", speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation (inputX, inputZ);
		} else if (speed < allowPlayerRotation) {
			anim.SetFloat ("Blend", speed, StopAnimTime, Time.deltaTime);
		}
	}
}