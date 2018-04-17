using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour {

    public int currentPlayerId=0;
    public int diceTotal;
    public int numberOfPlayers = 2;
    public bool isDoneRolling = false;
    public bool isDoneClicking = false;
    public bool isDoneAnimating = false;
    DiceRoller theDiceRoller;

    //TODO: Try enumerations
    //public enum turnPhase { WAITING_FOR_ROLL, WAITING_FOR_CLICK, WAITING_FOR_ANIMATION};
    //public turnPhase currentPhase;

    // Use this for initialization
    void Start () {
        theDiceRoller = GameObject.FindObjectOfType<DiceRoller>();
    }
	
	// Update is called once per frame
	void Update () {
		//is the turn done?
        if(isDoneAnimating && isDoneClicking && isDoneRolling) {
            Debug.Log("Turn is Done");
            newTurn();
        }
	}


    public void newTurn() {
        //This is the start of a player's turn
        //we don't have a roll for them yet

        currentPlayerId = (currentPlayerId + 1) % numberOfPlayers;

        this.isDoneRolling = false;
        this.isDoneClicking = false;
        this.isDoneAnimating = false;
        theDiceRoller.transform.GetChild(4).GetComponent<Text>().text = "?";
    }
}
