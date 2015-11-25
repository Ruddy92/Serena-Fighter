using UnityEngine;
using System.Collections;

public class SimpleChar : MonoBehaviour {

	
	private Vector3 spawnPos;
	private bool alive = true;
	private Vector3 turnVector;
	private float stickDeadzone = 0.02f;
	private float turnAxisThreshold = 0.0f;
	private Vector2 stickInput_r;
	private Vector3 moveDirection = Vector3.zero;
	private int scoreValue = 0;

	public bool travelled = false;
	public float turnSpeed = 1.0f;
	public int playerNo = 0;
	public int dmgpct = 0;
	public int score = 0;

	//Sets the Character's Spawn Position to be available later for respawn.
	void Start () 
	{

		if (this.gameObject.name == "Player1") {
			playerNo = 1;
		}
		else if (this.gameObject.name == "Player2")
		{
			playerNo = 2;
		} 
		else if (this.gameObject.name =="Player3")
		{
			playerNo = 3;
		} 
		else if (this.transform.name == "Player4") 
		{
			playerNo = 4;
		} 
		else
		{
			Debug.Log("No Correct Player Name Found");
		}
		spawnPos = transform.position;
	}
	
	// Calls the various functions neccessary for the character to function. Might be considering multi threading with Coroutines if
	// this ends up being too intensive per frame if done sequentially rather than parallel.
	void Update () {
		if (alive == true) 
		{
			StartCoroutine(CharMovement());
			//CharTurn();
			CharAttack();
			moveDirection = Vector3.zero;
		}
	}

	IEnumerator CharMovement()
	{
		CharacterController controller = GetComponent<CharacterController>();

		if (playerNo == 1) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, -Input.GetAxis ("Vertical"));
		}
		else if (playerNo == 2)
			moveDirection = new Vector3 (-Input.GetAxis ("Joy2Horizontal1"), 0, -Input.GetAxis ("Joy2Vertical1"));
		else if (playerNo == 3)
			moveDirection = new Vector3 (-Input.GetAxis ("Joy3Horizontal1"), 0, -Input.GetAxis ("Joy3Vertical1"));
		else if (playerNo == 4)
			moveDirection = new Vector3 (-Input.GetAxis ("Joy4Horizontal1"), 0, -Input.GetAxis ("Joy4Vertical1"));

		moveDirection = transform.TransformDirection (moveDirection);

		moveDirection *= 5.0f;

		controller.Move (moveDirection * Time.deltaTime);

		//CharTurn();

		yield return null;

	}

	void CharTurn()
	{
		stickInput_r = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (stickInput_r.magnitude < stickDeadzone) 
		{
			stickInput_r = Vector2.zero;
		}
		else 
		{
			stickInput_r = stickInput_r.normalized * ((stickInput_r.magnitude - stickDeadzone) / (1 - stickDeadzone));
		}
		
		if(stickInput_r.magnitude >= turnAxisThreshold)
		{
			turnVector.y = Mathf.Atan2(-stickInput_r.x, -stickInput_r.y) * Mathf.Rad2Deg;
			StartCoroutine(Turn());
		}
	}

	IEnumerator Turn()
	{
		Quaternion oldRotation = transform.rotation;
		Quaternion newRotation = new Quaternion ();
		newRotation.eulerAngles = turnVector / 2;

		if (moveDirection != Vector3.zero) {

			for (float t = 0.0f; t < 1.0f; t+= (turnSpeed * Time.deltaTime)) 
			{
				transform.rotation = Quaternion.Lerp (oldRotation, newRotation, t);
				yield return null;
			}
		}

	}

	void CharAttack()
	{
		
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "attack") 
		{
			dmgpct += 20;
			Destroy (col.gameObject);
		}
	}
}
