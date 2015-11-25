using UnityEngine;
using System.Collections;

public class Tunnel : MonoBehaviour {

	private float tunnelTime = 0.0f;
	private string tunnelName;
	private SimpleChar script;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			script = other.GetComponent<SimpleChar>();
			if (script.travelled == false)
			{
				other.gameObject.SetActive(false);
				script.travelled = true;
				StartCoroutine(TunnelTravel(other.gameObject));
			}
		}
	}

	IEnumerator TunnelTravel(GameObject traveller)
	{

		yield return new WaitForSeconds(3);

		tunnelName = GameObject.Find ("Tunnel Entrance" + Random.Range (1, 5).ToString ()).name;
		while (tunnelName == this.gameObject.name) 
		{
			tunnelName = GameObject.Find ("Tunnel Entrance" + Random.Range (1, 5).ToString ()).name;
		}
		if (tunnelName != this.gameObject.name) 
		{
			traveller.gameObject.SetActive (true);
			traveller.transform.position = GameObject.Find (tunnelName).transform.position;
		}

		yield return new WaitForSeconds (5);

		script.travelled = false;
		yield return null;
	}
}
