using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoller : MonoBehaviour {

	public int[] diceValues = new int[4];
	public int diceTotal;
	public Sprite[] DiceImageOne;
	public Sprite[] DiceImageZero;
	public bool isDoneRolling = false;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void newTurn(){
		//This is the start of a player's turn
		//we don't have a roll for them yet
		isDoneRolling = false;
		this.transform.GetChild (4).GetComponent<Text> ().text = "?";
	}

	public void RollTheDice(){
		// In Ur, you roll four dice (50-50 chance)
		// half the faces are 0, half are 1
		// Not physics enabled dice, just RNG for now

		diceTotal = 0;
		for (int i = 0; i < diceValues.Length; i++) {
			diceValues [i] = Random.Range (0, 2); //inclusive min, exclusive max
			diceTotal += diceValues[i];


			//Update the visuals to show dice roll
			//This could involve playing an annimation (2D or 3D)

			//We have four childre, each is a die image
			//grab that child and update it's image component to use a
			//random sprite of the correct type
			if(diceValues[i]==0){
				this.transform.GetChild (i).GetComponent<Image> ().sprite = DiceImageZero[Random.Range (0, DiceImageZero.Length)];
			} else{
				this.transform.GetChild (i).GetComponent<Image> ().sprite = DiceImageOne[Random.Range (0, DiceImageOne.Length)];
			}
		}

		//update total
		this.transform.GetChild(4).GetComponent<Text>().text=diceTotal.ToString();

		//sets doneRolling to true after all the rolling is done
		isDoneRolling = true;
	}
}
