// Richard Lucas - N3088581
using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    public string name_;
    public string bio_;

    // Player Variables - to be set in each characters inherited file 
    public int orig_damage_;     	 // stat
    public int orig_weight_;     	 // stat
    public float orig_speed_;   	 // stat
    // current values
    public int health_; // divide by 100 to get the power multiplier for knockback
	public int damage_; // the players dammage to be added to opponents health - used to apply knockback on hits
	public int weight_; // the players resistance to being hit (anti-knockback)
    int stamina_max_ = 100; // how many actions can the player perform
	public int stamina_; // the current stamina
	public float speed_; // the multiplier for the players movement

    // shield
    bool sheild_ = true; // can the player sheild
    bool sheild_up_ = false; // is the sheild active
    public float sheild_duration_ = 0.5f; // sheild duration in seconds
    public float sheild_cd_ = 0.5f; // the cooldown before the player can sheild again

    // attack variables
    public float attack_range_; // stat - MUST BE ADDED LATER
    float attack1_speed_ = 0.2f; // fast attack - normal damage
    float attack2_speed_ = 0.7f; // slow attack - uses multiplier on damage_
    float attack2_dmg_multiplier_ = 1.2f;

    // special attack variables - charge attack - vulnerable while charging - sphere that expands is AOE
    public int special_radius_ = 1; // for the sphere of attack
    public float special_charge_time_ = 1.0f; // in seconds
    float special_dmg_multiplier = 3.5f;
    // visual effect intensity - starts at 0 and goes to 1 over the charge duration
    float special_intensity_ = 0;


    // power up booleans
    int power_duration_ = 15; // the duration of the power up in seconds
    bool powered_up_ = false; // in case we need it for visuals
    bool damage_upped_ = false; // double damage - and therefore knockback
    bool weight_upped_ = false; // reduces damage and knockback taken
    bool stamina_upped_ = false; // allows for continuous attacks
    bool speed_upped_ = false;
    bool sheild_upped_ = false; // can take two hits before sheild dissapates and extends duration


    // Use this for initialization
	void Start ()
	{
		print ("start function");
		ResetAllChar();
	}

    // Update is called once per frame - likely not needed to be replaced with an 'on game tick' variant
    void Update()
    {
        // stamina regen
        if (stamina_ != stamina_max_)
        {
            stamina_++; // based on teh frame speed should be time based
        }

        // powered up?
        // if already powered up cannot be powered up again
        if (powered_up_)
        {
            // check for each powerup - could use an array of bools which will make this faster
            // check for Double damage
            if (damage_upped_)
            {
                //SetDamage(2 * orig_Damage_);
                // timer for the duration of power_duration_
                // if timer reached reset
                // and turn powered_up_to false
            }
        }

        // attacking and physics
		if (Input.GetButtonDown ("Fire1"))
		{
			Attack1();
		}
    }

    #region Gets, Sets and Resets
    // Gets
	public string GetName() { return name_; }
    public int GetHealth() { return health_; }
    public int GetDamage() { return damage_; }
    public int GetWeight() { return weight_; }
    public int GetStamina() { return stamina_; }
    public float GetSpeed() { return speed_; }
    public bool GetSheildStatus() { return sheild_up_; }

    // Sets
	public virtual void SetHealth(int Health) { health_ = Health; }
	public virtual void SetDamage(int Damage) { damage_ = Damage; }
	public virtual void SetWeight(int Weight) { weight_ = Weight; }
	public virtual void SetStamina(int Stamina) { stamina_ = Stamina; }
	public virtual void SetSpeed(float Speed) { speed_ = Speed; }
	public virtual void SetSheildStatus(bool SheildUp) { sheild_up_ = SheildUp; }

    // Resets
    //void ResetScore() { score_ = 0; }
	public virtual void ResetHealth() { health_ = 0; }
	public virtual void ResetDamage() { damage_ = orig_damage_; }
	public virtual void ResetWeight() { weight_ = orig_weight_; }
	public virtual void ResetStamina() { stamina_ = stamina_max_; }
	public virtual void ResetSpeed() { speed_ = orig_speed_; }
	public virtual void ResetSpecialIntensity() { special_intensity_ = 0; }
	public virtual void ResetSpecialRadius() { special_radius_ = 1; }
    public virtual void ResetAllChar()
    {
		print ("ressetting character variables");
		//ResetScore();
        ResetHealth();
        ResetDamage();
        ResetWeight();
        ResetStamina();
        ResetSpeed();
    }
	public virtual void ResetSpecial()
    {
        ResetSpecialIntensity();
        ResetSpecialRadius();
    }
    #endregion

    // add score
    // void addScore() { score_++; }

    // sheild functions
	void Sheilding() // the character has the sheild up
    {
        // set sheild up to true
        // any attack that would normally damage the player is negated
    }

    // damage functions
	void GiveDamage(Character Enemy) // takes and enemy as a parameter
    {
		Enemy.SetHealth(Enemy.GetHealth() + damage_);
    }

    #region Attack Functions
    // Attack functions
    // must be overriden with "override"
    //public abstract void Special() { }

    // can be overriden if i want still with "override"
    public virtual void Attack1() // fast attack 
    {
        // reduce the stamina buy an amount
        stamina_ -= 10; // magic number should maybe make a variable

        //might need to wait for a duration to time the physics with the animation
        
        // find the direction of the character
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        // raycast with a range
        RaycastHit hitWhat;
        GameObject enemyHit;

        // if it hits an object
        if (Physics.Raycast(transform.position, fwd, out hitWhat, 10.0f /* attack_range_*/))
        {
            enemyHit = hitWhat.transform.gameObject;
			Character script = hitWhat.transform.gameObject.GetComponent<Character>();
			print(script.GetName()); // need to test what the output is of this function
			Debug.DrawLine(transform.position, hitWhat.point, Color.red);
            // apply damage to the objects health
            GiveDamage(script);

            // apply physics in the direction of the raycast
            float Power = LinearAttPhys(script, attack1_speed_);
			print("Attackpower is" + Power);
            enemyHit.rigidbody.AddForce(fwd*Power);
        }
    }
    public virtual void Attack2() // slow attack
    {

    }
    #endregion

    #region Physics
    // 'Physics' equations
    float LinearAttPhys(Character Enemy, float AttSpeed) // will take the hit enemy and attackspeed
    {
		int EnemyHealth = Enemy.GetHealth();
		int EnemyWeight = Enemy.GetWeight();
		float knockback = (damage_ * (EnemyHealth + 1));     // might be some magic numbers in here
		float resistance = EnemyWeight /10;                          // might be some magic numbers in here
		float power = knockback - resistance;
		return power;
	}
    void Grav()
    {
        // apply a force in a downwards direction
        //deffo a magic number to be decided during testing
    }
    #endregion
}