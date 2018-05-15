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
    Text turnText;

    public enum turnPhase { WAITING_FOR_ROLL, WAITING_FOR_CLICK, WAITING_FOR_ANIMATION, WAITING_FOR_NEWTURN };
    public turnPhase currentPhase;

    // Use this for initialization
    void Start () {
        currentPhase = turnPhase.WAITING_FOR_ROLL;
        currentPlayerId = 0;
        theDiceRoller = GameObject.FindObjectOfType<DiceRoller>();
        turnText = GameObject.Find("PlayerText").GetComponent<Text>();
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

    public void checkLegalMoves() {

        //if we rolled zero, we have no legal moves
        if (diceTotal == 0) {
            StartCoroutine("noLegalMoveCoroutine");
            return;
        }

        //loop though all of a player's stone
        PlayerStone[] ps = GameObject.FindObjectsOfType<PlayerStone>();

        foreach (PlayerStone p in ps) {

        }



        //highlight stones that can be legally moved
        //if no legal moves, wait a sec then move to the next player (give message)
    }

    IEnumerator noLegalMoveCoroutine() {
        //display message
        //wait a sec

        //setup the new turn
        yield return new WaitForSeconds(1f);
        currentPhase = turnPhase.WAITING_FOR_NEWTURN;
    }

}
