// Richard Lucas - N3088581
using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour
{
    // basic
    public string character_name_;
    public int player_number_ =  1; // 1, 2, 3 or 4 - 0 means unassigned
    public GameObject Character; // which Character are you playing as

    // gametype variables
    int score_ = 0; // KOTH add a point for each second alone in the zone


    // Use this for initialization
    void Start()
    {
        // set all the variables
        ResetAll();
    }

    // Update is called once per frame - likely not needed to be replaced with an 'on game tick' variant
    void Update()
    {
        
    }

    #region Gets, Sets and Resets
    // Gets
    public string GetName() { return character_name_; }

    // Sets
    void SetCharacterName(string CharName) { character_name_ = CharName; }

    // Resets
    //void ResetCharacterName() { characater_name_ = null; }
    void ResetPlayerNumber() { player_number_ = 0; }
    void ResetScore() { score_ = 0; }
    void ResetAll() // probably not needed
    {
        //ResetCharacterName();
        //ResetPlayerNumber();
        ResetScore();
    }

#endregion
    
    // add score
    void addScore(){ score_++; }
}
