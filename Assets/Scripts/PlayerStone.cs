using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStone : MonoBehaviour {

	DiceRoller theDiceRoller;
	public Tile startingTile;
	Tile currentTile=null;

	// Use this for initialization
	void Start () {
		theDiceRoller = GameObject.FindObjectOfType<DiceRoller> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp(){
		//TODO: is the mouse over a UI element? Ignore click if so
		//Debug.Log ("Click");

		//TODO is it our turn

		//Have we rolled the dice;
		if(theDiceRoller.isDoneRolling==false){
			//you can't move!
			return;
		}
		int spacesToMove = theDiceRoller.diceTotal;

		//where should we end up?
		if(spacesToMove==0){
			return;
		}

		Tile finalTile = null;
		for (int i = 0; i < spacesToMove; i++) {
			if (currentTile == null) { //on starting space
				finalTile = startingTile;
				currentTile = finalTile;
			} else {
				if (currentTile.nextTiles == null || currentTile.nextTiles.Length == 0) {
					//We have reaced the end and should score
					Debug.Log ("Score!");
					Destroy (gameObject);
					return;
				} else if (currentTile.nextTiles.Length > 1) {
					//branch based to player ID
					finalTile = currentTile.nextTiles [0];
					currentTile = finalTile;
				} else {
					finalTile = currentTile.nextTiles [0];
					currentTile = finalTile;
				}
			}
		}
		if(finalTile==null){
			//Somthing werid happens
			return;
		}

		//no move to final tile
		//TODO: Animate
		this.transform.position=finalTile.transform.position;

	}
}
