// Richard Lucas - N3088581
using UnityEngine;
using System.Collections;

public class Froglegs : Character {
	void Start()
	{
		name_ = "Froglegs";
		bio_ = "who cares atm";
		
		// Player Variables - to be set in each characters inherited file 
		orig_damage_ = 15;     	 // stat
		orig_weight_ = 15;     	 // stat
		orig_speed_ = 1.2f;   				// stat

		attack_range_ = 0.5f; // stat - MUST BE ADDED LATER

		special_radius_ = 1; // for the sphere of attack
		special_charge_time_ = 1.0f; // in seconds

		base.ResetAllChar();
	}
}