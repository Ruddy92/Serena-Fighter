using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelProperties : MonoBehaviour {


	public int levelNum;

	public List<Vector3> KOTHPositions = new List<Vector3>();
	// Use this for initialization
	void Start () {
		if (levelNum == 1) {
			KOTHPositions.Add(new Vector3(0f,0f,0f));
			KOTHPositions.Add(new Vector3 (-12.9f,46f,150f));
			KOTHPositions.Add(new Vector3 (-12.9f,46f,-153f));
			KOTHPositions.Add(new Vector3 (157f,46f,-33.8f));
			KOTHPositions.Add(new Vector3 (-148f,46f,-13f));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
