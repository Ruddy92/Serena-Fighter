using UnityEngine;
using System.Collections;

public class KotHill : MonoBehaviour {


	private int playersInside = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{
		StartCoroutine (scoring (col));
	}

	IEnumerator scoring(Collider col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Debug.Log(col.gameObject.name + " has entered the hill!");
			Collider[] colliders = Physics.OverlapSphere(this.transform.position, 1.86f);
			Debug.Log("Hello");
			foreach (Collider hit in colliders)
			{

				if (hit.gameObject.tag == "Player")
				{

					playersInside++;
				}
			}
			while(playersInside == 1)
			{
				SimpleChar script = col.gameObject.GetComponent<SimpleChar>();
				yield return new WaitForSeconds(1);
				script.score++;
			}
			playersInside = 0;
			yield return null;
		}

	}
}
