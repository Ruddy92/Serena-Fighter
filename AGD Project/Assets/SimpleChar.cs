using UnityEngine;
using System.Collections;

public class SimpleChar : MonoBehaviour {

	public int dmgpct = 0;
	private Vector3 spawnPos;
	private bool alive = true;

	// Use this for initialization
	void Start () 
	{
		spawnPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (alive = true) 
		{
			CharMovement();
			CharAttack();
		}
	}

	void CharMovement()
	{
		var dt = Time.deltaTime;
		var position = transform.position;
		var velocity = rigidbody.velocity;

		velocity.z += 3.5f * Input.GetAxis("Vertical");
		velocity.x += 3.5f * Input.GetAxis ("Horizontal");

		if (velocity.x > 4) {
			velocity.x = 4;
		}
		if (velocity.x < -4) {
			velocity.x = -4;
		}
		if (velocity.z > 4) {
			velocity.z = 4;
		}
		if (velocity.z < -4) {
			velocity.z = -4;
		}

		position.x += velocity.x * dt;
		position.y = 0.5f;
		position.z += velocity.z * dt;

		transform.position = position;
		rigidbody.velocity = velocity;
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
