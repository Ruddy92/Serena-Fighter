using UnityEngine;
using System.Collections;

//Works independantly of the initial player script.
public class shootyPistol : MonoBehaviour
{
	
	public Rigidbody bullet;
	public float power = 50;

	void Start()
	{

	}


	void Update()
	{
		//Instantiates a new bullet clone based on the player.
		if( Input.GetButtonDown("Fire1"))
		{
				Rigidbody newInstance = Instantiate(bullet, transform.position + transform.forward * 1.5f, transform.rotation) as Rigidbody;
				Vector3 fwd = transform.TransformDirection(Vector3.forward);
				newInstance.AddForce(fwd*power);
		}

	}
}