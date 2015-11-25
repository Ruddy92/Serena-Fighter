using UnityEngine.UI;
using UnityEngine;
using System.Collections;


//time base
//none - no score added - white
//contested - no score added - black
// alone - score added - player colour
//visual representation 
//change partical effect to each colour depending on state above 
//player 1 red
//player 2 blue
//player 3 green
//player 4 yellow

//every 20 seconds move hill
//current position and new possible position
//rounds 3 minutes


public class KingOfTheHill : MonoBehaviour {

	public float targetScore = 60.0f;
	public float currentscore;
	public int winscore = 60;
	public float posX = 0;
	public float posY = 0;
	public int maxX = 50;
	public int minX = 20;
	public int minZ = 20;
	public int maxZ = 50;
	public int playercounter = 0;
	public Text scoreText;
	public Text winText;

	public float timeLeft = 180f;

	private bool playerinbounds;

	RaycastHit Hitwhat;




	// Use this for initialization
	void Start () 
	{
		currentscore = 0;
		InvokeRepeating ("MoveArea",1.0f,5.0f); // call movearea function every 20 seconds
		InvokeRepeating( "DecreaseTime", 1, 1 ); // Called every second
		SetScoreText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () 
	{
		DecreaseTime();

	}


	void MoveArea()
	{
		int levelnum = Random.Range (1, 6);

		LevelProperties levelp = GetComponent<LevelProperties>();
		this.transform.position = levelp.KOTHPositions [levelnum];
		//int randomX = Random.Range (minX, maxX);
		//int randomZ = Random.Range (minZ, maxZ);


		//transform.position = new Vector3 (randomX,  // randomizes the position of the gameobjects x,z position within a certain range. 
		                                  //(100), // set the gameobject to the height of the terrain
		                                  // randomZ);


	/*	Vector3 dwd = transform.TransformDirection(Vector3.down);
		Debug.Log ("Hello");
		if (Physics.Raycast (transform.position, dwd, out Hitwhat, 1000)) {

			Debug.DrawLine(transform.position, Hitwhat.point, Color.red);

			transform.position = new Vector3 (randomX,  
			                                  (100 - Hitwhat.distance), 
			                                  randomZ); 
		} */





	}


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")

			{
				playercounter ++;  // if player enters king of the hill add one to the ring counter
			}
	
		}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			playercounter --;
		}
	}


	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag == "Player")
			{
				if(playercounter == 1)

				{
					//player1.GetComponent<Player>().addScore(); // call score function from player script
				  	currentscore = currentscore += Time.deltaTime; // add 1 to score every second player is inside the ring alone
					SetScoreText();
				}

			}

	}

	void SetScoreText ()
	{
		scoreText.text = "Score: " + currentscore.ToString ();

		if (currentscore >= winscore)

		{
			winText.text = "You Win!";
		}
	}

	void DecreaseTime() 
	{

		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			Application.Quit();
		}
	}
		

	void OnGUI ()
	{
		GUI.Box (new Rect (Screen.width/2 -10,10,200,100), "Time Remaining:" + timeLeft.ToString("n0"));
		GUI.Box (new Rect (10 - 30,30,200,30), "Player1Score:" + currentscore.ToString("n0")); 
		//GUI.Box (new Rect (Screen.width/2 - Screen.height -100,10,100,100), timeLeft);
	}
	 


}
