using UnityEngine;
using System.Collections;

public class Esmerelda : Character {

	// Use this for initialization
	void Start () {
		name_ = "Esmerelda";
		bio_ = "who cares atm";
		
		// Player Variables - to be set in each characters inherited file 
		orig_damage_ = 5;     	 // stat
		orig_weight_ = 5;     	 // stat
		orig_speed_ = 1.2f;   				// stat
		
		attack_range_ = 0.5f; // stat - MUST BE ADDED LATER
		
		special_radius_ = 1; // for the sphere of attack
		special_charge_time_ = 1.0f; // in seconds

		base.ResetAllChar();
	}
}
