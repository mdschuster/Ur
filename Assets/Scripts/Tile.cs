using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public Tile[] nextTiles; //use array to handle branching
                             //see inspector for the "linked list"
    public PlayerStone playerStone; //null to start with

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
