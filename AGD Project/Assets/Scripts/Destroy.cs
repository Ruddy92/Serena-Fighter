using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float destroyTime = 5.0f;

	// Use this for initialization
	void Start () {

		Destroy (gameObject, destroyTime);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
