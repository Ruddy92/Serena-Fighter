using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour {

	public GameObject [] boost;
	public int amount;
	private Vector3 spawnPoint; 

	void Update()
	{
		boost = GameObject.FindGameObjectsWithTag ("Boost");
		amount = boost.Length;

		if (amount != 20) 
		{
			InvokeRepeating ("spawnBoost", 5, 10f);
		}

	}

	void spawnBoost()
	{
		spawnPoint.x = Random.Range (-20,20);
		spawnPoint.y = 0.5f;
		spawnPoint.z = Random.Range (-20,20);

		Instantiate (boost [UnityEngine.Random.Range(0, boost.Length)], spawnPoint, Quaternion.identity);
		CancelInvoke ();
	}


}
