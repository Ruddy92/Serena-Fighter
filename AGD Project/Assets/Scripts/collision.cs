using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour {

	//Public Int to set damage for seperate projectiles.
	public int damage;


	void Start () 
	{
		//
		if (this.name == "Pistol Bullet(Clone)") 
		{
			damage = 1;
		}
		else if (this.name == "Rifle Bullet(Clone)")
		{
			damage = 3;
		} 
		else if (this.name == "Rocket(Clone)")
		{
			damage = 10;
		}
		else 
		{
			Debug.Log("No correct projectile name found: Collision.cs");
		}
	
	}	
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnCollisionEnter(Collision col)
	{
		 
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Walls")
		{
			Collider[] colliders = Physics.OverlapSphere(this.transform.position, 1.0f);
			foreach(Collider hit in colliders)
			{
				if (hit.gameObject.tag == "Player")
				{
					SimpleChar script = hit.gameObject.GetComponent<SimpleChar>();
					script.dmgpct += damage;
					Destroy(this.gameObject);
				}
			}
		}

	}
}
