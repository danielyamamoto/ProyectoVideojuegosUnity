using UnityEngine;

public class MoveObjectController : MonoBehaviour  {
	public float reachRange = 1.8f;			

	private Animator anim;
	private Camera fpsCam;
	private GameObject player;

	private const string animBoolName = "isOpen_Obj_";

	private bool playerEntered;
	private bool showInteractMsg;
	private GUIStyle guiStyle;
	private string msg;

	private int rayLayerMask; 


	private void Awake() {
		//Initialize moveDrawController if script is enabled.
		player = GameObject.FindGameObjectWithTag("Player");

		//a reference to Camera is required for rayasts
		fpsCam = Camera.main;
		if (fpsCam == null)	{ Debug.LogError("A camera tagged 'MainCamera' is missing."); }

		//create AnimatorOverrideController to re-use animationController for sliding draws.
		anim = GetComponent<Animator>(); 
		anim.enabled = false;  //disable animation states by default.  

		//the layer used to mask raycast for interactable objects only
		LayerMask iRayLM = LayerMask.NameToLayer("InteractRaycast");
		rayLayerMask = 1 << iRayLM.value;  

		//setup GUI style settings for user prompts
		setupGui();
	}
		
	void OnTriggerEnter(Collider other) {		
		//player has collided with trigger
		if (other.gameObject == player) { playerEntered = true;	}
	}

	void OnTriggerExit(Collider other) {		
		//player has exited trigger
		if (other.gameObject == player) {			
			playerEntered = false;
			//hide interact message as player may not have been looking at object when they left
			showInteractMsg = false;		
		}
	}



	private void Update() {		
		if (playerEntered) {
			//center point of viewport in World space.
			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0f));
			RaycastHit hit;

			//if raycast hits a collider on the rayLayerMask
			if (Physics.Raycast(rayOrigin,fpsCam.transform.forward, out hit,reachRange,rayLayerMask)) {
				//is the object of the collider player is looking at the same as me?
				MoveableObject moveableObject = null;
				
				//it's not so return;
				if (!isEqualToParent(hit.collider, out moveableObject)) {	
					return;
				}
					
				//hit object must have MoveableDraw script attached
				if (moveableObject != null) {
					showInteractMsg = true;
					string animBoolNameNum = animBoolName + moveableObject.objectNumber.ToString();

					bool isOpen = anim.GetBool(animBoolNameNum);	//need current state for message.
					msg = getGuiMsg(isOpen);

					if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Fire1")) {
						anim.enabled = true;
						anim.SetBool(animBoolNameNum,!isOpen);
						msg = getGuiMsg(!isOpen);
					}

				}
			} else {
				showInteractMsg = false;
			}
		}
	}

	//is current gameObject equal to the gameObject of other.  check its parents
	private bool isEqualToParent(Collider other, out MoveableObject draw) {
		draw = null;
		bool rtnVal = false;
		
		try {
			int maxWalk = 6;
			draw = other.GetComponent<MoveableObject>();

			GameObject currentGO = other.gameObject;
			for(int i=0;i<maxWalk;i++) {
				if (currentGO.Equals(this.gameObject)) {
					rtnVal = true;	
					if (draw== null) draw = currentGO.GetComponentInParent<MoveableObject>();
					break;			//exit loop early.
				}

				//not equal to if reached this far in loop. move to parent if exists.
				//is there a parent
				if (currentGO.transform.parent != null) {
					currentGO = currentGO.transform.parent.gameObject;
				}
			}
		} catch (System.Exception e) {
			Debug.Log(e.Message);
		}
			
		return rtnVal;
	}
		
	#region GUI Config

	//configure the style of the GUI
	private void setupGui()
	{
		guiStyle = new GUIStyle();
		guiStyle.fontSize = 16;
		guiStyle.fontStyle = FontStyle.Bold;
		guiStyle.normal.textColor = Color.white;
		msg = "Press E/Fire1 to Open";
	}

	private string getGuiMsg(bool isOpen)
	{
		string rtnVal;
		if (isOpen)
		{
			rtnVal = "Press E/Fire1 to Close";
		}else
		{
			rtnVal = "Press E/Fire1 to Open";
		}

		return rtnVal;
	}

	void OnGUI()
	{
		if (showInteractMsg)  //show on-screen prompts to user for guide.
		{
			GUI.Label(new Rect (50,Screen.height - 50,200,50), msg,guiStyle);
		}
	}		
	//End of GUI Config --------------
	#endregion
}
