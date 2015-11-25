using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {

	public Vector3 offset, rotationVelocity;
	public float recycleOffset, spawnChance;

	public void SpawnIfAvailable(Vector3 position)
	{

	}

	void Update()
	{
		transform.Rotate(rotationVelocity * Time.deltaTime); // rotate boost 
	}

	void OnTriggerEnter () 
	{
		//if ()
		//Player.AddBoost();  // add boost to player with addboost function in player class
		gameObject.SetActive(false);
	}
}