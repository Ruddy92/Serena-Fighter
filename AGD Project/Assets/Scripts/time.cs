using UnityEngine;
using System.Collections;

public class time : MonoBehaviour {
		
	public float startTimeLeft = 60;
	int SS;
	int MM;
	int Seconds;
	
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		startTimeLeft -= Time.deltaTime;
		
		Seconds = (int)startTimeLeft;
		
		//work out the time in minutes and seconds
		// modulus divide by 60 to get the ramining seconds
		SS = Seconds%60;
	
		//reduce the total seconds by the remainder 
		Seconds = Seconds - SS;
	
		//divide the startSecs by 60 to get the minutes
		Seconds = Seconds/60;
	
		//modulus divide by 60 to get reamining minutes
		MM = Seconds%60;
		
		//reduce startSecs by the reaminding minutes
		Seconds = Seconds - MM;
	
		//Output
		guiText.text = MM + " : " + SS;
			
		if (Seconds < 0)
		{
			//end the game fool
		}
			
	}
}
