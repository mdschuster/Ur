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
    PlayerStone[] p1Stones;
    PlayerStone[] p2Stones;
    Text turnText;

    public enum turnPhase { WAITING_FOR_ROLL, WAITING_FOR_CLICK, WAITING_FOR_ANIMATION, WAITING_FOR_NEWTURN };
    public turnPhase currentPhase;

    // Use this for initialization
    void Start () {
        currentPhase = turnPhase.WAITING_FOR_ROLL;
        currentPlayerId = 0;
        theDiceRoller = GameObject.FindObjectOfType<DiceRoller>();
        turnText = GameObject.Find("PlayerText").GetComponent<Text>();
        p1Stones = GameObject.Find("Player1-StoneStorage").GetComponentsInChildren<PlayerStone>();
        p2Stones = GameObject.Find("Player2-StoneStorage").GetComponentsInChildren<PlayerStone>();
    }
	
	// Update is called once per frame
	void Update () {
		//is the turn done?
        if(currentPhase==turnPhase.WAITING_FOR_NEWTURN) {
            //Debug.Log("Turn is Done");
            newTurn();
        }
	}


    public void newTurn() {
        //This is the start of a player's turn
        //we don't have a roll for them yet

        currentPlayerId = (currentPlayerId + 1) % numberOfPlayers;

        currentPhase = turnPhase.WAITING_FOR_ROLL;
        if (currentPlayerId == 0) {
            turnText.text="Current Player: One";
        } else {
            turnText.text="Current Player: Two";
        }
        

        this.isDoneRolling = false;
        this.isDoneClicking = false;
        this.isDoneAnimating = false;
        theDiceRoller.transform.GetChild(4).GetComponent<Text>().text = "?";
    }

}
