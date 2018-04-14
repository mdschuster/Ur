using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoller : MonoBehaviour {

	public int[] diceValues = new int[4];
	public int diceTotal;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void RollTheDice(){
		// In Ur, you roll four dice (50-50 chance)
		// half the faces are 0, half are 1
		// Not physics enabled dice, just RNG for now

		diceTotal = 0;
		for (int i = 0; i < diceValues.Length; i++) {
			diceValues [i] = Random.Range (0, 2); //inclusive min, exclusive max
			diceTotal += diceValues[i];
		}

		Debug.Log ("Rolled: " + diceValues[0]+" "+ diceValues[1]+" "+ diceValues[2]+" "+ diceValues[3]+" " + " (" + diceTotal + ") ");
	}
}
