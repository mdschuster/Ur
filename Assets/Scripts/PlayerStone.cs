using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStone : MonoBehaviour {

	DiceRoller theDiceRoller;

	// Use this for initialization
	void Start () {
		theDiceRoller = GameObject.FindObjectOfType<DiceRoller> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp(){
		//TODO: is the mouse over a UI element? Ignore click if so
		Debug.Log ("Click");

		//TODO is it our turn

		//Have we rolled the dice;
		if(theDiceRoller.isDoneRolling==false){
			//you can't move!
			return;
		}
	}
}
